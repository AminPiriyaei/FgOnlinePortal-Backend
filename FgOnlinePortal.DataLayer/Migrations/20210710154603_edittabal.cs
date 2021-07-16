using Microsoft.EntityFrameworkCore.Migrations;

namespace FgOnlinePortal.DataLayer.Migrations
{
    public partial class edittabal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Tell",
                table: "PaymentGateways",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "BankAccount",
                table: "PaymentGateways",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Tell",
                table: "PaymentGateways",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "BankAccount",
                table: "PaymentGateways",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
