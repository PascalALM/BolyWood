using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Composants;

namespace Contrat
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract(Namespace = "http://Bolywood")]
    public interface IDataContract
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/commande/", 
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
        )]
        STC_MSG GetMessage(string msg);
        [OperationContract]
        [WebGet(UriTemplate = "/insertDatePrev/{id_commande}/{date}/",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json
        )]
        string insertDatePrev(string id_commande, string date);

    }
}
