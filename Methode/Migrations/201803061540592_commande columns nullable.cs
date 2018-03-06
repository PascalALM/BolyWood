namespace Methode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commandecolumnsnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Commandes", "DateEdition", c => c.DateTime());
            AlterColumn("dbo.Commandes", "DatePrevision", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Commandes", "DatePrevision", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Commandes", "DateEdition", c => c.DateTime(nullable: false));
        }
    }
}
