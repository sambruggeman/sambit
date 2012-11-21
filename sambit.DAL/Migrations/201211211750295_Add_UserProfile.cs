namespace sambit.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 4000),
                        Text = c.String(nullable: false, maxLength: 4000),
                        Username = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Posts");
        }
    }
}
