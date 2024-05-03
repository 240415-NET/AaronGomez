using System.Text.Json;

public class UserStorage
{
    public static void StoreUser(User user)
    {
        List<User> users = new List<User>();
        
        if(File.Exists("Guesses.json"))
        {
            List<User> initialUsersList = new List<User>();
            
            

        }
        else
        {
            users.Add(user);
            

            string jsonUsersString = JsonSerializer.Serialize(users);

            File.Create("Guesses.json");
        }
    }
}