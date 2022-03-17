using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XandaDeck.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Subscription = table.Column<int>(type: "int", nullable: false),
                    DeviceQuota = table.Column<int>(type: "int", nullable: false),
                    Devices = table.Column<int>(type: "int", nullable: false),
                    RegisteredDevices = table.Column<int>(type: "int", nullable: false),
                    OnlineDevices = table.Column<int>(type: "int", nullable: false),
                    DeviceOfflineNotice = table.Column<bool>(type: "bit", nullable: false),
                    DeviceOnlineNotice = table.Column<bool>(type: "bit", nullable: false),
                    NewLocationLoginNotice = table.Column<bool>(type: "bit", nullable: false),
                    Use2FA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    IsStaff = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Online = table.Column<bool>(type: "bit", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AccounId = table.Column<int>(type: "int", nullable: true),
                    LastLogin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    AuditLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Site = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.AuditLogId);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Layouts",
                columns: table => new
                {
                    LayoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LayoutStyle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layouts", x => x.LayoutId);
                    table.ForeignKey(
                        name: "FK_Layouts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PlayFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Always = table.Column<bool>(type: "bit", nullable: false),
                    PlayUntil = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Forever = table.Column<bool>(type: "bit", nullable: false),
                    RotateVideo = table.Column<bool>(type: "bit", nullable: false),
                    RotateBy = table.Column<int>(type: "int", nullable: false),
                    CropVideo = table.Column<bool>(type: "bit", nullable: false),
                    Top = table.Column<double>(type: "float", nullable: false),
                    Bottom = table.Column<double>(type: "float", nullable: false),
                    Left = table.Column<double>(type: "float", nullable: false),
                    Right = table.Column<double>(type: "float", nullable: false),
                    EnableSubtitles = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebPages",
                columns: table => new
                {
                    WebPageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Always = table.Column<bool>(type: "bit", nullable: false),
                    PlayUntil = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Forever = table.Column<bool>(type: "bit", nullable: false),
                    ZoomFactor = table.Column<double>(type: "float", nullable: false),
                    AutoZoom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebPages", x => x.WebPageId);
                    table.ForeignKey(
                        name: "FK_WebPages_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagsTagId = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    UploadedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PlayFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Always = table.Column<bool>(type: "bit", nullable: false),
                    PlayUntil = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Forever = table.Column<bool>(type: "bit", nullable: false),
                    PreviewPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Tag_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Online = table.Column<bool>(type: "bit", nullable: false),
                    LastOnline = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Registered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ScreenShotURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    EnableWiFi = table.Column<bool>(type: "bit", nullable: false),
                    WiFiNetworkName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    WiFiMode = table.Column<int>(type: "int", nullable: false),
                    WiFiKey = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    WiFiUsername = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    WiFiPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NetworkHidden = table.Column<bool>(type: "bit", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    UseDongle = table.Column<bool>(type: "bit", nullable: false),
                    SIMPin = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    APN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DongleUsername = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DonglePassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AdvancedConfig = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EnableProxy = table.Column<bool>(type: "bit", nullable: false),
                    WiFiStaticConfig = table.Column<bool>(type: "bit", nullable: false),
                    WiFiIPAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WiFiNetmask = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WiFiGateway = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WiFiDNS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WiFiSecondaryDNS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LANStaticConfig = table.Column<bool>(type: "bit", nullable: false),
                    LANIPAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LANNetmask = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LANGateway = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LANDNS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LANSecondaryDNS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    GoogleDNS = table.Column<bool>(type: "bit", nullable: false),
                    NTPServers = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Devices_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    ScheduleItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<int>(type: "int", nullable: false),
                    FirstStart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FirstStop = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: true),
                    Tuesday = table.Column<bool>(type: "bit", nullable: true),
                    Wednesday = table.Column<bool>(type: "bit", nullable: true),
                    Thursday = table.Column<bool>(type: "bit", nullable: true),
                    Friday = table.Column<bool>(type: "bit", nullable: true),
                    Saturday = table.Column<bool>(type: "bit", nullable: true),
                    Sunday = table.Column<bool>(type: "bit", nullable: true),
                    RepeatUnitl = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Forever = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.ScheduleItemId);
                    table.ForeignKey(
                        name: "FK_ScheduleItems_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
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
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_AccountId",
                table: "AuditLogs",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_AccountId",
                table: "Devices",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ScheduleId",
                table: "Devices",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AccountId",
                table: "Images",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_TagsTagId",
                table: "Images",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Layouts_AccountId",
                table: "Layouts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_ScheduleId",
                table: "ScheduleItems",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AccountId",
                table: "Schedules",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_AccountId",
                table: "Videos",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_WebPages_AccountId",
                table: "WebPages",
                column: "AccountId");
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
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Layouts");

            migrationBuilder.DropTable(
                name: "ScheduleItems");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "WebPages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
