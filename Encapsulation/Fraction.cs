using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    internal class Fraction
    {
        public int Integer { get; set; }
        public int Numenator { get; set; }
        int denominator;
        public int Denominator
        {
            get => denominator;
            set => denominator = value == 0 ? 1 : value;
        }

        //Constructors
        public Fraction(int integer)
        {
            Integer = integer;
            Console.WriteLine($"1ArgConstructor:\t{GetHashCode()}");
        }
        public Fraction()
        {
            Console.WriteLine($"DefConst:\t{GetHashCode()}");
        }
        public Fraction(int integer, int numenator, int denominator)
        {
            Integer = integer;
            Numenator = numenator;
            this.denominator = denominator;
            Console.WriteLine($"Constructor:\t{GetHashCode()}");
        }
        public Fraction(int numenator, int denominator)
        {
            Numenator = numenator;
            this.denominator = denominator;
            Console.WriteLine($"Constructor:\t{GetHashCode()}");
        }
        public Fraction(Fraction other)
        {
            Integer = other.Integer;
            Numenator = other.Numenator;
            denominator = other.Denominator;
            Console.WriteLine($"CopyConst:\t{GetHashCode()}");
        }

        ~Fraction()
        {
            Console.WriteLine($"Destructor:\t{GetHashCode()}");
        }

        //Metods:
        public void Print()
        {
            if (Integer != 0) Console.Write(Integer);
            if (Numenator != 0)
            {
                if (Integer != 0) Console.Write("(");
                Console.Write($"{Numenator} / {Denominator}");
                if (Integer != 0) Console.Write(")");
            }
            else if (Integer == 0) Console.Write(0);
            Console.WriteLine();
        }
        public override string ToString()
        {
            string res = "";
            if (Integer != 0) res += Integer;
            if (Numenator != 0)
            {
                if (Integer != 0) res += "(";
                res += $"{Numenator} / {Denominator}";
                if (Integer != 0) res += ")";
            }
            else if (Integer == 0) res += "0";
            return res;
        }
        public Fraction Improper()
        {
            Fraction copy = new Fraction(this);
            copy.Numenator += copy.Integer * copy.Denominator;
            copy.Integer = 0;
            return copy;
        }
        public Fraction Proper()
        {
            Fraction copy = new Fraction(this);
            copy.Integer += copy.Numenator / copy.Denominator;
            copy.Numenator %= copy.Denominator;
            return copy;
        }
        public Fraction Reduction()
        {
            for (int i = 2; i < Math.Min(Numenator, Denominator);)
                if (((Numenator % i) == 0) && ((Denominator % i) == 0))
                {
                    Numenator /= i;
                    Denominator /= i;
                }
                else i++;
            return this;
        }
        public double Decimal()
        {
            return Integer + (double)Numenator/Denominator;
        }

        //Operators
        public static Fraction operator * (Fraction l, Fraction r)
        {
            Fraction left = l.Improper();
            Fraction right = r.Improper();
            Fraction result = new Fraction(left.Numenator * right.Numenator, left.Denominator * right.Denominator);
            return result.Reduction();
        }
        public static Fraction operator / (Fraction l, Fraction r)
        {
            Fraction left = l.Improper();
            Fraction right = r.Improper();
            Fraction result = new Fraction(left.Numenator * right.Denominator, left.Denominator * right.Numenator);
            return result.Reduction();
        }
        public static Fraction operator + (Fraction l, Fraction r)
        {
            Fraction left = l.Improper();
            Fraction right = r.Improper();
            Fraction result = new Fraction(left.Numenator * right.Denominator + right.Numenator * left.Denominator, left.Denominator * right.Denominator);
            return result.Reduction();
        }
        public static Fraction operator - (Fraction l, Fraction r)
        {
            Fraction left = l.Improper();
            Fraction right = r.Improper();
            Fraction result = new Fraction(left.Numenator * right.Denominator - right.Numenator * left.Denominator, left.Denominator * right.Denominator);
            return result.Reduction();
        }
        public static Fraction operator++ (Fraction right)
        {
            right.Integer++;
            return right;
        }
        public static Fraction operator-- (Fraction right)
        {
            right.Integer--;
            return right;
        }
        
        public static bool operator== (Fraction left, Fraction right)
        {
            return left.Decimal() == right.Decimal();
        }
        public static bool operator!= (Fraction left, Fraction right)
        {
            return !(left == right);
        }
        public static bool operator > (Fraction left, Fraction right)
        {
            return left.Decimal() > right.Decimal();
        }
        public static bool operator < (Fraction left, Fraction right)
        {
            return left.Decimal() > right.Decimal();
        }
        public static bool operator<= (Fraction left, Fraction right)
        {
            return !(left > right);
        }
        public static bool operator>= (Fraction left, Fraction right)
        {
            return !(left < right);
        }
    }
}
