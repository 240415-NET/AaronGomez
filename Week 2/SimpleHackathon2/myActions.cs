namespace SimpleHackathon2;

public class myActions
{
    public static void MenuDisplay()
    {
        bool exitProgram = false;
        List<string> myList = new();

        while(exitProgram == false)
        {
        //Menu
        //Console.Clear();
        Console.WriteLine("Press 1 to add an item to your Grocery List");
        Console.WriteLine("Press 2 to view your grocery list");
        Console.WriteLine("Press 3 to remove an item");
        Console.WriteLine("Press q to exit");

        
        string menuSelection = (Console.ReadLine()??"").Trim().ToLower();
        if(menuSelection == "1")
        {
            //Add Object from user's input
            try
            {
            Console.WriteLine("What do you want to add to your Grocery List?");
            string name = (Console.ReadLine()??"").Trim().ToLower();
            Console.WriteLine($"How much does {name} cost?");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Select a category for {name} from this list:");
            for(int i = 0; i < groceryItem.categoryArray.Count(); i++)
            {
            Console.WriteLine($"{i+1}. {groceryItem.categoryArray[i]}");
            
            }
            int Selected = Convert.ToInt32(Console.ReadLine());
            string categorySelection = groceryItem.categoryArray[Selected];
        
            groceryItem myEntry = new groceryItem(name, categorySelection, price);

            myList.Add(myEntry.ToString());
            Console.WriteLine(myEntry.ToString());
            }
            catch
            {
                Console.WriteLine("I don't understand what you entered");
            }
        }
        else if(menuSelection == "2")
        {
            Console.Clear();
            foreach(var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------");
        }
        else if(menuSelection =="3")
        {
            Console.WriteLine("Which item would you like to Remove");
            for(int i = 0; i<myList.Count(); i++)
            {
                Console.WriteLine($"{i+1}. {myList[i]}");
            }
            try
            {
                int toRemove = (Convert.ToInt32(Console.ReadLine())-1);
                if(toRemove <= myList.Count() && toRemove >= 0)
                {
                myList.RemoveAt(toRemove);
                }
                else
                {
                    Console.WriteLine("Please select a number from the list");
                }
            }
            catch
            {
                Console.WriteLine("Please enter a number");
            }
        }
        else if(menuSelection =="q")
        {
            Console.Clear();
            exitProgram = true;
        }
        else
        {
            Console.WriteLine("I didn't understand what you entered.");
        }     
        }        
    }
}