using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Passingwind.Abp.ElsaModule.Common;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Passingwind.Abp.ElsaModule.MongoDB.Repositories;

public class WorkflowInstanceRepository : MongoDbRepository<IElsaModuleMongoDbContext, WorkflowInstance, Guid>, IWorkflowInstanceRepository
{
    public WorkflowInstanceRepository(IMongoDbContextProvider<IElsaModuleMongoDbContext> dbContextProvider) : base(dbContextProvider)
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
        var query = await GetMongoQueryableAsync(cancellationToken);
        return await query
            .WhereIf(definitionIds?.Any() == true, x => definitionIds.Contains(x.WorkflowDefinitionId))
            .WhereIf(definitionVersionIds?.Any() == true, x => definitionVersionIds.Contains(x.WorkflowDefinitionVersionId))
            .WhereIf(version.HasValue, x => x.Version == version)
            .WhereIf(status.HasValue, x => x.WorkflowStatus == status)
            .WhereIf(!string.IsNullOrEmpty(correlationId), x => x.CorrelationId == correlationId)
            .WhereIf(!string.IsNullOrEmpty(name), x => x.Name.Contains(name))
            .WhereIf(creationTimes?.Length == 2, x => x.CreationTime >= creationTimes[0] && x.CreationTime <= creationTimes[1])
            .WhereIf(lastExecutedTimes?.Length == 2, x => x.LastExecutedTime.HasValue && x.LastExecutedTime >= lastExecutedTimes[0] && x.LastExecutedTime <= lastExecutedTimes[1])
            .WhereIf(finishedTimes?.Length == 2, x => x.FinishedTime.HasValue && x.FinishedTime >= finishedTimes[0] && x.FinishedTime <= finishedTimes[1])
            .WhereIf(cancelledTimes?.Length == 2, x => x.CancelledTime.HasValue && x.CancelledTime >= cancelledTimes[0] && x.CancelledTime <= cancelledTimes[1])
            .WhereIf(faultedTimes?.Length == 2, x => x.FaultedTime.HasValue && x.FaultedTime >= faultedTimes[0] && x.FaultedTime <= faultedTimes[1])
            .As<IMongoQueryable<WorkflowInstance>>()
            .LongCountAsync(cancellationToken);
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
        var query = await GetMongoQueryableAsync(cancellationToken);
        return await query
            .WhereIf(definitionIds?.Any() == true, x => definitionIds.Contains(x.WorkflowDefinitionId))
            .WhereIf(definitionVersionIds?.Any() == true, x => definitionVersionIds.Contains(x.WorkflowDefinitionVersionId))
            .WhereIf(version.HasValue, x => x.Version == version)
            .WhereIf(status.HasValue, x => x.WorkflowStatus == status)
            .WhereIf(!string.IsNullOrEmpty(correlationId), x => x.CorrelationId == correlationId)
            .WhereIf(!string.IsNullOrEmpty(name), x => x.Name.Contains(name))
            .WhereIf(creationTimes?.Length == 2, x => x.CreationTime >= creationTimes[0] && x.CreationTime <= creationTimes[1])
            .WhereIf(lastExecutedTimes?.Length == 2, x => x.LastExecutedTime.HasValue && x.LastExecutedTime >= lastExecutedTimes[0] && x.LastExecutedTime <= lastExecutedTimes[1])
            .WhereIf(finishedTimes?.Length == 2, x => x.FinishedTime.HasValue && x.FinishedTime >= finishedTimes[0] && x.FinishedTime <= finishedTimes[1])
            .WhereIf(cancelledTimes?.Length == 2, x => x.CancelledTime.HasValue && x.CancelledTime >= cancelledTimes[0] && x.CancelledTime <= cancelledTimes[1])
            .WhereIf(faultedTimes?.Length == 2, x => x.FaultedTime.HasValue && x.FaultedTime >= faultedTimes[0] && x.FaultedTime <= faultedTimes[1])
            .As<IMongoQueryable<WorkflowInstance>>()
            .ToListAsync(cancellationToken);
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
        var query = await GetMongoQueryableAsync(cancellationToken);
        return await query
            .WhereIf(definitionIds?.Any() == true, x => definitionIds.Contains(x.WorkflowDefinitionId))
            .WhereIf(definitionVersionIds?.Any() == true, x => definitionVersionIds.Contains(x.WorkflowDefinitionVersionId))
            .WhereIf(version.HasValue, x => x.Version == version)
            .WhereIf(status.HasValue, x => x.WorkflowStatus == status)
            .WhereIf(!string.IsNullOrEmpty(correlationId), x => x.CorrelationId == correlationId)
            .WhereIf(!string.IsNullOrEmpty(name), x => x.Name.Contains(name))
            .WhereIf(creationTimes?.Length == 2, x => x.CreationTime >= creationTimes[0] && x.CreationTime <= creationTimes[1])
            .WhereIf(lastExecutedTimes?.Length == 2, x => x.LastExecutedTime.HasValue && x.LastExecutedTime >= lastExecutedTimes[0] && x.LastExecutedTime <= lastExecutedTimes[1])
            .WhereIf(finishedTimes?.Length == 2, x => x.FinishedTime.HasValue && x.FinishedTime >= finishedTimes[0] && x.FinishedTime <= finishedTimes[1])
            .WhereIf(cancelledTimes?.Length == 2, x => x.CancelledTime.HasValue && x.CancelledTime >= cancelledTimes[0] && x.CancelledTime <= cancelledTimes[1])
            .WhereIf(faultedTimes?.Length == 2, x => x.FaultedTime.HasValue && x.FaultedTime >= faultedTimes[0] && x.FaultedTime <= faultedTimes[1])
            .OrderBy(sorting ?? nameof(WorkflowInstance.CreationTime) + " desc")
            .As<IMongoQueryable<WorkflowInstance>>()
            .PageBy<WorkflowInstance, IMongoQueryable<WorkflowInstance>>(skipCount, maxResultCount)
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
        var query = await GetMongoQueryableAsync(cancellationToken);

        var startDate2 = startDate.Date;
        var endDate2 = endDate.Date;

        var list = await query
                   .Where(x => x.WorkflowStatus == workflowStatus && x.CreationTime >= startDate2 && x.CreationTime <= endDate2)
                   .WhereIf(definitionId.HasValue, x => x.WorkflowDefinitionId == definitionId)
                   .As<IMongoQueryable<WorkflowInstance>>()
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
        var query = await GetMongoQueryableAsync(cancellationToken);

        return query
            .WhereIf(definitionIds?.Any() == true, x => definitionIds.Contains(x.WorkflowDefinitionId))
            .WhereIf(definitionVersionIds?.Any() == true, x => definitionVersionIds.Contains(x.WorkflowDefinitionVersionId))
            .WhereIf(version.HasValue, x => x.Version == version)
            .WhereIf(!string.IsNullOrEmpty(correlationId), x => x.CorrelationId == correlationId)
            .WhereIf(!string.IsNullOrEmpty(name), x => x.Name.Contains(name))
            .WhereIf(creationTimes?.Length == 2, x => x.CreationTime >= creationTimes[0] && x.CreationTime <= creationTimes[1])
            .GroupBy(x => x.WorkflowStatus)
            .ToDictionary(x => x.Key, x => x.Count());
    }

    public async Task<List<WorkflowInstanceFault>> GetFaultsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dbset = await GetMongoQueryableAsync(cancellationToken);
        return await dbset.Where(x => x.Id == id).SelectMany(x => x.Faults).ToListAsync(cancellationToken);
    }

    public async Task<List<WorkflowInstanceFault>> GetFaultsByWorkflowDefinitionAsync(Guid id, int skipCount, int maxResultCount, CancellationToken cancellationToken = default)
    {
        var dbset = await GetMongoQueryableAsync(cancellationToken);
        return await dbset
            .Where(x => x.WorkflowDefinitionId == id)
            .SelectMany(x => x.Faults)
            .OrderByDescending(x => x.CreationTime)
            .PageBy(skipCount, maxResultCount)
            .As<IMongoQueryable<WorkflowInstanceFault>>()
            .ToListAsync(cancellationToken);
    }

    public async Task<long> GetFaultsCountByWorkflowDefinitionAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dbset = await GetMongoQueryableAsync(cancellationToken);
        return await dbset
            .Where(x => x.WorkflowDefinitionId == id)
            .SelectMany(x => x.Faults)
            .LongCountAsync(cancellationToken);
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
        var dbset = await GetMongoQueryableAsync();

        return dbset
            .WhereIf(definitionIds?.Any() == true, x => definitionIds.Contains(x.WorkflowDefinitionId))
            .WhereIf(definitionVersionIds?.Any() == true, x => definitionVersionIds.Contains(x.WorkflowDefinitionVersionId))
            .WhereIf(version.HasValue, x => x.Version == version)
            .WhereIf(status.HasValue, x => x.WorkflowStatus == status)
            .WhereIf(!string.IsNullOrEmpty(correlationId), x => x.CorrelationId == correlationId)
            .WhereIf(!string.IsNullOrEmpty(name), x => x.Name.Contains(name))
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
        return await query
            .As<IMongoQueryable<WorkflowInstanceFault>>()
            .LongCountAsync(cancellationToken);
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

        return await query
            .As<IMongoQueryable<WorkflowInstance>>()
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);
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

        return await query
            .As<IMongoQueryable<WorkflowInstance>>()
            .ToListAsync(cancellationToken);
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
            .As<IMongoQueryable<WorkflowInstance>>()
            .PageBy<WorkflowInstance, IMongoQueryable<WorkflowInstance>>(skipCount, maxResultCount)
            .ToListAsync(cancellationToken);
    }

    public async Task CleanupAsync(Guid id, bool input = false, bool output = false, bool faults = false, bool variables = false, bool metadata = false, bool activityScopes = false, bool activityData = false, bool logs = false, CancellationToken cancellationToken = default)
    {
        var query = await GetMongoQueryableAsync();

        var dbContext = await GetDbContextAsync(cancellationToken);

        var builder = Builders<WorkflowInstance>.Update;
        var updates = new List<UpdateDefinition<WorkflowInstance>>();

        if (input)
            updates.Add(builder.Set(x => x.Input, null));
        if (output)
            updates.Add(builder.Set(x => x.Output, null));
        if (faults)
            updates.Add(builder.Set(x => x.Faults, null));
        if (variables)
            updates.Add(builder.Set(x => x.Variables, null));
        if (metadata)
            updates.Add(builder.Set(x => x.Metadata, null));
        if (activityScopes)
            updates.Add(builder.Set(x => x.ActivityScopes, null));
        if (activityData)
            updates.Add(builder.Set(x => x.ActivityData, null));

        await dbContext.WorkflowInstances.UpdateOneAsync(x => x.Id == id, builder.Combine(updates), cancellationToken: cancellationToken);

        if (logs)
        {
            await dbContext.WorkflowExecutionLogs.DeleteManyAsync(x => x.WorkflowInstanceId == id, cancellationToken: cancellationToken);
        }
    }
}
