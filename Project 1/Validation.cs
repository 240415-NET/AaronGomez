//looks for string input
public class ValidateUserInput
{
    

    public string ValidateName(string input)
    {
        bool Continue = true;
        do{
        try{
        input.Trim().ToLower();
        return input;
        if input.IsNullorEmpty
        {}
        else
        {
            Console.WriteLine("Please enter a username");
        }
        }
        catch(Exception e)
        {
             Console.WriteLine(e.StackTrace);
             return input;
        }
        }
        while(Continue==true);
        
        
    }
}

public class ValidateName
{

}