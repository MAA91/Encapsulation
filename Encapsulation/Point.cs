using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    
    internal class Point
    {
        double x;
        double y;

        public double GetX()
        {
            return x;
        }
        public void SetX(double x)
        {
            this.x = x;
        }
        public double GetY()
        {
            return y;
        }
        public void SetY(double y)
        {
            this.y = y;
        }

        public double X 
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(double x = 0, double y = 0)
        {
            this.x = x;
            this.Y = y; 
        }

        public double Distance(Point other)
        {
            return Math.Sqrt((this.x - other.x) * (this.x - other.x) + (this.y - other.y) * (this.y - other.y));
        }
        public static double Distance(Point A, Point B)
        {
            return Math.Sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));
        }
    }
}
