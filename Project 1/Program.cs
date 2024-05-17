﻿namespace Project_1;

class Program
{
    static void Main(string[] args)
    {
        //Console.Clear();
        //Menu.StartMenu();
        User myUser = new("Joe");
        SqlRepository.StoreUser(myUser);
        Guess myGuess = new(myUser.userId, new Guid("00000000-0000-0000-0000-000000000004"), 324, new TimeSpan(hours: 0, minutes:0, seconds:7));
        SqlGuessRepository.StoreGuess(myGuess);

        Console.WriteLine(SqlGuessRepository.ReadGuesses()[0].guesserId);
        Console.WriteLine("Guesses read successfully");

    
    }
}
