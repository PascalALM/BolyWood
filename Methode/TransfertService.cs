using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Composants;
using Contrat;

namespace Methode
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class TransfertService : Contrat.IDataContract
    {
        
        public void insertDatePrev(string id_commande, string date)
        {
            Console.WriteLine("Transfert.insertDatePrev(" + id_commande + ", " + date + ")");


            try
            {
                Commande commande = CommandeDAO.getCommande(int.Parse(id_commande));

                if(commande != null)
                {
                    DateTime datePrev = DateTime.ParseExact(date, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    
                    commande.DateEdition = DateTime.Now;
                    commande.DatePrevision = datePrev;
                    
                    commande = CommandeDAO.updateObject(commande);
                    Console.WriteLine("Date de prévision affectée à la commande " + id_commande);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur dans la requête : " + ex);
                WebOperationContext ctx = WebOperationContext.Current;
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return;
        }

        //public STC_MSG GetMessage(string xml)
        //{
        //    //EndpointAddress ep;
        //    //Contrat.IDataContract proxy;
        //    //string uri;

        //    Console.WriteLine("Transfert.GetMessage()");
        //    //if (message.OpName == "sendBC")
        //    //{
        //    //    message = new Controller().getResult(message);
        //    //}

        //    //string xml = Parser.ToXML(message);



        //    //uri = "http://localhost:8733/Bolywood/Mex";
        //    //ep = new EndpointAddress(uri);

        //    //proxy = ChannelFactory<Contrat.IDataContract>.CreateChannel(new BasicHttpBinding(), ep);

        //    //proxy.getData(message);

        //    Console.WriteLine("Message reçu " + xml);

        //    //reponseStr = proxy.getData(xml);

        //    //Console.WriteLine("Message envoyé " + reponseStr);
        //    //Console.WriteLine(reponse);

        //    //STC_MSG reponse = Parser.FromXml<STC_MSG>(xml);
        //    //Console.WriteLine("message traité " + reponse.AppName);

        //    return reponse;

        //    //return new STC_MSG();
        //}
       
    }
}
