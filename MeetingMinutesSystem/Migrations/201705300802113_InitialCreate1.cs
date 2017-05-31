namespace MeetingMinutesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MinutesModel", "Content", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.MinutesModel", "ResponsibleMember", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MinutesModel", "ResponsibleMember", c => c.String());
            AlterColumn("dbo.MinutesModel", "Content", c => c.String());
        }
    }
}
