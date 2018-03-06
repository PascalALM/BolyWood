using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Composants;

namespace Contrat
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract(Namespace = "http://Bolywood")]
    public interface IDataContract
    {
        [OperationContract]
        STC_MSG getData(STC_MSG msg);
        

        // TODO: ajoutez vos opérations de service ici
    }
}
