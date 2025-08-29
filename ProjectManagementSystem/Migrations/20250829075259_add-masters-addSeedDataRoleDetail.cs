using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addmastersaddSeedDataRoleDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UserManagement");

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleModuleAccess",
                schema: "UserManagement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModuleAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModuleAccess_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "UserManagement",
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleModuleAccess_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Master",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "UserManagement",
                table: "Module",
                columns: new[] { "Id", "ActionName", "ControllerName", "CreatedBy", "CreatedDate", "DisplayOrder", "IconClass", "IsActive", "IsDeleted", "ModuleName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Index", "Roles", 1, new DateTime(2025, 8, 29, 0, 52, 58, 544, DateTimeKind.Local).AddTicks(9809), 1, "", true, false, "Master", null, null },
                    { 2, "Index", "Department", 1, new DateTime(2025, 8, 29, 0, 52, 58, 545, DateTimeKind.Local).AddTicks(1573), 2, "", true, false, "Master", null, null },
                    { 3, "Index", "Designation", 1, new DateTime(2025, 8, 29, 0, 52, 58, 545, DateTimeKind.Local).AddTicks(1588), 3, "", true, false, "Master", null, null },
                    { 4, "Index", "Status", 1, new DateTime(2025, 8, 29, 0, 52, 58, 545, DateTimeKind.Local).AddTicks(1592), 4, "", true, false, "Master", null, null },
                    { 5, "Index", "Priority", 1, new DateTime(2025, 8, 29, 0, 52, 58, 545, DateTimeKind.Local).AddTicks(1595), 5, "", true, false, "Master", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Master",
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "SA", 1, new DateTime(2025, 8, 29, 0, 52, 58, 537, DateTimeKind.Local).AddTicks(7104), true, false, "SuperAdmin", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_RoleModuleAccess_ModuleId",
                schema: "UserManagement",
                table: "RoleModuleAccess",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModuleAccess_RoleId",
                schema: "UserManagement",
                table: "RoleModuleAccess",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleModuleAccess",
                schema: "UserManagement");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "UserManagement");

            migrationBuilder.DeleteData(
                schema: "Master",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
