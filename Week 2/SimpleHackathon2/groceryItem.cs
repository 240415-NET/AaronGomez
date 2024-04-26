namespace SimpleHackathon2;

public class groceryItem
{
    public string Name;
    public string Category;

    public static string[] categoryArray = ["Fresh Produce", "Bakery", "Meat", "Frozen", "Dairy", "Miscellaneous"];
    public double Price;
    public bool Purchased = false;

    public groceryItem(string Name, string Category, double Price)
    {
        this.Name = Name;
        this.Category = Category;
        this.Price = Price;
    }

    public override string ToString()
    {
	    return $"Name: {Name}, Category: {Category}, Price per unit: ${Price}";
    }

    

}