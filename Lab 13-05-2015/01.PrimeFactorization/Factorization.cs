using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Factorization
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        PrintPrimeFactors(n);
    }
    
    
    static void PrintPrimeFactors(int n)
    {
        int factor = 2;
        int temp = n;
        List<int> factors = new List<int>();

        while (temp != 1)
        {
            if (temp % factor == 0)
            {
                temp /= factor;
                factors.Add(factor);
            }
            else
            {
                factor++;
            }
        }

        Console.WriteLine("{0} = {1}", n, String.Join(" * ", factors));
        

    }
}