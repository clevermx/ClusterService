using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using ClusterizationService;

namespace HostServer2
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost host = new ServiceHost(typeof(kMeans), new Uri("http://localhost:8000/kMeans"));
            // Добавляем конечную точку службы с заданным интерфейсом, привязкой (создаём новую) и адресом конечной точки
            host.AddServiceEndpoint(typeof(IkMeans), new BasicHttpBinding(), "");
            // Запускаем службу
            host.Open();
            Console.WriteLine("Сервер запущен");
            Console.ReadLine();
        }
    }
}
