// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

class Program
{
    static void Main(string[] args){
        Console.WriteLine("Please enter a number:");
        int newInt = Convert.ToInt32(Console.ReadLine());

        /*if(newInt == 4 )
        {
            Console.WriteLine("newInt equals 4!");
        }
        else
        {
            Console.WriteLine("newInt is a number");
        }*/

        switch(newInt)
        {
            case 1: 
                Console.WriteLine("newInt equals 1");
                break;
            case >=8:
                Console.WriteLine("newInt is greater than or equal to 8");
                break;
            case <0:
                Console.WriteLine("newInt is negative");
                break;
            default:
                Console.WriteLine("newInt is a number");
                break;
        }
    }
}

