using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Makes\" (\"Name\") VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO \"Makes\" (\"Name\") VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO \"Makes\" (\"Name\") VALUES ('Make3')");

            // Postgres statements to get ID (as opposed to a sub-SELECT in each INSERT below):
            //with tempIndex as (select objectid from public.guiautojdecatalog where name = 'RIO')
            //select * from public.guiautojdecatalog where objectid = (select objectid from tempIndex)
            // or
            //select objectid into noid from public.guiautojdecatalog where name = 'RIO'
            //select * from public.guiautojdecatalog where objectid = (select objectid from noid)

            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make1-ModelA', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make1-ModelB', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make1-ModelC', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make1'))");

            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make2-ModelA', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make2-ModelB', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make2-ModelC', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make2'))");

            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make3-ModelA', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make3-ModelB', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO \"Models\" (\"Name\", \"MakeId\") VALUES ('Make3-ModelC', (SELECT \"Id\" FROM \"Makes\" WHERE \"Name\" = 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Makes\" WHERE \"Name\" IN ('Make1', 'Make2', 'Make3')");
            // Deleting the Makes table will also remove the Models table
            // migrationBuilder.Sql("DELETE FROM Models");
        }
    }
}
