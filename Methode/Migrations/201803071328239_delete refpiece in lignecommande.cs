namespace Methode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleterefpieceinlignecommande : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LigneCommandes", name: "RefPiece", newName: "Piece_Id");
            RenameIndex(table: "dbo.LigneCommandes", name: "IX_RefPiece", newName: "IX_Piece_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.LigneCommandes", name: "IX_Piece_Id", newName: "IX_RefPiece");
            RenameColumn(table: "dbo.LigneCommandes", name: "Piece_Id", newName: "RefPiece");
        }
    }
}
