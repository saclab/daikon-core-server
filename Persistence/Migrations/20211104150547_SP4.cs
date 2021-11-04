using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations
{
    public partial class SP4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppOrgs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Alias = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityName = table.Column<string>(type: "text", nullable: true),
                    PropertyName = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    PrimaryKeyValue = table.Column<string>(type: "text", nullable: true),
                    OldValue = table.Column<string>(type: "text", nullable: true),
                    NewValue = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SaccId = table.Column<string>(type: "text", nullable: true),
                    Smile = table.Column<string>(type: "text", nullable: true),
                    MolWeight = table.Column<string>(type: "text", nullable: true),
                    MolArea = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    Section = table.Column<string>(type: "text", nullable: true),
                    Topic = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PostedBy = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Mentions = table.Column<string>(type: "text", nullable: true),
                    Tags = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessionNumber = table.Column<string>(type: "text", nullable: true),
                    GeneName = table.Column<string>(type: "text", nullable: true),
                    Function = table.Column<string>(type: "text", nullable: true),
                    Product = table.Column<string>(type: "text", nullable: true),
                    FunctionalCategory = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identification = table.Column<string>(type: "text", nullable: true),
                    Module = table.Column<string>(type: "text", nullable: true),
                    SubModule = table.Column<string>(type: "text", nullable: true),
                    QuestionBody = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ToolTip = table.Column<string>(type: "text", nullable: true),
                    PossibleAnswers = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    OrgId = table.Column<Guid>(type: "uuid", nullable: true),
                    Lock = table.Column<bool>(type: "boolean", nullable: false),
                    Archived = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AppOrgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "AppOrgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscussionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: true),
                    PostedBy = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Mentions = table.Column<string>(type: "text", nullable: true),
                    Tags = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Discussions_DiscussionId",
                        column: x => x.DiscussionId,
                        principalTable: "Discussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneEssentiality",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    EssentialityCondition = table.Column<string>(type: "text", nullable: true),
                    Strain = table.Column<string>(type: "text", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneEssentiality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneEssentiality_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneNonPublicData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    ProteinProduction = table.Column<string>(type: "text", nullable: true),
                    ProteinActivityAssay = table.Column<string>(type: "text", nullable: true),
                    KnockdownStrain = table.Column<string>(type: "text", nullable: true),
                    Phenotype = table.Column<string>(type: "text", nullable: true),
                    CRISPRiStrain = table.Column<string>(type: "text", nullable: true),
                    Mutation = table.Column<string>(type: "text", nullable: true),
                    Isolate = table.Column<string>(type: "text", nullable: true),
                    ParentStrain = table.Column<string>(type: "text", nullable: true),
                    CompoundSmiles = table.Column<string>(type: "text", nullable: true),
                    ShiftInMIC = table.Column<string>(type: "text", nullable: true),
                    Lab = table.Column<string>(type: "text", nullable: true),
                    Organization = table.Column<string>(type: "text", nullable: true),
                    UnpublishedMethod = table.Column<string>(type: "text", nullable: true),
                    Resolution = table.Column<string>(type: "text", nullable: true),
                    UnpublishedCondition = table.Column<string>(type: "text", nullable: true),
                    Ligand = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneNonPublicData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneNonPublicData_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenePromotionRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    GenePromotionRequestStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenePromotionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenePromotionRequests_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenePublicData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Proteomics = table.Column<string>(type: "text", nullable: true),
                    Mutant = table.Column<string>(type: "text", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Start = table.Column<string>(type: "text", nullable: true),
                    End = table.Column<string>(type: "text", nullable: true),
                    Orientation = table.Column<string>(type: "text", nullable: true),
                    GeneLength = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    GeneSequence = table.Column<string>(type: "text", nullable: true),
                    MolecularMass = table.Column<string>(type: "text", nullable: true),
                    IsoelectricPoint = table.Column<string>(type: "text", nullable: true),
                    ProteinLength = table.Column<string>(type: "text", nullable: true),
                    ProteinSequence = table.Column<string>(type: "text", nullable: true),
                    PFAM = table.Column<string>(type: "text", nullable: true),
                    M_Leprae = table.Column<string>(type: "text", nullable: true),
                    M_Marinum = table.Column<string>(type: "text", nullable: true),
                    M_Smegmatis = table.Column<string>(type: "text", nullable: true),
                    Cryo = table.Column<string>(type: "text", nullable: true),
                    XRay = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Ligand = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenePublicData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenePublicData_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneVulnerability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    Rank = table.Column<string>(type: "text", nullable: true),
                    UVi = table.Column<string>(type: "text", nullable: true),
                    IVi = table.Column<string>(type: "text", nullable: true),
                    ViRatio = table.Column<string>(type: "text", nullable: true),
                    VulnerabilityCondition = table.Column<string>(type: "text", nullable: true),
                    Operon = table.Column<string>(type: "text", nullable: true),
                    Confounded = table.Column<string>(type: "text", nullable: true),
                    Shell2015Operon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneVulnerability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneVulnerability_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessionNumber = table.Column<string>(type: "text", nullable: true),
                    GeneName = table.Column<string>(type: "text", nullable: true),
                    Bucket = table.Column<string>(type: "text", nullable: true),
                    ImpactScore = table.Column<double>(type: "double precision", nullable: false),
                    ImpactComplete = table.Column<double>(type: "double precision", nullable: false),
                    LikeScore = table.Column<double>(type: "double precision", nullable: false),
                    LikeComplete = table.Column<double>(type: "double precision", nullable: false),
                    ScreeningScore = table.Column<double>(type: "double precision", nullable: false),
                    ScreeningComplete = table.Column<double>(type: "double precision", nullable: false),
                    StructureScore = table.Column<double>(type: "double precision", nullable: false),
                    StructureComplete = table.Column<double>(type: "double precision", nullable: false),
                    VulnerabilityRatio = table.Column<double>(type: "double precision", nullable: false),
                    VulnerabilityRank = table.Column<double>(type: "double precision", nullable: false),
                    HTSFeasibility = table.Column<double>(type: "double precision", nullable: false),
                    SBDFeasibility = table.Column<double>(type: "double precision", nullable: false),
                    Progressibility = table.Column<double>(type: "double precision", nullable: false),
                    Safety = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Targets_Genes_GeneId",
                        column: x => x.GeneId,
                        principalTable: "Genes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenePromotionRequestValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenePromotionRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AnswerdBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenePromotionRequestValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenePromotionRequestValues_GenePromotionRequests_GenePromot~",
                        column: x => x.GenePromotionRequestId,
                        principalTable: "GenePromotionRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenePromotionRequestValues_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScreenName = table.Column<string>(type: "text", nullable: true),
                    AccessionNumber = table.Column<string>(type: "text", nullable: true),
                    GeneName = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    OrgId = table.Column<Guid>(type: "uuid", nullable: false),
                    PromotionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Promoter = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screens_AppOrgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "AppOrgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screens_Targets_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetScorecards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetID = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetAccessionNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetScorecards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetScorecards_Targets_TargetID",
                        column: x => x.TargetID,
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScreenId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessionNumber = table.Column<string>(type: "text", nullable: true),
                    Library = table.Column<string>(type: "text", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: true),
                    MIC = table.Column<string>(type: "text", nullable: true),
                    IC50 = table.Column<string>(type: "text", nullable: true),
                    ClusterGroup = table.Column<int>(type: "integer", nullable: false),
                    CompoundId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hits_Compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "Compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hits_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenSequences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScreenId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessionNumber = table.Column<string>(type: "text", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: true),
                    Protocol = table.Column<string>(type: "text", nullable: true),
                    Library = table.Column<string>(type: "text", nullable: true),
                    Scientist = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UnverifiedHitCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenSequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScreenSequences_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetScoreCardValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetScorecardId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetAccessionNumber = table.Column<string>(type: "text", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionIdentification = table.Column<string>(type: "text", nullable: true),
                    QuestionModule = table.Column<string>(type: "text", nullable: true),
                    QuestionSubModule = table.Column<string>(type: "text", nullable: true),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AnswerdBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetScoreCardValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetScoreCardValues_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TargetScoreCardValues_TargetScorecards_TargetScorecardId",
                        column: x => x.TargetScorecardId,
                        principalTable: "TargetScorecards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrgId",
                table: "AspNetUsers",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneEssentiality_GeneId",
                table: "GeneEssentiality",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneNonPublicData_GeneId",
                table: "GeneNonPublicData",
                column: "GeneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequests_GeneId",
                table: "GenePromotionRequests",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequestValues_GenePromotionRequestId",
                table: "GenePromotionRequestValues",
                column: "GenePromotionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_GenePromotionRequestValues_QuestionId",
                table: "GenePromotionRequestValues",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_GenePublicData_GeneId",
                table: "GenePublicData",
                column: "GeneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneVulnerability_GeneId",
                table: "GeneVulnerability",
                column: "GeneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hits_CompoundId",
                table: "Hits",
                column: "CompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Hits_ScreenId",
                table: "Hits",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_DiscussionId",
                table: "Replies",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_OrgId",
                table: "Screens",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_TargetId",
                table: "Screens",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenSequences_ScreenId",
                table: "ScreenSequences",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_GeneId",
                table: "Targets",
                column: "GeneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TargetScorecards_TargetID",
                table: "TargetScorecards",
                column: "TargetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TargetScoreCardValues_QuestionId",
                table: "TargetScoreCardValues",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetScoreCardValues_TargetScorecardId",
                table: "TargetScoreCardValues",
                column: "TargetScorecardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BTask");

            migrationBuilder.DropTable(
                name: "ChangeLogs");

            migrationBuilder.DropTable(
                name: "GeneEssentiality");

            migrationBuilder.DropTable(
                name: "GeneNonPublicData");

            migrationBuilder.DropTable(
                name: "GenePromotionRequestValues");

            migrationBuilder.DropTable(
                name: "GenePublicData");

            migrationBuilder.DropTable(
                name: "GeneVulnerability");

            migrationBuilder.DropTable(
                name: "Hits");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "ScreenSequences");

            migrationBuilder.DropTable(
                name: "TargetScoreCardValues");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GenePromotionRequests");

            migrationBuilder.DropTable(
                name: "Compounds");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "TargetScorecards");

            migrationBuilder.DropTable(
                name: "AppOrgs");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "Genes");
        }
    }
}
