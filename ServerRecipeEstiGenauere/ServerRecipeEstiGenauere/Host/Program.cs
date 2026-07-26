using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfServiceLibrary2;



namespace Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(RecipeService));
            host.Open();
                Console.WriteLine("This Is My Server. Do Not Close!!");
            Console.ReadLine();

        }
    }
}
