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
                        Nom = c.String(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        DateEdition = c.DateTime(),
                        DatePrevision = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LigneCommandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefPiece = c.Int(nullable: false),
                        Quantite = c.Single(nullable: false),
                        Unite = c.String(),
                        Commande_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commandes", t => t.Commande_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pieces", t => t.RefPiece, cascadeDelete: true)
                .Index(t => t.RefPiece)
                .Index(t => t.Commande_Id);
            
            CreateTable(
                "dbo.Pieces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        PrixUnitaire = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LigneCommandes", "RefPiece", "dbo.Pieces");
            DropForeignKey("dbo.LigneCommandes", "Commande_Id", "dbo.Commandes");
            DropIndex("dbo.LigneCommandes", new[] { "Commande_Id" });
            DropIndex("dbo.LigneCommandes", new[] { "RefPiece" });
            DropTable("dbo.Pieces");
            DropTable("dbo.LigneCommandes");
            DropTable("dbo.Commandes");
        }
    }
}
