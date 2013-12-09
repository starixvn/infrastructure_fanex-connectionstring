using System.Configuration;
using System.Threading;
using Fanex.ConnectionString.Client;

namespace Fanex.ConnectionString.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionStringManager.Start();

            DoAction();//
        }

        static void DoAction()
        {
            while (true)
            {
                var collection = ConnectionStringManager.ConnectionStrings;                

                foreach (ConnectionStringSettings item in collection)
                {
                    System.Console.WriteLine("alias:{0},connection:{1}", item.Name, item.ConnectionString);
                }
                System.Console.WriteLine("----------");

                Thread.Sleep(5000);

            }
        }

    }
}
