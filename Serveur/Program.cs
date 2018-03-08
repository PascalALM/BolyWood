using Contrat;
using Methode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Serveur
{
    class Program
    {
        static void Main(string[] args)
        {
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

                    Console.WriteLine("Press <Enter> to stop the service.");
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

        }
    }
}
