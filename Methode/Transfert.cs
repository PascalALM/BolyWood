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

        private STC_MSG msg;
        public STC_MSG getData(STC_MSG message)
        {
            Console.WriteLine("Transfert.getData() Succès");
            //if (message.OpName == "sendBC")
            //{
            //    message = new Controller().getResult(message);
            //}

            msg = new STC_MSG();
            msg.AppName = "BolyWood Motherfucker";
            msg.AppVrs = "1000.0";
            msg.OpName = "sendBC";
            msg.OpStatut = false;

            msg.MsgInfo = "";
            

            return message;
        }
    }
}
