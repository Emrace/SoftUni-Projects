using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

class InsertionSort
{
    static void Main()
    {
        DateTime now = DateTime.Now;
        //int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] array = {1, 25, 78, 97, 45, 66, 79, 124, 2, 3, -1};
        array = SortInsertion(array);

        Console.WriteLine(String.Join(" ", array));
    }

    static int[] SortInsertion(int[] numbers)
    {
        for (int i = 1; i < numbers.Length; i++)
        {
            int current = i;
            while (current > 0 && numbers[current - 1] > numbers[current])
            {
                numbers[current] ^= numbers[current - 1];
                numbers[current - 1] ^= numbers[current];
                numbers[current] ^= numbers[current - 1];

                current--;
            }
        }

        return numbers;
    }
}
