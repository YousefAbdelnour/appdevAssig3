using System;
using System.Linq;

namespace AbdelnourYousefAssignment03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HugeInteger h1 = new HugeInteger("1987543");
            HugeInteger h2 = new HugeInteger("110843240");
            Console.WriteLine(string.Join("", h1.Digits));
            Console.WriteLine("Is h2 bigger than h1: " + h2.IsGreaterThan(h1));
            Console.WriteLine("h1 - h2 = " + string.Join("", h1.Subtract(h2).Digits.Reverse()));
            Console.WriteLine("h1 + h2 = " + string.Join("", h2.Add(h1).Digits.Reverse()));
            Console.WriteLine(h2.ToString());
            Console.WriteLine(string.Join("", h1.Multiply(h2).Digits));
            Console.WriteLine(string.Join("", h2.Divide(h1).Digits));
        }
    }
}
