using System;
using System.Collections.Generic;
using System.Linq;

class LinearAndBinary
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine(LinearSearch(array, n));

    }

    
    

    static int LinearSearch(int[] array, int element)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == element)
            {
                return i;
            }
        }

        return -1;
    }

    static int BinarySearch(int[] array, int element)
    {
        int min = 0;
        int max = array.Length - 1;
        int mid = array.Length / 2;


        while (max > min)
        {
            mid = (min+max)/2;
            if (element == array[mid])
            {
                return mid;
            }
            else if (element > array[mid])
            {
                min = mid + 1;
            }
            else
            {
                max = mid - 1;
            }
        }

        return -1;
    }
}