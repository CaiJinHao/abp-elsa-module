﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations;

/// <inheritdoc />
public partial class Update_Abp_8 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowTeams",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowTeams",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowInstances",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowInstances",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowGroups",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowGroups",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowExecutionLogs",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowExecutionLogs",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowDefinitionVersions",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowDefinitionVersions",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowDefinitions",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowDefinitions",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaTriggers",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaTriggers",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaGlobalVariables",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaGlobalVariables",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaGlobalCodeVersions",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaGlobalCodeVersions",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaGlobalCodes",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaGlobalCodes",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaBookmarks",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaBookmarks",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AppApiKeys",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AppApiKeys",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpUsers",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpUsers",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpTenants",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpTenants",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpSecurityLogs",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpSecurityLogs",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpRoles",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpRoles",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpOrganizationUnits",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpOrganizationUnits",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "EntityId",
            table: "AbpEntityChanges",
            type: "nvarchar(128)",
            maxLength: 128,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(128)",
            oldMaxLength: 128);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpClaimTypes",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpClaimTypes",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpBackgroundJobs",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpBackgroundJobs",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpAuditLogs",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpAuditLogs",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40,
            oldNullable: true);

        migrationBuilder.CreateTable(
            name: "AbpSettingDefinitions",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                DefaultValue = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                IsVisibleToClients = table.Column<bool>(type: "bit", nullable: false),
                Providers = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                IsInherited = table.Column<bool>(type: "bit", nullable: false),
                IsEncrypted = table.Column<bool>(type: "bit", nullable: false),
                ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_AbpSettingDefinitions", x => x.Id));

        migrationBuilder.CreateIndex(
            name: "IX_AbpSettingDefinitions_Name",
            table: "AbpSettingDefinitions",
            column: "Name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AbpSettingDefinitions");

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowTeams",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowTeams",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowInstances",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowInstances",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowGroups",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowGroups",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowExecutionLogs",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowExecutionLogs",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowDefinitionVersions",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowDefinitionVersions",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaWorkflowDefinitions",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaWorkflowDefinitions",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaTriggers",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaTriggers",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaGlobalVariables",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaGlobalVariables",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaGlobalCodeVersions",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaGlobalCodeVersions",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaGlobalCodes",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaGlobalCodes",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "ElsaBookmarks",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "ElsaBookmarks",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AppApiKeys",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AppApiKeys",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpUsers",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpUsers",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpTenants",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpTenants",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpSecurityLogs",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpSecurityLogs",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpRoles",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpRoles",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpOrganizationUnits",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpOrganizationUnits",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "EntityId",
            table: "AbpEntityChanges",
            type: "nvarchar(128)",
            maxLength: 128,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(128)",
            oldMaxLength: 128,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpClaimTypes",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpClaimTypes",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpBackgroundJobs",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpBackgroundJobs",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);

        migrationBuilder.AlterColumn<string>(
            name: "ExtraProperties",
            table: "AbpAuditLogs",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ConcurrencyStamp",
            table: "AbpAuditLogs",
            type: "nvarchar(40)",
            maxLength: 40,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(40)",
            oldMaxLength: 40);
    }
}
