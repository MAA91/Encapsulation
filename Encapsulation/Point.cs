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
            this.y = y;
            Console.WriteLine($"Constructor:\t{GetHashCode()}");
        }
        public Point(Point other)
        {
            X = other.X;
            Y = other.Y;
            Console.WriteLine($"CopyConstructor:\t{GetHashCode()}");
        }
        ~Point()
        {
            Console.WriteLine($"Distructor:\t{GetHashCode()}");
        }

        //Operator
        public static Point operator+(Point left, Point right)
        {
            Point res = new Point(left.X + right.X, left.Y + right.Y);
            return res;
        }
        public static Point operator -(Point left, Point right)
        {
            return left + (-right);
        }
        public static Point operator++(Point obj)
        {
            obj.X++;
            obj.Y++;
            return obj;
        }
        public static Point operator--(Point obj)
        {
            obj.X--;
            obj.Y--;
            return obj;
        }
        public static Point operator -(Point right)
        {
            right.X = -right.X;
            right.Y = -right.Y;
            return right;
        }
        public static Point operator +(Point right)
        {
            return right;
        }

        public static bool operator==(Point left, Point right)
        {
             return (left.X == right.X) && (left.Y == right.Y);
        }
        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }


        //Metods
        public void Print()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }
        public double Distance(Point other)
        {
            return Math.Sqrt((this.x - other.x) * (this.x - other.x) + (this.y - other.y) * (this.y - other.y));
        }
        public static double Distance(Point A, Point B)
        {
            return A.Distance(B);
        }
    }
}
