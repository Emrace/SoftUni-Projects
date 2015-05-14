using System;
using System.Collections.Generic;
using System.Linq;

class Sieve
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        PrintPrimes(n);
    }

    static void PrintPrimes(int n)
    {
        List<int> numbers = new List<int>();

        numbers = Enumerable.Range(0, n + 1).ToList();

        for (int i = 2; i < numbers.Count; i++)
        {
            for (int j = i*2; j < numbers.Count; j+=i)
            {
                numbers[j] = -1;
            }
        }

        numbers.RemoveAll(x => x == -1);
        numbers.Remove(0);
        numbers.Remove(1);



        Console.WriteLine(String.Join(", ", numbers));
    }
}