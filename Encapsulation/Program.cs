using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(2, 3);
            Point B = new Point(6, 6);
            Console.WriteLine(A.Distance(B));
            Console.WriteLine(Point.Distance(A, B));

            
        }
    }
}
