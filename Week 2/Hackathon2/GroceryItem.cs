namespace Hackathon2;
public class GroceryList
{

    public List<string> GroceryItem {get; set;}
    public void CreateList()
    {
        
    }
    public void Load(List<string> listName, string data)
    {
        listName.Add(data);
    }

    public void Print(string listName)
    {
        foreach(var item in listName)
        {
            Console.WriteLine(item);
        }
    }

    public void Remove()
    {

    }
    
}


/*public class GroceryItem
{
    public bool Status = false;

    public double Price {get; set;}
    public string Description {get; set;}

    //Constructor
    public GroceryItem(string Description, bool Status, double Price)
    {

    }

    //Override ToString
    public override string ToString()
    {

        if(Status == true){
            return $"{Description}\n Price: ${Price}\nStatus: To Buy";
        }
        else
        {
        return $"{Description}\n Price: ${Price}\nStatus: Purchased";
        }
    }

    /*public string CreateList()
    {
        List<string> GroceryList = new List<string>();
    }*/

    /*public string AddToList()
    {
        string userInput;

        while (quit == false)
        {
            Console.WriteLine("Please enter an item for your shopping list or type 'print' to print list");
            userInput = Console.ReadLine().Trim();
            if (userInput.ToLower() == "q")
            {
                quit = true;
            }
            else if (userInput.ToLower() == "print")
            {
                shoppingList.ForEach(Console.WriteLine);
            }
            else
            {
                shoppingList.Add(itemNum + ". " + userInput);
                itemNum++;
            }
        }
    }


}*/
