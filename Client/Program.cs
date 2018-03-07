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


            //Piece piece1 = new Piece()
            //{
            //    Nom = "Planche",
            //    PrixUnitaire = 50.0
            //};
            //Piece piece2 = new Piece()
            //{
            //    Nom = "Ampoule",
            //    PrixUnitaire = 12.0
            //};
            //Commande commande = new Commande("Deuxième commande");

            using (var db = new CommandeContext())
            {

                //CommandeDAO.insertObject(ref piece1);
                //CommandeDAO.insertObject(ref piece2);
                //piece1 = CommandeDAO.insertObject(piece1);
                //piece2 = CommandeDAO.insertObject(piece2);
                //commande = CommandeDAO.insertObject(commande);

                List<Piece> pieces = CommandeDAO.getPieces();



                Console.WriteLine("get commande2");
                Commande commande2 = CommandeDAO.getCommande(2);
                Console.WriteLine(commande2);

                commande2.Nom = "Commande 2 modifiée";

                commande2 = CommandeDAO.updateObject(commande2);
                Console.WriteLine(commande2);

                //Console.WriteLine("getAllPiece");
                //LigneCommande ligneCommande;
                //foreach (Piece p in pieces)
                //{
                //    Console.WriteLine("Pièce : " + p.Nom + " " + p.PrixUnitaire);
                //    ligneCommande = new LigneCommande()
                //    {
                //        RefCommande = commande2.Id,
                //        RefPiece = p.Id,
                //        Quantite = 1000,
                //        Unite = "Lot"
                //    };
                //    //db.LignesCommande.Add(ligneCommande);
                //    //db.SaveChanges();
                //    CommandeDAO.persistObject(ref ligneCommande);
                //    Console.WriteLine("Ligne de la commande ajouté");
                //}

            }


            Console.Read();


        }
       
    
    }
}
