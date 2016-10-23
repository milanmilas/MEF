using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingWithoutMef
{
    class Program
    {
        static void Main(string[] args)
        {
            //var log = LogManager.GetCurrentClassLogger();
            //log.Info("test message");

            var worker = new Worker();
            worker.DoWork();

            Console.ReadKey();
        }
    }
}
