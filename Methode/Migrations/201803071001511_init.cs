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
                        RefCommande = c.Int(nullable: false),
                        RefPiece = c.Int(nullable: false),
                        Quantite = c.Single(nullable: false),
                        Unite = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commandes", t => t.RefCommande, cascadeDelete: true)
                .ForeignKey("dbo.Pieces", t => t.RefPiece, cascadeDelete: true)
                .Index(t => t.RefCommande)
                .Index(t => t.RefPiece);
            
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
            DropForeignKey("dbo.LigneCommandes", "RefCommande", "dbo.Commandes");
            DropIndex("dbo.LigneCommandes", new[] { "RefPiece" });
            DropIndex("dbo.LigneCommandes", new[] { "RefCommande" });
            DropTable("dbo.Pieces");
            DropTable("dbo.LigneCommandes");
            DropTable("dbo.Commandes");
        }
    }
}
