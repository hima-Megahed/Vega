using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabaseManufacturerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('ALFA ROMEO')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('AUDI')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('BMW')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('JEEP')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('CITROEN')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('FIAT')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('FORD')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('HONDA')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('HYUNDAI')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('KIA')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('MAZDA')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('MITSUBISHI')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('NISSAN')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('PEUGEOT')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('RENAULT')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('SEAT UK')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('SKODA')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('SUZUKI')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('TOYOTA')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('Volkswagen')");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Manufacturers] ([Name]) VALUES('VOLVO')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Manufacturers");
        }
    }
}
