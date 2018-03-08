using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Composants;
using Contrat;

namespace Methode
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class TransfertService : Contrat.IDataContract
    {

        private string reponseStr;

        public string insertDatePrev(string id_commande, string date)
        {
            Console.WriteLine("Transfert.insertDatePrev(" + id_commande + ", " + date + ")");
            return date;
        }

        public STC_MSG GetMessage(string xml)
        {
            //EndpointAddress ep;
            //Contrat.IDataContract proxy;
            //string uri;

            Console.WriteLine("Transfert.GetMessage()");
            //if (message.OpName == "sendBC")
            //{
            //    message = new Controller().getResult(message);
            //}

            //string xml = Parser.ToXML(message);



            //uri = "http://localhost:8733/Bolywood/Mex";
            //ep = new EndpointAddress(uri);

            //proxy = ChannelFactory<Contrat.IDataContract>.CreateChannel(new BasicHttpBinding(), ep);

            //proxy.getData(message);

            Console.WriteLine("Message reçu " + xml);

            //reponseStr = proxy.getData(xml);

            //Console.WriteLine("Message envoyé " + reponseStr);
            //Console.WriteLine(reponse);

            STC_MSG reponse = Parser.FromXml<STC_MSG>(xml);
            Console.WriteLine("message traité " + reponse.AppName);

            return reponse;

            //return new STC_MSG();
        }
       
    }
}
