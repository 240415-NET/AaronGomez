namespace TuesdayHackathon;

public class Car
{
    public int year {get; set;}
    
    public string Make {get; set;}

    public string Model {get; set;}

    //Methods
    public static void DefineCar()
    {
        try
        (
        Console.WriteLine("What year is your car?");
        year = TryParse.ToInt32(Console.ReadLine());
        Console.WriteLine("What Model is your car?");
        Model = Console.ReadLine();
        Console.WriteLine("What Make is your car?");
        Make = Console.ReadLine();
        )
        catch(

        )
    }

}