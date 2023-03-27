using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class metadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "GeneProteinProductions",
                newName: "LastEditAt");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "GeneProteinActivityAssays",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "Activity",
                table: "GeneProteinActivityAssays",
                newName: "Reference");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Votes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Votes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Votes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Voters",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Voters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Voters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Voters",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Voters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TargetScoreCardValues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TargetScoreCardValues",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "TargetScoreCardValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "TargetScoreCardValues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "TargetScoreCardValues",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "TargetScorecards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "TargetScorecards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "TargetScorecards",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Targets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Targets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Targets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TargetGenes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TargetGenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "TargetGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "TargetGenes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "TargetGenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Strains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Strains",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Strains",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcentrationUnit",
                table: "ScreenSequences",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "ScreenSequences",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "ScreenSequences",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "ScreenSequences",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Screens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Screens",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Replies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Replies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Replies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Replies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Replies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Questions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Questions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProjectSupportingOrgs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProjectSupportingOrgs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "ProjectSupportingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "ProjectSupportingOrgs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "ProjectSupportingOrgs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectLegacyId",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProjectParticipatingOrgs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProjectParticipatingOrgs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "ProjectParticipatingOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "ProjectParticipatingOrgs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "ProjectParticipatingOrgs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IC50Unit",
                table: "ProjectCompoundEvolutions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "ProjectCompoundEvolutions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "ProjectCompoundEvolutions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "ProjectCompoundEvolutions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MICUnit",
                table: "ProjectCompoundEvolutions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProjectBaseHits",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProjectBaseHits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "ProjectBaseHits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "ProjectBaseHits",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "ProjectBaseHits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IC50Unit",
                table: "Hits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Hits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Hits",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Hits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MICUnit",
                table: "Hits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Hits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneVulnerability",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneUnpublishedStructures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneUnpublishedStructures",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneUnpublishedStructures",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "GeneUnpublishedStructures",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResolutionUnit",
                table: "GeneUnpublishedStructures",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "GeneUnpublishedStructures",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Genes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Genes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Genes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Genes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Genes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneResistanceMutations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneResistanceMutations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneResistanceMutations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "GeneResistanceMutations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GenePublicData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GenePublicData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneLengthUnit",
                table: "GenePublicData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GenePublicData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsoelectricPointUnit",
                table: "GenePublicData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GenePublicData",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GenePublicData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MolecularMassUnit",
                table: "GenePublicData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProteinLengthUnit",
                table: "GenePublicData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneProteinProductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneProteinProductions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMID",
                table: "GeneProteinProductions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "GeneProteinProductions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Assay",
                table: "GeneProteinActivityAssays",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneProteinActivityAssays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneProteinActivityAssays",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneProteinActivityAssays",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "GeneProteinActivityAssays",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMID",
                table: "GeneProteinActivityAssays",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GenePromtionRequestGenes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GenePromtionRequestGenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GenePromtionRequestGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GenePromtionRequestGenes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GenePromtionRequestGenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GenePromotionRequestValues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GenePromotionRequestValues",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GenePromotionRequestValues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GenePromotionRequestValues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GenePromotionRequestValues",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GenePromotionRequests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GenePromotionRequests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GenePromotionRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GenePromotionRequests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GenePromotionRequests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneHypomorphs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneHypomorphs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneHypomorphs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GeneGroups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GeneGroups",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneGroups",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneGroups",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GeneGroupGenes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "GeneGroupGenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneGroupGenes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneGroupGenes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneGroupGenes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneExternalIds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneExternalIds",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneExternalIds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneEssentiality",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneEssentiality",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneEssentiality",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "GeneCRISPRiStrains",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "GeneCRISPRiStrains",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "GeneCRISPRiStrains",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Discussions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Discussions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Discussions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Discussions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Discussions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CASNumber",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CanonicalSmile",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommonName",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IUPACName",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InChI",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InChIKey",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Compounds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "Compounds",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MolAreaUnit",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MolFormula",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MolLogP",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MolVolume",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MolVolumeUnit",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MolWeightUnit",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PubChemRef",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Compounds",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AppVals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AppVals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "AppVals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "AppVals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "AppVals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AppOrgs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AppOrgs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "AppOrgs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditAt",
                table: "AppOrgs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastEditBy",
                table: "AppOrgs",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "TargetScoreCardValues");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "TargetScorecards");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Targets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "TargetGenes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "ConcentrationUnit",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "ScreenSequences");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "ProjectSupportingOrgs");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectLegacyId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "ProjectParticipatingOrgs");

            migrationBuilder.DropColumn(
                name: "IC50Unit",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "MICUnit",
                table: "ProjectCompoundEvolutions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "ProjectBaseHits");

            migrationBuilder.DropColumn(
                name: "IC50Unit",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "MICUnit",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneVulnerability");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "ResolutionUnit",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "GeneUnpublishedStructures");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Genes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "GeneResistanceMutations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "GeneLengthUnit",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsoelectricPointUnit",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "MolecularMassUnit",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "ProteinLengthUnit",
                table: "GenePublicData");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "PMID",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "GeneProteinProductions");

            migrationBuilder.DropColumn(
                name: "Assay",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "PMID",
                table: "GeneProteinActivityAssays");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GenePromtionRequestGenes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GenePromotionRequestValues");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GenePromotionRequests");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneHypomorphs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneGroups");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneGroupGenes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneExternalIds");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneEssentiality");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "GeneCRISPRiStrains");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "CASNumber",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "CanonicalSmile",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "CommonName",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IUPACName",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "InChI",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "InChIKey",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "MolAreaUnit",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "MolFormula",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "MolLogP",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "MolVolume",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "MolVolumeUnit",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "MolWeightUnit",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "PubChemRef",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Compounds");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "AppVals");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "LastEditAt",
                table: "AppOrgs");

            migrationBuilder.DropColumn(
                name: "LastEditBy",
                table: "AppOrgs");

            migrationBuilder.RenameColumn(
                name: "LastEditAt",
                table: "GeneProteinProductions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "GeneProteinActivityAssays",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "GeneProteinActivityAssays",
                newName: "Activity");
        }
    }
}
