using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillNet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDoubleRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Organizations_OrganizationId1",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_OrganizationId1",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "OrganizationId1",
                table: "Groups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId1",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_OrganizationId1",
                table: "Groups",
                column: "OrganizationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Organizations_OrganizationId1",
                table: "Groups",
                column: "OrganizationId1",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
