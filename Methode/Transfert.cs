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
    public class Transfert : Contrat.IDataContract
    {

        private STC_MSG reponse;
        public STC_MSG getData(STC_MSG message)
        {
            EndpointAddress ep;
            Contrat.IDataContract proxy;
            string uri;

            Console.WriteLine("Transfert.getData() Succès");
            //if (message.OpName == "sendBC")
            //{
            //    message = new Controller().getResult(message);
            //}



            uri = "http://localhost:8010/Commande/Prevision";
            ep = new EndpointAddress(uri);

            proxy = ChannelFactory<Contrat.IDataContract>.CreateChannel(new BasicHttpBinding(), ep);

            //proxy.getData(message);

            reponse = proxy.getData(message);

            Console.WriteLine(reponse);


            return reponse;
        }
    }
}
