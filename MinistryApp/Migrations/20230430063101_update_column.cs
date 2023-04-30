using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.Migrations
{
    public partial class update_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Upzila",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Thana",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Division",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "District",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictsVMId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionsVMId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnionsVMId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpazilasVMId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DistrictsVMId",
                table: "AspNetUsers",
                column: "DistrictsVMId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DivisionsVMId",
                table: "AspNetUsers",
                column: "DivisionsVMId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UnionsVMId",
                table: "AspNetUsers",
                column: "UnionsVMId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UpazilasVMId",
                table: "AspNetUsers",
                column: "UpazilasVMId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DistrictsList_DistrictsVMId",
                table: "AspNetUsers",
                column: "DistrictsVMId",
                principalTable: "DistrictsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DivisionsList_DivisionsVMId",
                table: "AspNetUsers",
                column: "DivisionsVMId",
                principalTable: "DivisionsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UnionsList_UnionsVMId",
                table: "AspNetUsers",
                column: "UnionsVMId",
                principalTable: "UnionsList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UpazilasList_UpazilasVMId",
                table: "AspNetUsers",
                column: "UpazilasVMId",
                principalTable: "UpazilasList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DistrictsList_DistrictsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DivisionsList_DivisionsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UnionsList_UnionsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UpazilasList_UpazilasVMId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DistrictsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DivisionsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UnionsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UpazilasVMId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DistrictsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DivisionsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UnionsVMId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpazilasVMId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Upzila",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Thana",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Division",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
