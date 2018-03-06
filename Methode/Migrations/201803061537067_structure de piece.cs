namespace Methode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class structuredepiece : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pieces", "PrixUnitaire", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pieces", "PrixUnitaire", c => c.Single(nullable: false));
        }
    }
}
