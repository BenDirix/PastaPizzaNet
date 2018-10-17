using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class LijnTrekker
    {
        public static void TrekLijn()
        {
            Console.WriteLine();
            for (int i = 0; i < 80; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
