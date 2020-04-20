using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class AddDataToMoviesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Avengers: Endgame', 1, '2019-04-30', '2019-04-25', 5)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Gisaengchung', 5, '2019-05-15', '2019-05-01', 2)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Onward', 3, '2020-04-20', '2019-04-15', 3)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('The Invisible Man', 2, '2019-02-26', '2019-02-27', 10)");
            migrationBuilder.Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Joker', 1, '2019-08-10', '2019-08-15', 8)");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
