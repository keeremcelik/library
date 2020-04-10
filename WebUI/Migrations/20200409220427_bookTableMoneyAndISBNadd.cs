using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Migrations
{
    public partial class bookTableMoneyAndISBNadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Books",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");
        }
    }
}
