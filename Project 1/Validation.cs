//looks for string input
using System.Security.Cryptography.X509Certificates;

public class ValidateUserInput
{
    public string ValidateString(string input)
    {
        bool Continue = true;
        
        do{
        input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            Console.WriteLine("Please enter a value?");
        }
        else
        {      
        try{
            Convert.ToInt32(input);
            Continue = false;
        }
        catch(Exception e)
        {
             //Console.WriteLine(e.StackTrace);
             Console.WriteLine("Please enter an integer?");
        }
        
        }
        }
        while(!Continue);
        return input;
             
    }

    public static int ValidateInt()
    {
        bool IsValid =false;
        do{
            try{
                string input = Console.ReadLine();
                if(input==null || input=="")
                {Console.WriteLine("Please enter a number");}
                int validInt = Convert.ToInt32(input.Trim());
                return validInt;
                IsValid = true;
            }
            catch
            {
            Console.WriteLine("Please enter an integer");
            }
            //return validInt;
        }
        while(!IsValid);
        return 0;

    }
}