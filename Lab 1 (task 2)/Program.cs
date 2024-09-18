using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<int> numbers = new Queue<int>(new int[] { -3, 5, -2, 8, 0, -7, 10 });

        var positives = numbers.Where(n => n > 0).ToList();
        var negatives = numbers.Where(n => n < 0).ToList();

        double positiveAverage = positives.Any() ? positives.Average() : 0;
        double negativeAverage = negatives.Any() ? negatives.Average() : 0;

        Console.WriteLine($"Середнє арифметичне додатних чисел: {positiveAverage:N2}");
        Console.WriteLine($"Середнє арифметичне від'ємних чисел: {negativeAverage:N2}");
    }
}
