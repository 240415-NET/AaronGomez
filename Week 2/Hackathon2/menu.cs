namespace Hackathon2;

class Menu
{
       public static void ListMenu()
       
       {
        
        Console.Clear();
        
        Console.WriteLine("Please select what you would like to do");
        Console.WriteLine("A: Add Groceries to List");
        Console.WriteLine("U: Update Grocery List Options");
        Console.WriteLine("X: Exit the Application");
        try
            {
            string userInput = Console.ReadLine();
            if(userInput.ToLower() == "a")
            {
                Console.WriteLine("The user input 'a'");
            }
            else if(userInput.ToLower() == "u")
            {
                Console.WriteLine("The user input u");
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


}

