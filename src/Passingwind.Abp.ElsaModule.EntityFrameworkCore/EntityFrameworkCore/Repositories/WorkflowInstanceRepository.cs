using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Passingwind.Abp.ElsaModule.Common;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Passingwind.Abp.ElsaModule.EntityFrameworkCore.Repositories;

public class WorkflowInstanceRepository : EfCoreRepository<ElsaModuleDbContext, WorkflowInstance, Guid>, IWorkflowInstanceRepository
{
    public WorkflowInstanceRepository(IDbContextProvider<ElsaModuleDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<long> LongCountAsync(
        string name = null,
        IEnumerable<Guid> definitionIds = null,
        IEnumerable<Guid> definitionVersionIds = null,
        int? version = null,
        WorkflowInstanceStatus? status = null,
        string correlationId = null,
        DateTime[] creationTimes = null,
        DateTime[] lastExecutedTimes = null,
        DateTime[] finishedTimes = null,
        DateTime[] cancelledTimes = null,
        DateTime[] faultedTimes = null,
        CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(
            name: name,
            definitionIds: definitionIds,
            definitionVersionIds: definitionVersionIds,
            version: version,
            status: status,
            correlationId: correlationId,
            creationTimes: creationTimes,
            lastExecutedTimes: lastExecutedTimes,
            finishedTimes: finishedTimes,
            cancelledTimes: cancelledTimes,
            faultedTimes: faultedTimes);
        return await query.LongCountAsync(cancellationToken);
    }

    public async Task<List<WorkflowInstance>> GetListAsync(
        string name = null,
        IEnumerable<Guid> definitionIds = null,
        IEnumerable<Guid> definitionVersionIds = null,
        int? version = null,
        WorkflowInstanceStatus? status = null,
        string correlationId = null,
        DateTime[] creationTimes = null,
        DateTime[] lastExecutedTimes = null,
        DateTime[] finishedTimes = null,
        DateTime[] cancelledTimes = null,
        DateTime[] faultedTimes = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(
            name: name,
            definitionIds: definitionIds,
            definitionVersionIds: definitionVersionIds,
            version: version,
            status: status,
            correlationId: correlationId,
            creationTimes: creationTimes,
            lastExecutedTimes: lastExecutedTimes,
            finishedTimes: finishedTimes,
            cancelledTimes: cancelledTimes,
            faultedTimes: faultedTimes);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<WorkflowInstance>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string name = null,
        IEnumerable<Guid> definitionIds = null,
        IEnumerable<Guid> definitionVersionIds = null,
        int? version = null,
        WorkflowInstanceStatus? status = null,
        string correlationId = null,
        DateTime[] creationTimes = null,
        DateTime[] lastExecutedTimes = null,
        DateTime[] finishedTimes = null,
        DateTime[] cancelledTimes = null,
        DateTime[] faultedTimes = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(
            name: name,
            definitionIds: definitionIds,
            definitionVersionIds: definitionVersionIds,
            version: version,
            status: status,
            correlationId: correlationId,
            creationTimes: creationTimes,
            lastExecutedTimes: lastExecutedTimes,
            finishedTimes: finishedTimes,
            cancelledTimes: cancelledTimes,
            faultedTimes: faultedTimes);
        return await query
            .OrderBy(sorting ?? nameof(WorkflowInstance.CreationTime) + " desc")
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(cancellationToken);
    }

    protected virtual async Task<IQueryable<WorkflowInstance>> GetQueryableAsync(
        string name = null,
        IEnumerable<Guid> definitionIds = null,
        IEnumerable<Guid> definitionVersionIds = null,
        int? version = null,
        WorkflowInstanceStatus? status = null,
        string correlationId = null,
        DateTime[] creationTimes = null,
        DateTime[] lastExecutedTimes = null,
        DateTime[] finishedTimes = null,
        DateTime[] cancelledTimes = null,
        DateTime[] faultedTimes = null)
    {
        var dbset = await GetDbSetAsync();
        return dbset
            .WhereIf(definitionIds?.Any() == true, x => definitionIds.Contains(x.WorkflowDefinitionId))
            .WhereIf(definitionVersionIds?.Any() == true, x => definitionVersionIds.Contains(x.WorkflowDefinitionVersionId))
            .WhereIf(version.HasValue, x => x.Version == version)
            .WhereIf(status.HasValue, x => x.WorkflowStatus == status)
            .WhereIf(!string.IsNullOrEmpty(correlationId), x => x.CorrelationId == correlationId)
            .WhereIf(!string.IsNullOrEmpty(name), x => EF.Functions.Like(x.Name, $"%{name}%"))
            .WhereIf(creationTimes?.Length == 2, x => x.CreationTime >= creationTimes[0] && x.CreationTime <= creationTimes[1])
            .WhereIf(lastExecutedTimes?.Length == 2, x => x.LastExecutedTime.HasValue && x.LastExecutedTime >= lastExecutedTimes[0] && x.LastExecutedTime <= lastExecutedTimes[1])
            .WhereIf(finishedTimes?.Length == 2, x => x.FinishedTime.HasValue && x.FinishedTime >= finishedTimes[0] && x.FinishedTime <= finishedTimes[1])
            .WhereIf(cancelledTimes?.Length == 2, x => x.CancelledTime.HasValue && x.CancelledTime >= cancelledTimes[0] && x.CancelledTime <= cancelledTimes[1])
            .WhereIf(faultedTimes?.Length == 2, x => x.FaultedTime.HasValue && x.FaultedTime >= faultedTimes[0] && x.FaultedTime <= faultedTimes[1]);
    }

    protected virtual async Task<IQueryable<WorkflowInstance>> GetQueryableAsync(
        string name = null,
        IEnumerable<Guid> definitionIds = null,
        IEnumerable<Guid> definitionVersionIds = null,
        int? version = null,
        WorkflowInstanceStatus? status = null,
        string correlationId = null,
        DateTime? minCreationTime = null,
        DateTime? maxCreationTime = null,
        DateTime? minLastExecutedTime = null,
        DateTime? maxLastExecutedTime = null,
        DateTime? minFinishedTime = null,
        DateTime? maxFinishedTime = null,
        DateTime? minCancelledTime = null,
        DateTime? maxCancelledTime = null,
        DateTime? minFaultedTime = null,
        DateTime? maxFaultedTime = null)
    {
        var dbset = await GetDbSetAsync();
        return dbset
            .WhereIf(definitionIds?.Any() == true, x => definitionIds.Contains(x.WorkflowDefinitionId))
            .WhereIf(definitionVersionIds?.Any() == true, x => definitionVersionIds.Contains(x.WorkflowDefinitionVersionId))
            .WhereIf(version.HasValue, x => x.Version == version)
            .WhereIf(status.HasValue, x => x.WorkflowStatus == status)
            .WhereIf(!string.IsNullOrEmpty(correlationId), x => x.CorrelationId == correlationId)
            .WhereIf(!string.IsNullOrEmpty(name), x => EF.Functions.Like(x.Name, $"%{name}%"))
            .WhereIf(minCreationTime.HasValue, x => x.CreationTime >= minCreationTime)
            .WhereIf(maxCreationTime.HasValue, x => x.CreationTime <= maxCreationTime)
            .WhereIf(minLastExecutedTime.HasValue, x => x.LastExecutedTime >= minLastExecutedTime)
            .WhereIf(maxLastExecutedTime.HasValue, x => x.LastExecutedTime <= maxLastExecutedTime)
            .WhereIf(minFinishedTime.HasValue, x => x.FinishedTime >= minFinishedTime)
            .WhereIf(maxFinishedTime.HasValue, x => x.FinishedTime <= maxFinishedTime)
            .WhereIf(minCancelledTime.HasValue, x => x.CancelledTime >= minCancelledTime)
            .WhereIf(maxCancelledTime.HasValue, x => x.CancelledTime <= maxCancelledTime)
            .WhereIf(minFaultedTime.HasValue, x => x.FaultedTime >= minFaultedTime)
            .WhereIf(maxFaultedTime.HasValue, x => x.FaultedTime <= maxFaultedTime)
            ;
    }

    public async Task<long> LongCountAsync(string name = null, IEnumerable<Guid> definitionIds = null, IEnumerable<Guid> definitionVersionIds = null, int? version = null, WorkflowInstanceStatus? status = null, string correlationId = null, DateTime? minCreationTime = null, DateTime? maxCreationTime = null, DateTime? minLastExecutedTime = null, DateTime? maxLastExecutedTime = null, DateTime? minFinishedTime = null, DateTime? maxFinishedTime = null, DateTime? minCancelledTime = null, DateTime? maxCancelledTime = null, DateTime? minFaultedTime = null, DateTime? maxFaultedTime = null, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(
            name: name,
            definitionIds: definitionIds,
            definitionVersionIds: definitionVersionIds,
            version: version,
            status: status,
            correlationId: correlationId,
            minCreationTime: minCreationTime,
            maxCreationTime: maxCreationTime,
            minLastExecutedTime: minLastExecutedTime,
            maxLastExecutedTime: maxLastExecutedTime,
            minFinishedTime: minFinishedTime,
            maxFinishedTime: maxFinishedTime,
            minCancelledTime: minCancelledTime,
            maxCancelledTime: maxCancelledTime,
            minFaultedTime: minFaultedTime,
            maxFaultedTime: maxFaultedTime);
        return await query.LongCountAsync(cancellationToken);
    }

    public async Task<List<Guid>> GetIdsAsync(string name = null, IEnumerable<Guid> definitionIds = null, IEnumerable<Guid> definitionVersionIds = null, int? version = null, WorkflowInstanceStatus? status = null, string correlationId = null, DateTime? minCreationTime = null, DateTime? maxCreationTime = null, DateTime? minLastExecutedTime = null, DateTime? maxLastExecutedTime = null, DateTime? minFinishedTime = null, DateTime? maxFinishedTime = null, DateTime? minCancelledTime = null, DateTime? maxCancelledTime = null, DateTime? minFaultedTime = null, DateTime? maxFaultedTime = null, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(
             name: name,
             definitionIds: definitionIds,
             definitionVersionIds: definitionVersionIds,
             version: version,
             status: status,
             correlationId: correlationId,
             minCreationTime: minCreationTime,
             maxCreationTime: maxCreationTime,
             minLastExecutedTime: minLastExecutedTime,
             maxLastExecutedTime: maxLastExecutedTime,
             minFinishedTime: minFinishedTime,
             maxFinishedTime: maxFinishedTime,
             minCancelledTime: minCancelledTime,
             maxCancelledTime: maxCancelledTime,
             minFaultedTime: minFaultedTime,
             maxFaultedTime: maxFaultedTime);
        return await query.Select(x => x.Id).ToListAsync(cancellationToken);
    }

    public async Task<List<WorkflowInstance>> GetListAsync(string name = null, IEnumerable<Guid> definitionIds = null, IEnumerable<Guid> definitionVersionIds = null, int? version = null, WorkflowInstanceStatus? status = null, string correlationId = null, DateTime? minCreationTime = null, DateTime? maxCreationTime = null, DateTime? minLastExecutedTime = null, DateTime? maxLastExecutedTime = null, DateTime? minFinishedTime = null, DateTime? maxFinishedTime = null, DateTime? minCancelledTime = null, DateTime? maxCancelledTime = null, DateTime? minFaultedTime = null, DateTime? maxFaultedTime = null, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(
             name: name,
             definitionIds: definitionIds,
             definitionVersionIds: definitionVersionIds,
             version: version,
             status: status,
             correlationId: correlationId,
             minCreationTime: minCreationTime,
             maxCreationTime: maxCreationTime,
             minLastExecutedTime: minLastExecutedTime,
             maxLastExecutedTime: maxLastExecutedTime,
             minFinishedTime: minFinishedTime,
             maxFinishedTime: maxFinishedTime,
             minCancelledTime: minCancelledTime,
             maxCancelledTime: maxCancelledTime,
             minFaultedTime: minFaultedTime,
             maxFaultedTime: maxFaultedTime);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<List<WorkflowInstance>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, string name = null, IEnumerable<Guid> definitionIds = null, IEnumerable<Guid> definitionVersionIds = null, int? version = null, WorkflowInstanceStatus? status = null, string correlationId = null, DateTime? minCreationTime = null, DateTime? maxCreationTime = null, DateTime? minLastExecutedTime = null, DateTime? maxLastExecutedTime = null, DateTime? minFinishedTime = null, DateTime? maxFinishedTime = null, DateTime? minCancelledTime = null, DateTime? maxCancelledTime = null, DateTime? minFaultedTime = null, DateTime? maxFaultedTime = null, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var query = await GetQueryableAsync(
            name: name,
            definitionIds: definitionIds,
            definitionVersionIds: definitionVersionIds,
            version: version,
            status: status,
            correlationId: correlationId,
            minCreationTime: minCreationTime,
            maxCreationTime: maxCreationTime,
            minLastExecutedTime: minLastExecutedTime,
            maxLastExecutedTime: maxLastExecutedTime,
            minFinishedTime: minFinishedTime,
            maxFinishedTime: maxFinishedTime,
            minCancelledTime: minCancelledTime,
            maxCancelledTime: maxCancelledTime,
            minFaultedTime: minFaultedTime,
            maxFaultedTime: maxFaultedTime);
        return await query
            .OrderBy(sorting ?? nameof(WorkflowInstance.CreationTime) + " desc")
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<Dictionary<DateTime, int>> GetStatusDateCountStatisticsAsync(
        WorkflowInstanceStatus workflowStatus,
        DateTime startDate,
        DateTime endDate,
        double timeZone = 0,
        Guid? definitionId = null,
        CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();

        var list = await dbset
              .Where(x => x.WorkflowStatus == workflowStatus && x.CreationTime >= startDate && x.CreationTime <= endDate)
              .WhereIf(definitionId.HasValue, x => x.WorkflowDefinitionId == definitionId)
              .Select(x => new { x.Id, x.CreationTime })
              .ToListAsync(cancellationToken);

        return list
                .Select(x => new { Id = x.Id, CreationTime = x.CreationTime.AddHours(timeZone) })
                .GroupBy(x => x.CreationTime.Date)
                .ToDictionary(x => x.Key.Date, x => x.Count());
    }

    public async Task<Dictionary<WorkflowInstanceStatus, int>> GetWorkflowStatusStatisticsAsync(
        string name = null,
        IEnumerable<Guid> definitionIds = null,
        IEnumerable<Guid> definitionVersionIds = null,
        int? version = null,
        string correlationId = null,
        DateTime[] creationTimes = null,
        CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();

        var list = await dbset
            .WhereIf(definitionIds?.Any() == true, x => definitionIds.Contains(x.WorkflowDefinitionId))
            .WhereIf(definitionVersionIds?.Any() == true, x => definitionVersionIds.Contains(x.WorkflowDefinitionVersionId))
            .WhereIf(version.HasValue, x => x.Version == version)
            .WhereIf(!string.IsNullOrEmpty(correlationId), x => x.CorrelationId == correlationId)
            .WhereIf(!string.IsNullOrEmpty(name), x => EF.Functions.Like(x.Name, $"%{name}%"))
            .WhereIf(creationTimes?.Length == 2, x => x.CreationTime >= creationTimes[0] && x.CreationTime <= creationTimes[1])
            .Select(x => new { x.Id, x.WorkflowStatus })
            .ToListAsync(cancellationToken);

        return list
                .GroupBy(x => x.WorkflowStatus)
                .ToDictionary(x => x.Key, x => x.Count());
    }

    public async Task<List<WorkflowInstanceFault>> GetFaultsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();
        return await dbset.Where(x => x.Id == id).SelectMany(x => x.Faults).ToListAsync(cancellationToken);
    }

    public async Task<List<WorkflowInstanceFault>> GetFaultsByWorkflowDefinitionAsync(Guid id, int skipCount, int maxResultCount, CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();
        return await dbset
            .Where(x => x.WorkflowDefinitionId == id)
            .SelectMany(x => x.Faults)
            .OrderByDescending(x => x.CreationTime)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<long> GetFaultsCountByWorkflowDefinitionAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dbset = await GetDbSetAsync();
        return await dbset
            .Where(x => x.WorkflowDefinitionId == id)
            .SelectMany(x => x.Faults)
            .LongCountAsync(cancellationToken);
    }

    public async Task CleanupAsync(Guid id, bool input = false, bool output = false, bool faults = false, bool variables = false, bool metadata = false, bool activityScopes = false, bool activityData = false, bool logs = false, CancellationToken cancellationToken = default)
    {
        var dbContext = await GetDbContextAsync();
        var dbset = await GetDbSetAsync();

        if (input)
            await dbset.Where(x => x.Id == id).ExecuteUpdateAsync(x => x.SetProperty(x => x.Input, (_) => null), cancellationToken: cancellationToken);
        if (output)
            await dbset.Where(x => x.Id == id).ExecuteUpdateAsync(x => x.SetProperty(x => x.Output, (_) => null), cancellationToken: cancellationToken);
        if (faults)
            await dbContext.Set<WorkflowInstanceFault>().Where(x => x.WorkflowInstanceId == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
        if (variables)
            await dbContext.Set<WorkflowInstanceVariable>().Where(x => x.WorkflowInstanceId == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
        if (metadata)
            await dbContext.Set<WorkflowInstanceMetadata>().Where(x => x.WorkflowInstanceId == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
        if (activityScopes)
            await dbContext.Set<WorkflowInstanceActivityScope>().Where(x => x.WorkflowInstanceId == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
        if (activityData)
            await dbContext.Set<WorkflowInstanceActivityData>().Where(x => x.WorkflowInstanceId == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
        if (logs)
            await dbContext.Set<WorkflowExecutionLog>().Where(x => x.WorkflowInstanceId == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}