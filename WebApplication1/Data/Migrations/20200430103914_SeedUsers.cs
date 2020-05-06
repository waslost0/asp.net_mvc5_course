using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0f0e6284-a3a8-40d2-86d4-1c6331fd46c5', N'admin3@mail.com', N'ADMIN3@MAIL.COM', N'admin3@mail.com', N'ADMIN3@MAIL.COM', 1, N'AQAAAAEAACcQAAAAEIFTHSF0aie6AZC/EZrCSZVYGVy9TJEEi564UZrjj2pTvBcQZUewSUkWcX/tT9Lsvw==', N'RX4KGAZCEAN34WFZNKB2PWYRNB7R6VDY', N'a27d78f1-0897-4d04-96a7-23dfaa227e8d', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f0c356c3-20a8-4b3d-97cd-00006c262f8d', N'test1@mail.com', N'TEST1@MAIL.COM', N'test1@mail.com', N'TEST1@MAIL.COM', 1, N'AQAAAAEAACcQAAAAEBVhykpQjryW1QAR21JVJaXa7stlT99S6Ibsm/44qQGHtS2IIOEG2aTAc6ACGF/ItA==', N'HJLO5EABLS775G6DKBJJNHQ6I4EXNH3Y', N'e4993aa2-6e54-40e6-aeb3-3a2a92903cea', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Admin', N'Administrator', NULL)
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0f0e6284-a3a8-40d2-86d4-1c6331fd46c5', N'1')

");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
