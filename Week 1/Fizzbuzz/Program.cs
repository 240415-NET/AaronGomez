﻿namespace Fizzbuzz;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        for(int i = 1; i <= 100; i++)
        if(i%3==0 && i%5 == 0)
        {
            Console.WriteLine("Fizzbuzz");
        }
        else if(i%3==0)
        {
            Console.WriteLine("Fizz");
        }
        else if(i%5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
}
