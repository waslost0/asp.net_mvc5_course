using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class PopulateNameMembershipTypesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name='Pay as You Go' WHERE Id=1");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name='Month' WHERE Id=2");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name='3 Months' WHERE Id=3");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name='Year' WHERE Id=4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
