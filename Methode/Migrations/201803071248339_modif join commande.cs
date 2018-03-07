namespace Methode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifjoincommande : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LigneCommandes", name: "RefCommande", newName: "Commande_Id");
            RenameIndex(table: "dbo.LigneCommandes", name: "IX_RefCommande", newName: "IX_Commande_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.LigneCommandes", name: "IX_Commande_Id", newName: "IX_RefCommande");
            RenameColumn(table: "dbo.LigneCommandes", name: "Commande_Id", newName: "RefCommande");
        }
    }
}
