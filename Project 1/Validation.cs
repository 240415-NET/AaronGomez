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

public class HandleUserInput()
{
    public static bool ValidateUserInput(string userInput, string validationType, int limiter =0, int lowerlimit = 0)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("Please enter something");
            return false;
        }
        switch (validationType)
        {
            case "alphaOnly":

                break;
            case "integerOnly":
                int testInt;
                if (!Int32.TryParse(userInput, out testInt))
                {
                    Console.WriteLine("Enter a whole number.");
                    return false;
                }
                //if(limiter>0 && Convert.ToInt32(userInput) > limiter)
                if (testInt > limiter || testInt <=0)
                {
                    Console.WriteLine("Enter one of the applicable options");
                    return false;
                }
                /**else if(testInt <= lowerlimit)
                {
                    Console.WriteLine("This should be a positive whole number. Not 0, not negative. Try again.");
                    return false;
                }*/
                return true;
            default:
                return true;
        }
        return true;
    }
    public static string ReturnUserInput(string validationType, bool valIsSingleChar = false, int limiter = 0, int lowerlimit = 0)
    {
        string strUserInput;
        bool isValid;
        //bool keepAsking = true;
        //do
        //{
            strUserInput = (Console.ReadLine()??"").Trim();
            Console.ForegroundColor = ConsoleColor.Red;
            isValid = ValidateUserInput(strUserInput, validationType, limiter, lowerlimit);
            Console.ResetColor();
            if (!isValid)
            {
                strUserInput = "noCurrentValidInput";
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            // else
            // {
            //     keepAsking = false;
            // }
        //}while (keepAsking);
        return strUserInput;
    }
}