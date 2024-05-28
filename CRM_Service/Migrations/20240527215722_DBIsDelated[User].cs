using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Service.Migrations
{
    /// <inheritdoc />
    public partial class DBIsDelatedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelated",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelated",
                table: "User");
        }
    }
}
