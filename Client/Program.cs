using Composants;
using Methode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Client
{
    class Program
    {

        private static ServiceHost host;
        static void Main(string[] args)
        {
            initializeDb();

            List<Piece> pieces = CommandeDAO.getPieces();

            Console.WriteLine("get commande 1");
            Commande commande1 = CommandeDAO.getCommande(1);
            Console.WriteLine(commande1);

            Console.WriteLine("test lignescommande");
            foreach (LigneCommande l in commande1.LignesCommande)
            {
                Console.WriteLine(l);
                Console.WriteLine(l.Piece.Nom);
            }

            Transfert Client = new Transfert();

            STC_MSG msg = new STC_MSG();
            msg.AppName = "BolyWood Motherfucker";
            msg.AppVrs = "1000.0";
            msg.OpName = "sendBC";
            msg.OpStatut = false;

            msg.MsgInfo = "";
            //STC_MSG reponse = Client.getData(msg);

            host = new ServiceHost(typeof(Transfert));
            //host.AddServiceEndpoint(typeof(iSvc), new BasicHttpBinding(), uri);
            host.Open();
            Console.WriteLine("Srv Up");
            //Console.Read();

            Console.Read();


        }

        private static void initializeDb()
        {
            using (var db = new CommandeContext())
            {
                Piece piece1 = new Piece()
                {
                    Nom = "Planche",
                    PrixUnitaire = 50.0
                };
                Piece piece2 = new Piece()
                {
                    Nom = "Ampoule",
                    PrixUnitaire = 12.0
                };
                Commande commande = new Commande("Première commande");
                Commande commande2 = new Commande("Deuxième commande");

                piece1 = CommandeDAO.insertObject(piece1);
                piece2 = CommandeDAO.insertObject(piece2);
                commande = CommandeDAO.insertObject(commande);
                commande2 = CommandeDAO.insertObject(commande);

                List<Piece> pieces = CommandeDAO.getPieces();

                Console.WriteLine("get commande 1");
                Commande commande1 = CommandeDAO.getCommande(1);
                Console.WriteLine(commande1);



                //commande1.Nom = "Commande 2 modifiée";

                //commande1 = CommandeDAO.updateObject(commande1);
                //Console.WriteLine(commande1);

                Console.WriteLine("getAllPiece");
                LigneCommande ligneCommande;
                foreach (Piece p in pieces)
                {
                    Console.WriteLine("Pièce : " + p.Nom + " " + p.PrixUnitaire);
                    ligneCommande = new LigneCommande()
                    {
                        Commande = commande1,
                        Piece = p,
                        Quantite = 1000,
                        Unite = "Lot"
                    };
                    //db.LignesCommande.Add(ligneCommande);
                    //db.SaveChanges();
                    ligneCommande = CommandeDAO.insertObject(ligneCommande);
                    Console.WriteLine("Ligne de la commande ajouté");
                }

            }
        }


    }
}
