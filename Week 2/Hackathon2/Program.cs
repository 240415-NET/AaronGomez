using System.Security.Cryptography.X509Certificates;

namespace Hackathon2;

class Program
{
    static void Main(string[] args)
    {
        bool exitProgram = false;

        GroceryList myList= new();
        while (exitProgram == false)
        {
        Console.WriteLine("Please select what you would like to do");
        Console.WriteLine("A: Add Groceries to List");
        Console.WriteLine("U: Update Grocery List Options");
        Console.WriteLine("V: View Grocery List Options");
        Console.WriteLine("X: Exit the Application");
        try
            {
            string userInput = Console.ReadLine();
            if(userInput.ToLower() == "a")
            {
                Console.WriteLine("The user input 'a'");
                Console.WriteLine("How many items do you want to add?");
            try
            {
                int numberItems = int.Parse(Console.ReadLine());
        
                for (int i = 0; i < (numberItems); i++)
                {
                Console.WriteLine("Please add a grocery to your list?");
                try{
                myList.Load(myList,Console.ReadLine().Trim().ToLower());
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Please write a grocery item");
                }
            }
        }
        catch
        {
            Console.WriteLine("I don't understand what you entered");
        }
            }
            else if(userInput.ToLower() == "u")
            {
                Console.WriteLine("The user input u");
            }
            else if(userInput.ToLower()=="v")
            {
                myList.Print("myList");
            }
            else if(userInput.ToLower()== "x")
            {
                Console.WriteLine("The user wants to exit");
                return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
            Console.WriteLine("Please enter one of the letter options given");

        }

       }
        

        myList.Print("myList");
    }

}

