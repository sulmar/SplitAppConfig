using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAppConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConfigurationManager.
                ConnectionStrings["VidiaConnection"].ConnectionString;


            Console.WriteLine(connection);


            var serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
        }
    }
}
