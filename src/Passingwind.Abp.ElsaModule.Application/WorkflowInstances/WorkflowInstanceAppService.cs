﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elsa.Services;
using Elsa.Services.WorkflowStorage;
using Microsoft.AspNetCore.Authorization;
using Passingwind.Abp.ElsaModule.Cleanup;
using Passingwind.Abp.ElsaModule.Common;
using Passingwind.Abp.ElsaModule.Permissions;
using Passingwind.Abp.ElsaModule.Stores;
using Passingwind.Abp.ElsaModule.WorkflowDefinitions;
using Passingwind.Abp.ElsaModule.WorkflowExecutionLog;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Volo.Abp.Json;

namespace Passingwind.Abp.ElsaModule.WorkflowInstances;

[Authorize(Policy = ElsaModulePermissions.Instances.Default)]
public class WorkflowInstanceAppService : ElsaModuleAppService, IWorkflowInstanceAppService
{
    private readonly IJsonSerializer _jsonSerializer;
    private readonly IWorkflowInstanceRepository _workflowInstanceRepository;
    private readonly IWorkflowDefinitionRepository _workflowDefinitionRepository;
    private readonly IWorkflowExecutionLogRepository _workflowExecutionLogRepository;
    private readonly IStoreMapper _storeMapper;
    private readonly IWorkflowInstanceCanceller _workflowInstanceCanceller;
    private readonly IWorkflowReviver _workflowReviver;
    private readonly IWorkflowLaunchpad _workflowLaunchpad;
    private readonly IWorkflowStorageService _workflowStorageService;
    private readonly IDistributedCache<WorkflowInstanceDateCountStatisticsResultDto> _workflowInstanceDateCountStatisticsDistributedCache;
    private readonly IDistributedCache<WorkflowInstanceStatusCountStatisticsResultDto> _workflowInstanceStatusCountStatisticsDistributedCache;
    private readonly IWorkflowPermissionProvider _workflowPermissionProvider;
    private readonly IWorkflowDefinitionVersionRepository _workflowDefinitionVersionRepository;
    private readonly ICleanupRunner _cleanupRunner;

    public WorkflowInstanceAppService(
        IJsonSerializer jsonSerializer,
        IWorkflowInstanceRepository workflowInstanceRepository,
        IWorkflowDefinitionRepository workflowDefinitionRepository,
        IWorkflowExecutionLogRepository workflowExecutionLogRepository,
        IStoreMapper storeMapper,
        IWorkflowInstanceCanceller workflowInstanceCanceller,
        IWorkflowReviver workflowReviver,
        IWorkflowLaunchpad workflowLaunchpad,
        IWorkflowStorageService workflowStorageService,
        IDistributedCache<WorkflowInstanceDateCountStatisticsResultDto> workflowInstanceDateCountStatisticsDistributedCache,
        IDistributedCache<WorkflowInstanceStatusCountStatisticsResultDto> workflowInstanceStatusCountStatisticsDistributedCache,
        IWorkflowPermissionProvider workflowPermissionProvider,
        IWorkflowDefinitionVersionRepository workflowDefinitionVersionRepository,
        ICleanupRunner cleanupRunner)
    {
        _jsonSerializer = jsonSerializer;
        _workflowInstanceRepository = workflowInstanceRepository;
        _workflowDefinitionRepository = workflowDefinitionRepository;
        _workflowExecutionLogRepository = workflowExecutionLogRepository;
        _storeMapper = storeMapper;
        _workflowInstanceCanceller = workflowInstanceCanceller;
        _workflowReviver = workflowReviver;
        _workflowLaunchpad = workflowLaunchpad;
        _workflowStorageService = workflowStorageService;
        _workflowInstanceDateCountStatisticsDistributedCache = workflowInstanceDateCountStatisticsDistributedCache;
        _workflowInstanceStatusCountStatisticsDistributedCache = workflowInstanceStatusCountStatisticsDistributedCache;
        _workflowPermissionProvider = workflowPermissionProvider;
        _workflowDefinitionVersionRepository = workflowDefinitionVersionRepository;
        _cleanupRunner = cleanupRunner;
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Action)]
    public async Task CancelAsync(Guid id)
    {
        var entity = await _workflowInstanceRepository.GetAsync(id);

        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Action);

        if (entity.WorkflowStatus == WorkflowInstanceStatus.Idle || entity.WorkflowStatus == WorkflowInstanceStatus.Running || entity.WorkflowStatus == WorkflowInstanceStatus.Suspended)
        {
            var result = await _workflowInstanceCanceller.CancelAsync(id.ToString());

            if (result.Status == CancelWorkflowInstanceResultStatus.InvalidStatus)
                throw new UserFriendlyException($"Cannot cancel a workflow instance with status {result.WorkflowInstance!.WorkflowStatus}");
        }
        else
        {
            throw new UserFriendlyException($"Cannot cancel a workflow instance with status {entity.WorkflowStatus}");
        }
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Action)]
    public virtual async Task RetryAsync(Guid id, WorkflowInstanceRetryRequestDto input)
    {
        var entity = await _workflowInstanceRepository.GetAsync(id);

        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Action);

        var instance = _storeMapper.MapToModel(entity);

        if (!input.RunImmediately)
        {
            await _workflowReviver.ReviveAndQueueAsync(instance);
        }
        else
        {
            var result = await _workflowReviver.ReviveAndRunAsync(instance);

            if (result.WorkflowInstance.WorkflowStatus == Elsa.Models.WorkflowStatus.Faulted)
                throw new UserFriendlyException($"Workflow instance {result.WorkflowInstance.Id} has faulted");
        }
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Action)]
    public virtual async Task DispatchAsync(Guid id, WorkflowInstanceDispatchRequestDto input)
    {
        var entity = await _workflowInstanceRepository.GetAsync(id);

        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Action);

        await _workflowLaunchpad.DispatchPendingWorkflowAsync(id.ToString(), input.ActivityId?.ToString(), input.Input);
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Action)]
    public async Task ExecuteAsync(Guid id, WorkflowInstanceExecuteRequestDto input)
    {
        var entity = await _workflowInstanceRepository.GetAsync(id);

        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Action);

        await _workflowLaunchpad.ExecutePendingWorkflowAsync(id.ToString(), input.ActivityId?.ToString(), input.Input);
    }

    public async Task<WorkflowInstanceDto> GetAsync(Guid id)
    {
        // check can read details data
        var fullDataAccess = await AuthorizationService.IsGrantedAsync(ElsaModulePermissions.Instances.Data);

        var entity = await _workflowInstanceRepository.GetAsync(id, fullDataAccess);

        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Default);

        var instance = _storeMapper.MapToModel(entity);

        // var input = await _workflowStorageService.LoadAsync(instance);

        return ObjectMapper.Map<WorkflowInstance, WorkflowInstanceDto>(entity);
    }

    public async Task<WorkflowInstanceBasicDto> GetBasicAsync(Guid id)
    {
        var entity = await _workflowInstanceRepository.GetAsync(id, false);

        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Default);

        return ObjectMapper.Map<WorkflowInstance, WorkflowInstanceBasicDto>(entity);
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Data)]
    public async Task<ListResultDto<WorkflowExecutionLogDto>> GetExecutionLogsAsync(Guid id)
    {
        var entity = await _workflowInstanceRepository.GetAsync(id, false);

        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Data);

        var list = await _workflowExecutionLogRepository.GetListAsync(workflowInstanceId: id);

        return new ListResultDto<WorkflowExecutionLogDto>(ObjectMapper.Map<List<Common.WorkflowExecutionLog>, List<WorkflowExecutionLogDto>>(list));
    }

    public async Task<PagedResultDto<WorkflowInstanceBasicDto>> GetListAsync(WorkflowInstanceListRequestDto input)
    {
        var grantedResult = await _workflowPermissionProvider.GetGrantsAsync();

        List<Guid> definitionIds = new List<Guid>(grantedResult.WorkflowIds);

        if (input.WorkflowDefinitionId.HasValue)
        {
            // check permissions
            if (!grantedResult.WorkflowIds.Contains(input.WorkflowDefinitionId.Value) && !grantedResult.AllGranted)
            {
                throw new AbpAuthorizationException();
            }

            definitionIds = new List<Guid>() { input.WorkflowDefinitionId.Value };
        }

        definitionIds = definitionIds.Distinct().ToList();

        var count = await _workflowInstanceRepository.LongCountAsync(
            name: input.Name,
            definitionIds: definitionIds,
            version: input.Version,
            status: input.WorkflowStatus,
            correlationId: input.CorrelationId,
            minCreationTime: input.CreationTimes?.Length >= 1 ? input.CreationTimes[0] : null,
            maxCreationTime: input.CreationTimes?.Length == 2 ? input.CreationTimes[1] : null,
            minLastExecutedTime: input.LastExecutedTimes?.Length >= 1 ? input.LastExecutedTimes[0] : null,
            maxLastExecutedTime: input.LastExecutedTimes?.Length == 2 ? input.LastExecutedTimes[1] : null,
            minFinishedTime: input.FinishedTimes?.Length >= 1 ? input.FinishedTimes[0] : null,
            maxFinishedTime: input.FinishedTimes?.Length == 2 ? input.FinishedTimes[1] : null,
            minFaultedTime: input.FaultedTimes?.Length >= 1 ? input.FaultedTimes[0] : null,
            maxFaultedTime: input.FaultedTimes?.Length == 2 ? input.FaultedTimes[1] : null);

        var list = await _workflowInstanceRepository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            name: input.Name,
            definitionIds: definitionIds,
            version: input.Version,
            status: input.WorkflowStatus,
            correlationId: input.CorrelationId,
            minCreationTime: input.CreationTimes?.Length >= 1 ? input.CreationTimes[0] : null,
            maxCreationTime: input.CreationTimes?.Length == 2 ? input.CreationTimes[1] : null,
            minLastExecutedTime: input.LastExecutedTimes?.Length >= 1 ? input.LastExecutedTimes[0] : null,
            maxLastExecutedTime: input.LastExecutedTimes?.Length == 2 ? input.LastExecutedTimes[1] : null,
            minFinishedTime: input.FinishedTimes?.Length >= 1 ? input.FinishedTimes[0] : null,
            maxFinishedTime: input.FinishedTimes?.Length == 2 ? input.FinishedTimes[1] : null,
            minFaultedTime: input.FaultedTimes?.Length >= 1 ? input.FaultedTimes[0] : null,
            maxFaultedTime: input.FaultedTimes?.Length == 2 ? input.FaultedTimes[1] : null);

        return new PagedResultDto<WorkflowInstanceBasicDto>(count, ObjectMapper.Map<List<WorkflowInstance>, List<WorkflowInstanceBasicDto>>(list));
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _workflowInstanceRepository.GetAsync(id, false);
        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Delete);

        await _workflowInstanceRepository.DeleteAsync(id);
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Delete)]
    public async Task BatchDeleteAsync(WorkflowInstanceBatchActionRequestDto input)
    {
        if (input?.Ids?.Length > 0)
        {
            foreach (var id in input.Ids)
            {
                await DeleteAsync(id);
            }
        }
    }

    public async Task<WorkflowInstanceExecutionLogSummaryDto> GetLogSummaryAsync(Guid id)
    {
        var fullDataAccess = await AuthorizationService.IsGrantedAsync(ElsaModulePermissions.Instances.Data);

        var entity = await _workflowInstanceRepository.GetAsync(id);

        await CheckWorkflowPermissionAsync(entity, ElsaModulePermissions.Instances.Default);

        var allLogs = await _workflowExecutionLogRepository.GetListAsync(workflowInstanceId: id);

        var dto = new WorkflowInstanceExecutionLogSummaryDto()
        {
            Activities = new List<WorkflowInstanceExecutionLogSummaryActivityDto>()
        };

        foreach (var itemLogs in (IEnumerable<IGrouping<Guid, Common.WorkflowExecutionLog>>)allLogs.GroupBy(x => x.ActivityId))
        {
            var logs = itemLogs.OrderByDescending(x => x.Timestamp);

            var exectutingLog = logs.FirstOrDefault(x => x.EventName == "Executing");
            var exectutedLog = logs.FirstOrDefault(x => x.EventName == "Executed");
            var faultedLog = logs.FirstOrDefault(x => x.EventName == "Faulted");

            var summary = new WorkflowInstanceExecutionLogSummaryActivityDto()
            {
                ActivityId = itemLogs.Key,
                ActivityType = logs.First().ActivityType,

                StartTime = logs.Last().Timestamp,
                EndTime = logs.First().Timestamp,

                ExecutedCount = logs.Count(),

                Duration = (logs.First().Timestamp - logs.Last().Timestamp).TotalMilliseconds,

                IsExecuted = logs.Any(x => x.EventName == "Executed"),
                IsExecuting = !logs.Any(x => x.EventName == "Executed") && !logs.Any(x => x.EventName == "Faulted"),
                IsFaulted = logs.Any(x => x.EventName == "Faulted"),

                Outcomes = logs.Where(x => x.Data?.ContainsKey("Outcomes") == true).SelectMany(x => x.Data.SafeGetValue<string, object, string[]>("Outcomes")).ToArray(),

                StateData = !fullDataAccess ? null : entity.ActivityData.Find(x => x.ActivityId == itemLogs.Key)?.Data ?? default,

                JournalData = !fullDataAccess ? null : logs.First().Data,

                Message = !fullDataAccess ? null : logs.First().Message,
            };

            dto.Activities.Add(summary);
        }

        // reorder again
        dto.Activities = dto.Activities.OrderByDescending(x => x.StartTime).ToList();

        return dto;
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Statistic)]
    public async Task<WorkflowInstanceDateCountStatisticsResultDto> GetStatusDateCountStatisticsAsync(WorkflowInstanceDateCountStatisticsRequestDto input)
    {
        var datePeriod = input.DatePeriod ?? 30;
        ArgumentOutOfRangeException.ThrowIfLessThan(datePeriod, 0, nameof(input.DatePeriod));

        double tz = input.Tz;

        var endDate = Clock.Now;
        var startDate = Clock.Now.Date.AddDays(-datePeriod);

        string cacheKey = $"workflow:instance:all:statistics:datecount:dateperiod:{datePeriod}:tz:{tz}";
        if (input.WorkflowDefinitionId.HasValue)
            cacheKey = $"workflow:instance:{input.WorkflowDefinitionId}:statistics:datecount:dateperiod:{datePeriod}:tz:{tz}";

        return await _workflowInstanceDateCountStatisticsDistributedCache.GetOrAddAsync(cacheKey, async () =>
        {
            var finished = await _workflowInstanceRepository.GetStatusDateCountStatisticsAsync(
                WorkflowInstanceStatus.Finished,
                startDate,
                endDate,
                timeZone: tz,
                definitionId: input.WorkflowDefinitionId);
            var faulted = await _workflowInstanceRepository.GetStatusDateCountStatisticsAsync(
                WorkflowInstanceStatus.Faulted,
                startDate,
                endDate,
                timeZone: tz,
                definitionId: input.WorkflowDefinitionId);

            var dto = new WorkflowInstanceDateCountStatisticsResultDto();

            for (int i = 1; i <= datePeriod; i++)
            {
                var date = startDate.Date.AddDays(i);
                dto.Items.Add(new WorkflowInstanceDateCountStatisticDto
                {
                    Date = date,
                    FailedCount = faulted.TryGetValue(date.Date, out var value) ? value : 0,
                    FinishedCount = finished.TryGetValue(date.Date, out var value2) ? value2 : 0,
                });
            }

            return dto;
        }, () => new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(5),
        });
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Statistic)]
    public async Task<WorkflowInstanceStatusCountStatisticsResultDto> GetStatusCountStatisticsAsync(WorkflowInstanceStatusCountStatisticsRequestDto input)
    {
        string cacheKey = "workflow:instance:all:statistic:statuscount";
        if (input.WorkflowDefinitionId.HasValue)
            cacheKey = $"workflow:instance:{input.WorkflowDefinitionId}:statistic:statuscount";

        return await _workflowInstanceStatusCountStatisticsDistributedCache.GetOrAddAsync(cacheKey, async () =>
        {
            var allCount = await _workflowInstanceRepository.LongCountAsync(definitionIds: input.WorkflowDefinitionId.HasValue ? new[] { input.WorkflowDefinitionId.Value } : null);
            var runningCount = await _workflowInstanceRepository.LongCountAsync(
                definitionIds: input.WorkflowDefinitionId.HasValue ? new[] { input.WorkflowDefinitionId.Value } : null,
                status: WorkflowInstanceStatus.Running);
            var faultedCount = await _workflowInstanceRepository.LongCountAsync(
                definitionIds: input.WorkflowDefinitionId.HasValue ? new[] { input.WorkflowDefinitionId.Value } : null,
                status: WorkflowInstanceStatus.Faulted);
            var suspendedCount = await _workflowInstanceRepository.LongCountAsync(
                definitionIds: input.WorkflowDefinitionId.HasValue ? new[] { input.WorkflowDefinitionId.Value } : null,
                status: WorkflowInstanceStatus.Suspended);
            var finishedCount = await _workflowInstanceRepository.LongCountAsync(
                definitionIds: input.WorkflowDefinitionId.HasValue ? new[] { input.WorkflowDefinitionId.Value } : null,
                status: WorkflowInstanceStatus.Finished);

            return new WorkflowInstanceStatusCountStatisticsResultDto
            {
                All = allCount,
                Faulted = faultedCount,
                Finished = finishedCount,
                Suspended = suspendedCount,
                Running = runningCount,
            };
        }, () => new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(2),
        });
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Action)]
    public async Task BatchCancelAsync(WorkflowInstanceBatchActionRequestDto input)
    {
        // TODO check permissions

        if (input?.Ids?.Length > 0)
        {
            foreach (var id in input.Ids)
            {
                await CancelAsync(id);
            }
        }
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Action)]
    public async Task BatchRetryAsync(WorkflowInstanceBatchActionRequestDto input)
    {
        // TODO check permissions

        if (input?.Ids?.Length > 0)
        {
            foreach (var id in input.Ids)
            {
                await RetryAsync(id, new WorkflowInstanceRetryRequestDto { RunImmediately = false });
            }
        }
    }

    public async Task<ListResultDto<WorkflowInstanceFaultDto>> GetFaultsAsync(Guid id)
    {
        var list = await _workflowInstanceRepository.GetFaultsAsync(id);

        return new ListResultDto<WorkflowInstanceFaultDto>(ObjectMapper.Map<List<WorkflowInstanceFault>, List<WorkflowInstanceFaultDto>>(list));
    }

    public async Task<PagedResultDto<WorkflowInstanceFaultDto>> GetFaultsByWorkflowDefinitionAsync(Guid id, WorkflowInstanceFaultRequestDto input)
    {
        var count = await _workflowInstanceRepository.GetFaultsCountByWorkflowDefinitionAsync(id);
        var list = await _workflowInstanceRepository.GetFaultsByWorkflowDefinitionAsync(id, input.SkipCount, input.MaxResultCount);

        return new PagedResultDto<WorkflowInstanceFaultDto>(count, ObjectMapper.Map<List<WorkflowInstanceFault>, List<WorkflowInstanceFaultDto>>(list));
    }

    public async Task<PagedResultDto<WorkflowDefinitionBasicDto>> GetAssignableDefinitionAsync(WorkflowDefinitionListRequestDto input)
    {
        var grantedResult = await _workflowPermissionProvider.GetGrantsAsync();

        var count = await _workflowDefinitionRepository.CountAsync(
            name: input.Filter,
            isSingleton: input.IsSingleton,
            deleteCompletedInstances: input.DeleteCompletedInstances,
            channel: input.Channel,
            tag: input.Tag,
            groupId: input.GroupId,
            filterIds: grantedResult.AllGranted ? null : grantedResult.WorkflowIds);

        var list = await _workflowDefinitionRepository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            name: input.Filter,
            isSingleton: input.IsSingleton,
            deleteCompletedInstances: input.DeleteCompletedInstances,
            channel: input.Channel,
            tag: input.Tag,
            groupId: input.GroupId,
            filterIds: grantedResult.AllGranted ? null : grantedResult.WorkflowIds,
            ordering: input.Sorting);

        return new PagedResultDto<WorkflowDefinitionBasicDto>(count, ObjectMapper.Map<List<WorkflowDefinition>, List<WorkflowDefinitionBasicDto>>(list));
    }

    public async Task<WorkflowDefinitionVersionDto> GetDefinitionAsync(Guid id)
    {
        var instance = await _workflowInstanceRepository.GetAsync(id);

        var definition = await _workflowDefinitionRepository.GetAsync(instance.WorkflowDefinitionId);
        var version = await _workflowDefinitionVersionRepository.GetByVersionAsync(instance.WorkflowDefinitionId, instance.Version);

        var dto = ObjectMapper.Map<WorkflowDefinitionVersion, WorkflowDefinitionVersionDto>(version);
        dto.Definition = ObjectMapper.Map<WorkflowDefinition, WorkflowDefinitionDto>(definition);
        return dto;
    }

    [Authorize(Policy = ElsaModulePermissions.Instances.Cleanup)]
    public async Task CleanupAsync()
    {
        await _cleanupRunner.RunAsync(true);
    }
}
