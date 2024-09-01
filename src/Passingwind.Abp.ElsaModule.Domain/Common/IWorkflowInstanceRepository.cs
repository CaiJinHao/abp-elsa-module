using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Passingwind.Abp.ElsaModule.Common;

public interface IWorkflowInstanceRepository : IRepository<WorkflowInstance, Guid>
{
    //Task<long> LongCountAsync(
    //    string name = null,
    //    IEnumerable<Guid> definitionIds = null,
    //    IEnumerable<Guid> definitionVersionIds = null,
    //    int? version = null,
    //    WorkflowInstanceStatus? status = null,
    //    string correlationId = null,
    //    DateTime[] creationTimes = null,
    //    DateTime[] lastExecutedTimes = null,
    //    DateTime[] finishedTimes = null,
    //    DateTime[] cancelledTimes = null,
    //    DateTime[] faultedTimes = null,
    //    CancellationToken cancellationToken = default);

    //Task<List<WorkflowInstance>> GetListAsync(
    //    string name = null,
    //    IEnumerable<Guid> definitionIds = null,
    //    IEnumerable<Guid> definitionVersionIds = null,
    //    int? version = null,
    //    WorkflowInstanceStatus? status = null,
    //    string correlationId = null,
    //    DateTime[] creationTimes = null,
    //    DateTime[] lastExecutedTimes = null,
    //    DateTime[] finishedTimes = null,
    //    DateTime[] cancelledTimes = null,
    //    DateTime[] faultedTimes = null,
    //    bool includeDetails = false,
    //    CancellationToken cancellationToken = default);

    //Task<List<WorkflowInstance>> GetPagedListAsync(
    //    int skipCount,
    //    int maxResultCount,
    //    string sorting,
    //    string name = null,
    //    IEnumerable<Guid> definitionIds = null,
    //    IEnumerable<Guid> definitionVersionIds = null,
    //    int? version = null,
    //    WorkflowInstanceStatus? status = null,
    //    string correlationId = null,
    //    DateTime[] creationTimes = null,
    //    DateTime[] lastExecutedTimes = null,
    //    DateTime[] finishedTimes = null,
    //    DateTime[] cancelledTimes = null,
    //    DateTime[] faultedTimes = null,
    //    bool includeDetails = false,
    //    CancellationToken cancellationToken = default);

    Task<long> LongCountAsync(
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
        DateTime? maxFaultedTime = null,
        CancellationToken cancellationToken = default);

    Task<List<Guid>> GetIdsAsync(
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
    DateTime? maxFaultedTime = null,
    bool includeDetails = false,
    CancellationToken cancellationToken = default);

    Task<List<WorkflowInstance>> GetListAsync(
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
        DateTime? maxFaultedTime = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);

    Task<List<WorkflowInstance>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
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
        DateTime? maxFaultedTime = null,
        bool includeDetails = false,
    CancellationToken cancellationToken = default);

    Task<Dictionary<WorkflowInstanceStatus, int>> GetWorkflowStatusStatisticsAsync(
        string name = null,
        IEnumerable<Guid> definitionIds = null,
        IEnumerable<Guid> definitionVersionIds = null,
        int? version = null,
        string correlationId = null,
        DateTime[] creationTimes = null,
        CancellationToken cancellationToken = default);

    Task<Dictionary<DateTime, int>> GetStatusDateCountStatisticsAsync(
        WorkflowInstanceStatus workflowStatus,
        DateTime startDate,
        DateTime endDate,
        double timeZone = 0,
        Guid? definitionId = null,
        CancellationToken cancellationToken = default);

    Task<List<WorkflowInstanceFault>> GetFaultsAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<WorkflowInstanceFault>> GetFaultsByWorkflowDefinitionAsync(Guid id, int skipCount, int maxResultCount, CancellationToken cancellationToken = default);
    Task<long> GetFaultsCountByWorkflowDefinitionAsync(Guid id, CancellationToken cancellationToken = default);

    Task CleanupAsync(Guid id, bool input = false, bool output = false, bool faults = false, bool variables = false, bool metadata = false, bool activityScopes = false, bool activityData = false, bool logs = false, CancellationToken cancellationToken = default);
}
