namespace Methode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateEdition = c.DateTime(nullable: false),
                        DatePrevision = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LigneCommandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefCommande = c.Int(nullable: false),
                        RefPiece = c.Int(nullable: false),
                        Quantite = c.Single(nullable: false),
                        Unite = c.String(),
                        Commande_Id = c.Int(),
                        Piece_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commandes", t => t.Commande_Id)
                .ForeignKey("dbo.Pieces", t => t.Piece_Id)
                .Index(t => t.Commande_Id)
                .Index(t => t.Piece_Id);
            
            CreateTable(
                "dbo.Pieces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        PrixUnitaire = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LigneCommandes", "Piece_Id", "dbo.Pieces");
            DropForeignKey("dbo.LigneCommandes", "Commande_Id", "dbo.Commandes");
            DropIndex("dbo.LigneCommandes", new[] { "Piece_Id" });
            DropIndex("dbo.LigneCommandes", new[] { "Commande_Id" });
            DropTable("dbo.Pieces");
            DropTable("dbo.LigneCommandes");
            DropTable("dbo.Commandes");
        }
    }
}
