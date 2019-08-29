using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabaseModelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Giulietta', (select Id from Manufacturers where Name = 'ALFA ROMEO'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Giulia', (select Id from Manufacturers where Name = 'ALFA ROMEO'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('A1', (select Id from Manufacturers where Name = 'AUDI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('A3', (select Id from Manufacturers where Name = 'AUDI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Q2', (select Id from Manufacturers where Name = 'AUDI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('i3', (select Id from Manufacturers where Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('2 Series', (select Id from Manufacturers where Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('X2', (select Id from Manufacturers where Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Renegade', (select Id from Manufacturers where Name = 'JEEP'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Compass', (select Id from Manufacturers where Name = 'JEEP'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('C1', (select Id from Manufacturers where Name = 'CITROEN'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('C3', (select Id from Manufacturers where Name = 'CITROEN'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('C3 Aircross', (select Id from Manufacturers where Name = 'CITROEN'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('C4 Cactus', (select Id from Manufacturers where Name = 'CITROEN'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('C4 SpaceTourer', (select Id from Manufacturers where Name = 'CITROEN'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Berlingo', (select Id from Manufacturers where Name = 'CITROEN'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('500C', (select Id from Manufacturers where Name = 'FIAT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('500L', (select Id from Manufacturers where Name = 'FIAT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Panda', (select Id from Manufacturers where Name = 'FIAT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Tipo', (select Id from Manufacturers where Name = 'FIAT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Ka+', (select Id from Manufacturers where Name = 'FORD'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Fiesta', (select Id from Manufacturers where Name = 'FORD'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Focus', (select Id from Manufacturers where Name = 'FORD'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Jazz', (select Id from Manufacturers where Name = 'HONDA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Civic', (select Id from Manufacturers where Name = 'HONDA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('CR-V', (select Id from Manufacturers where Name = 'HONDA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('i10', (select Id from Manufacturers where Name = 'HYUNDAI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Kona', (select Id from Manufacturers where Name = 'HYUNDAI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Tucson', (select Id from Manufacturers where Name = 'HYUNDAI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('IONIQ', (select Id from Manufacturers where Name = 'HYUNDAI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Rio', (select Id from Manufacturers where Name = 'KIA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Picanto', (select Id from Manufacturers where Name = 'KIA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Venga', (select Id from Manufacturers where Name = 'KIA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Optima', (select Id from Manufacturers where Name = 'KIA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('MX-5', (select Id from Manufacturers where Name = 'MAZDA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('CX-5', (select Id from Manufacturers where Name = 'MAZDA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Mazda6', (select Id from Manufacturers where Name = 'MAZDA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Mirage', (select Id from Manufacturers where Name = 'MITSUBISHI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('ASX', (select Id from Manufacturers where Name = 'MITSUBISHI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Eclipse Cross', (select Id from Manufacturers where Name = 'MITSUBISHI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Micra', (select Id from Manufacturers where Name = 'NISSAN'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Juke', (select Id from Manufacturers where Name = 'NISSAN'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('108', (select Id from Manufacturers where Name = 'PEUGEOT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Rifter', (select Id from Manufacturers where Name = 'PEUGEOT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('308 SW', (select Id from Manufacturers where Name = 'PEUGEOT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Captur', (select Id from Manufacturers where Name = 'RENAULT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Zoe', (select Id from Manufacturers where Name = 'RENAULT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Megane', (select Id from Manufacturers where Name = 'RENAULT'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Ateca', (select Id from Manufacturers where Name = 'SEAT UK'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Alhambra', (select Id from Manufacturers where Name = 'SEAT UK'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Tarraco', (select Id from Manufacturers where Name = 'SEAT UK'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Citigo', (select Id from Manufacturers where Name = 'SKODA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Fabia', (select Id from Manufacturers where Name = 'SKODA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Octavia', (select Id from Manufacturers where Name = 'SKODA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('S-Cross', (select Id from Manufacturers where Name = 'SUZUKI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Vitara', (select Id from Manufacturers where Name = 'SUZUKI'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Prius', (select Id from Manufacturers where Name = 'TOYOTA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Prius+', (select Id from Manufacturers where Name = 'TOYOTA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('PROACE Verso', (select Id from Manufacturers where Name = 'TOYOTA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('RAV4', (select Id from Manufacturers where Name = 'TOYOTA'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('T-ROC', (select Id from Manufacturers where Name = 'Volkswagen'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Sharan', (select Id from Manufacturers where Name = 'Volkswagen'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('Tiguan', (select Id from Manufacturers where Name = 'Volkswagen'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('V40', (select Id from Manufacturers where Name = 'VOLVO'))");
            migrationBuilder.Sql("INSERT INTO [Vega].[dbo].[Models] ([Name], [ManufacturerId]) VALUES ('XC40', (select Id from Manufacturers where Name = 'VOLVO'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Models");
        }
    }
}
