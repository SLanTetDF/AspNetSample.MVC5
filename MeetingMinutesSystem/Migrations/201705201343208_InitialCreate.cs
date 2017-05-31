namespace MeetingMinutesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MinutesModel",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Content = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        ResponsibleMember = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MinutesModel");
        }
    }
}
