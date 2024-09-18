using System;

class Program
{
    static void Main()
    {
        string[] zodiacSigns = new string[]
        {
            "Овен", "Телець", "Близнюки", "Рак",
            "Лев", "Діва", "Терези", "Скорпіон",
            "Стрілець", "Козеріг", "Водолій", "Риби"
        };

        Console.WriteLine("Знаки зодіаку в прямому порядку:");
        foreach (string sign in zodiacSigns)
        {
            Console.WriteLine(sign);
        }

        Console.WriteLine("\nЗнаки зодіаку в зворотному порядку:");
        for (int i = zodiacSigns.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(zodiacSigns[i]);
        }

        Console.WriteLine($"\nКількість елементів у масиві: {zodiacSigns.Length}");

        Array.Clear(zodiacSigns, 0, zodiacSigns.Length);
    }
}
