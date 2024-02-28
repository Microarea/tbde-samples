using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagoCloudApi;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI;
using Image = System.Drawing.Image;
using System.IO;
using System.Collections.Generic;
using System.ServiceProcess;

namespace MagoCloudApi
{
    public class ServiceManager
    {
        public List<(string serviceName, string Status)> GetServicesStatus()
        {
            List<(string serviceName, string Status)> servicesStatus = new List<(string serviceName, string Status)>();

            // Ottieni tutti i servizi installati
            ServiceController[] services = ServiceController.GetServices();

            // Filtra i servizi che iniziano con "magoweb"
            var filteredServices = services.Where(s => s.ServiceName.StartsWith("magoweb_"));

            foreach (ServiceController service in filteredServices)
            {
                string status = GetServiceStatus(service.ServiceName);
                servicesStatus.Add((service.ServiceName, status));
            }

            return servicesStatus;
        }

        private string GetServiceStatus(string serviceName)
        {
            using (ServiceController sc = new ServiceController(serviceName))
            {
                try
                {
                    return sc.Status == ServiceControllerStatus.Running ? "✅" : "❌";
                }
                catch
                {
                    return "Errore";
                }
            }
        }
    }
}



