using Composants;
using Methode;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    class Program
    {

        static void Main(string[] args)
        {
            //Transfert Client = new Transfert();

            //STC_MSG msg = new STC_MSG();
            //msg.AppName = "BolyWood Motherfucker";
            //msg.AppVrs = "1000.0";
            //msg.OpName = "sendBC";
            //msg.OpStatut = false;

            //msg.MsgInfo = "";
            //STC_MSG reponse = Client.getData(msg);

            //Console.WriteLine(reponse);
            Console.WriteLine("Test d'ajout en base de donnée");

            Piece piece1 = new Piece()
            {
                Nom = "Barre",
                PrixUnitaire = 20.0
            };
            Piece piece2 = new Piece()
            {
                Nom = "Vis",
                PrixUnitaire = 1.0
            };
            Commande commande = new Commande("Date");

            using (var db = new CommandeContext())
            {
                //db.Pieces.Add(piece1);
                //db.Pieces.Add(piece2);
                //db.Commandes.Add(commande);
                //db.SaveChanges();

                List<Commande> commandes = db.Commandes.ToList();
                //var commandes = from b in db.Commandes
                //            //where b.Name.StartsWith("B")
                //            select b;
                foreach (Commande c in commandes)
                {
                    Console.WriteLine(c);
                }
                //var query = (from r in db.Commandes select r);
                // Display all Blogs from the database 
                //var query = from b in db.Pieces
                //            orderby b.Nom
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Name);
                //}


            }
            //LigneCommande ligneCommande1 = new LigneCommande()
            //{
            //};
            //LigneCommande ligneCommande2 = new LigneCommande()
            //{
            //};

            Console.Read();


        }
       
    
    }
}
