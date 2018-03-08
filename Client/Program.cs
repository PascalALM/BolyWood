using Composants;
using Contrat;
using Methode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializeDb();

            //List<Piece> pieces = CommandeDAO.getPieces();

            //Console.WriteLine("get commande 1");
            //Commande commande1 = CommandeDAO.getCommande(10);
            //Console.WriteLine(commande1);

            //Console.WriteLine("test lignescommande");
            //foreach (LigneCommande l in commande1.LignesCommande)
            //{
            //    Console.WriteLine(l);
            //    Console.WriteLine(l.Piece.Nom);
            //}


            STC_MSG msg = new STC_MSG();
            msg.AppName = "BolyWood Motherfucker";
            msg.AppVrs = "1000.0";
            msg.OpName = "sendBC";
            msg.OpStatut = false;

            msg.MsgInfo = "test";

            //msg.Data = new object[2];

            string xml = Parser.ToXML(msg);
            Console.WriteLine("xml parsé" + xml);
            Console.WriteLine("json parsé" + JsonConvert.SerializeObject(msg));
            using (WebServiceHost host = new WebServiceHost(
                typeof(TransfertService), 
                new Uri("http://localhost:8733/Bolywood/Service")
            ))
            {
                try
                {
                    ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IDataContract), new WebHttpBinding(), "");
                    host.Open();

                    Console.WriteLine("The service is ready");

                    //using (ChannelFactory<IDataContract> cf = new ChannelFactory<IDataContract>(new WebHttpBinding(), "http://localhost:8733/Bolywood/Service"))
                    //{
                    //    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                    //    IDataContract channel = cf.CreateChannel();

                    //    Console.WriteLine("Calling GetMessage via HTTP POST: ");
                    //    channel.GetMessage(xml);

                    //}

                        //Task.Run(() =>
                        //{
                        //    Thread.Sleep(5000);

                        //    TransfertService Client = new TransfertService();

                        //    string xml = Parser.ToXML(msg);
                        //    Console.WriteLine(xml);
                        //    STC_MSG reponse = Client.GetMessage(xml);
                        //});

                        //Console.WriteLine("Press <Enter> to stop the service.");
                        Console.Read();

                    // Close the ServiceHost.
                    //host.Close();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    host.Abort();
                }

            }


            //TransfertService Client = new TransfertService();

            //STC_MSG reponse = Client.getData(msg);

            //Console.Read();


        }

        private static void initializeDb()
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
