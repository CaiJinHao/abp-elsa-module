﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Passingwind.Abp.ElsaModule.Common;
using Passingwind.Abp.ElsaModule.GlobalCodes;
using Passingwind.Abp.ElsaModule.Groups;
using Passingwind.Abp.ElsaModule.Teams;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace Passingwind.Abp.ElsaModule.EntityFrameworkCore;

public static class ElsaModuleDbContextModelCreatingExtensions
{
    public static void ConfigureElsaModule(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder
            .Entity<WorkflowDefinition>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowDefinitions", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.DisplayName).HasMaxLength(128);
                b.Property(x => x.Description).HasMaxLength(256);
                b.Property(x => x.Channel).HasMaxLength(64);
                b.Property(x => x.GroupName).HasMaxLength(64);

                b.Property(x => x.Tag).HasMaxLength(64);
                b.Property(x => x.ContextOptions).HasConversion(new EfCoreJsonValueConverter<Elsa.Models.WorkflowContextOptions>(), ValueComparer.CreateDefault(typeof(Elsa.Models.WorkflowContextOptions), false));
                b.Property(x => x.Variables).HasConversion(new EfCoreJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));
                b.Property(x => x.CustomAttributes).HasConversion(new EfCoreJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));

                // b.HasMany(x => x.Versions).WithOne(x => x.Definition).HasForeignKey(x => x.DefinitionId);
                b.HasIndex(x => x.Name);
            })
            .Entity<WorkflowDefinitionVersion>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowDefinitionVersions", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasMany(x => x.Activities);
                b.HasMany(x => x.Connections);

                b.HasIndex(x => new { x.DefinitionId, x.Version });

                b.HasMany(x => x.Activities).WithOne().HasForeignKey(x => x.WorkflowDefinitionVersionId);
                b.HasMany(x => x.Connections).WithOne().HasForeignKey(x => x.WorkflowDefinitionVersionId);
            })
            .Entity<Activity>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "Activities", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowDefinitionVersionId, x.ActivityId });

                b.Property(x => x.Type).IsRequired().HasMaxLength(32);
                b.Property(x => x.Name).IsRequired().HasMaxLength(64);
                b.Property(x => x.DisplayName).HasMaxLength(128);
                b.Property(x => x.Description).HasMaxLength(256);

                b.Property(x => x.Properties).HasConversion(new EfCoreJsonValueConverter<List<Elsa.Models.ActivityDefinitionProperty>>(), ValueComparer.CreateDefault(typeof(List<Elsa.Models.ActivityDefinitionProperty>), false));
                b.Property(x => x.Attributes).HasConversion(new EfCoreJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));
                b.Property(x => x.PropertyStorageProviders).HasConversion(new EfCoreJsonValueConverter<Dictionary<string, string>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, string>), false));
            })
            .Entity<ActivityConnection>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "ActivityConnections", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowDefinitionVersionId, x.SourceId, x.TargetId, x.Outcome, });

                b.Property(x => x.Outcome).IsRequired().HasMaxLength(64);
                b.Property(x => x.Attributes).HasConversion(new EfCoreJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));
            })
            .Entity<Bookmark>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "Bookmarks", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Hash).HasMaxLength(128);
                // b.Property(x => x.Model).HasMaxLength(128);
                b.Property(x => x.ModelType).HasMaxLength(256);
                b.Property(x => x.ActivityType).HasMaxLength(256);
                b.Property(x => x.CorrelationId).HasMaxLength(128);
            })
            .Entity<Trigger>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "Triggers", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Hash).HasMaxLength(128);
                // b.Property(x => x.Model).HasMaxLength(128);
                b.Property(x => x.ModelType).HasMaxLength(256);
                b.Property(x => x.ActivityType).HasMaxLength(256);
            })
            .Entity<WorkflowInstance>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowInstances", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                b.Property(x => x.CorrelationId).HasMaxLength(128);
                b.Property(x => x.ContextType).HasMaxLength(128);
                b.Property(x => x.ContextId).HasMaxLength(128);

                b.Property(x => x.Input).HasConversion(new EfCoreJsonValueConverter<Elsa.Services.Models.WorkflowInputReference>(), ValueComparer.CreateDefault(typeof(Elsa.Services.Models.WorkflowInputReference), false));
                b.Property(x => x.Output).HasConversion(new EfCoreJsonValueConverter<Elsa.Services.Models.WorkflowOutputReference>(), ValueComparer.CreateDefault(typeof(Elsa.Services.Models.WorkflowOutputReference), false));
#pragma warning disable CS0618 // Type or member is obsolete
                b.Property(x => x.Fault).HasConversion(new EfCoreJsonValueConverter<Elsa.Models.WorkflowFault>(), ValueComparer.CreateDefault(typeof(Elsa.Models.WorkflowFault), false));
#pragma warning restore CS0618 // Type or member is obsolete
                b.Property(x => x.CurrentActivity).HasConversion(new EfCoreJsonValueConverter<WorkflowInstanceScheduledActivity>(), ValueComparer.CreateDefault(typeof(WorkflowInstanceScheduledActivity), false));

                //b.Property(x => x.ScheduledActivities).HasConversion(new ElsaEFJsonValueConverter<List<Elsa.Models.ScheduledActivity>>(), ValueComparer.CreateDefault(typeof(List<Elsa.Models.ScheduledActivity>), false));
                //b.Property(x => x.BlockingActivities).HasConversion(new ElsaEFJsonValueConverter<List<Elsa.Models.BlockingActivity>>(), ValueComparer.CreateDefault(typeof(List<Elsa.Models.BlockingActivity>), false));
                //b.Property(x => x.ActivityScopes).HasConversion(new ElsaEFJsonValueConverter<List<Elsa.Models.ActivityScope>>(), ValueComparer.CreateDefault(typeof(List<Elsa.Models.ActivityScope>), false));
                // b.Property(x => x.ActivityData).HasConversion(new ElsaEFJsonValueConverter<Dictionary<Guid, IDictionary<string, object>>>(), ValueComparer.CreateDefault(typeof(Dictionary<Guid, IDictionary<string, object>>), false));
                //b.Property(x => x.Variables).HasConversion(new ElsaEFJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));
                //b.Property(x => x.Metadata).HasConversion(new ElsaEFJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));

                // b.HasOne(x => x.Definition).WithOne().OnDelete(DeleteBehavior.SetNull);
                // b.HasOne(x => x.DefinitionVersion).WithOne();

                b.HasIndex(x => x.Name);
                b.HasIndex(x => x.WorkflowStatus);
                b.HasIndex(x => x.WorkflowDefinitionId);
                b.HasIndex(x => new { x.WorkflowDefinitionId, x.WorkflowDefinitionVersionId });
            })
            .Entity<WorkflowInstanceActivityData>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowInstanceActivityData", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowInstanceId, x.ActivityId });

                b.Property(x => x.Data).HasConversion(new EfCoreJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));
            })
            .Entity<WorkflowInstanceBlockingActivity>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowInstanceBlockingActivities", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowInstanceId, x.ActivityId });

                b.Property(x => x.ActivityType).HasMaxLength(256).IsRequired();
            })
            .Entity<WorkflowInstanceScheduledActivity>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowInstanceScheduledActivities", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowInstanceId, x.ActivityId });

                b.Property(x => x.Input).HasConversion(new EfCoreJsonValueConverter<object>(), ValueComparer.CreateDefault(typeof(object), false));
            })
            .Entity<WorkflowInstanceMetadata>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowInstanceMetadata", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowInstanceId, x.Key });

                b.Property(x => x.Key).HasMaxLength(256).IsRequired();

                b.Property(x => x.Value).HasConversion(new EfCoreJsonValueConverter<object>(), ValueComparer.CreateDefault(typeof(object), false));
            })
            .Entity<WorkflowInstanceActivityScope>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowInstanceScopes", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowInstanceId, x.ActivityId });

                b.Property(x => x.Variables).HasConversion(new EfCoreJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));
            })
            .Entity<WorkflowInstanceVariable>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowInstanceVariables", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowInstanceId, x.Key });

                b.Property(x => x.Key).HasMaxLength(256).IsRequired();

                b.Property(x => x.Value).HasConversion(new EfCoreJsonValueConverter<object>(), ValueComparer.CreateDefault(typeof(object), false));

                b.HasIndex(x => x.Key);
            })
            .Entity<WorkflowInstanceFault>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowInstanceFaults", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.Id, x.WorkflowInstanceId });

                b.Property(x => x.ActivityInput).HasConversion(new EfCoreJsonValueConverter<object>(), ValueComparer.CreateDefault(typeof(object), false));
                b.Property(x => x.Exception).HasConversion(new EfCoreJsonValueConverter<SimpleExceptionModel>(), ValueComparer.CreateDefault(typeof(SimpleExceptionModel), false));
            })
            .Entity<WorkflowExecutionLog>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowExecutionLogs", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.ActivityType).HasMaxLength(256);
                b.Property(x => x.EventName).HasMaxLength(128);
                b.Property(x => x.Source).HasMaxLength(128);
                b.Property(x => x.Data).HasConversion(new EfCoreJsonValueConverter<Dictionary<string, object>>(), ValueComparer.CreateDefault(typeof(Dictionary<string, object>), false));

                b.HasIndex(x => x.WorkflowInstanceId);
            })
            .Entity<GlobalVariable>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "GlobalVariables", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Key).HasMaxLength(256).IsRequired();
                b.HasIndex(x => x.Key);

                b.HasIndex(x => x.Key);
            })
            .Entity<WorkflowTeam>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowTeams", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Name).HasMaxLength(128).IsRequired();

                b.HasMany(x => x.Users).WithOne().HasForeignKey(x => x.WorkflowTeamId);
                b.HasMany(x => x.RoleScopes).WithOne().HasForeignKey(x => x.WorkflowTeamId);

                b.HasIndex(x => x.Name);
            })
            .Entity<WorkflowTeamUser>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowTeamUsers", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.HasKey(x => new { x.WorkflowTeamId, x.UserId });
            })
            .Entity<WorkflowTeamRoleScope>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowTeamRoleScopes", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.RoleName).IsRequired().HasMaxLength(IdentityRoleConsts.MaxNameLength);
                b.Property(x => x.Values).HasConversion(new EfCoreJsonValueConverter<List<WorkflowTeamRoleScopeValue>>(), ValueComparer.CreateDefault(typeof(List<WorkflowTeamRoleScopeValue>), false));

                b.HasKey(x => new { x.WorkflowTeamId, x.RoleName });
            })
            .Entity<WorkflowGroup>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "WorkflowGroups", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Name).HasMaxLength(64).IsRequired();
                b.Property(x => x.Description).HasMaxLength(256);
            })
            .Entity<GlobalCode>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "GlobalCodes", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Name).HasMaxLength(64).IsRequired();
                b.Property(x => x.Description).HasMaxLength(256);
            })
            .Entity<GlobalCodeVersion>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "GlobalCodeVersions", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();
            })
            .Entity<GlobalCodeContent>(b =>
            {
                b.ToTable(ElsaModuleDbProperties.DbTablePrefix + "GlobalCodeContents", ElsaModuleDbProperties.DbSchema);
                b.ConfigureByConvention();
            });
    }
}
