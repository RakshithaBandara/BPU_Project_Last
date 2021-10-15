namespace BPU_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'07e97691-c4d9-4c15-8939-c7904297ea78', N'user', 0, N'AFicG2KCnqwtKHFaPQP3F9GU3tCASNwab7DL0JySBPuL3sL5zfa27gGyNLfdEeocLQ==', N'a73ca937-b97c-439c-ae7e-babbdd5406ae', NULL, 0, 0, NULL, 1, 0, N'user')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'49778b85-0eab-4eab-a0fc-25477bfe78ea', N'admin', 0, N'AGe/rkOUnZMd9plvYSMAwSiACbCC5AJqbY9iEOi5y5ou/9Z13e9YkEr0ij82CZIH3g==', N'6bf17faa-f78a-470c-a734-26a534d17ae2', NULL, 0, 0, NULL, 1, 0, N'admin')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6d81316d-0e7e-49cc-8570-c4c3b7b1f177', N'CanManageSalesorders')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'49778b85-0eab-4eab-a0fc-25477bfe78ea', N'6d81316d-0e7e-49cc-8570-c4c3b7b1f177')


");
        }
        
        public override void Down()
        {
        }
    }
}
