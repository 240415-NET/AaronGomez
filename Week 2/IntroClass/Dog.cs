namespace IntroClass;

public class Dog
{
    //Fields
    public string breed {get; set; }
    public string name {get; set; }

    public int age {get; set; }

    public double weight {get; set; }

    //Methods
    public void Bark()
    {
        Console.WriteLine($"{name}: bark bark");
    }

    public static void DefineDog()
    {
        Console.WriteLine("A dog is a domesticated descendant of the wolf.");
    }

}