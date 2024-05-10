using System.Text.Json;

public class UserStorage 
{
    public static string filePath = "UsersFile.json";

    public static void StoreUser(User user)
    {   

        if(File.Exists(filePath))
        {
            string existingUsersJson = File.ReadAllText(filePath);

            List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);

            existingUsersList.Add(user);

            string jsonExistingUsersListString = JsonSerializer.Serialize(existingUsersList);

            File.WriteAllText(filePath, jsonExistingUsersListString);

        }
        else if (!File.Exists(filePath)) 
        {
            List<User> initialUsersList = new List<User>();

            initialUsersList.Add(user);

            string jsonUsersListString = JsonSerializer.Serialize(initialUsersList);

            File.WriteAllText(filePath, jsonUsersListString);
        }

    }

    public static User FindUser(string usernameToFind)
    {
        User foundUser = new();

        try{
            string existingUsersJson = File.ReadAllText(filePath);

            List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);

            foundUser = existingUsersList.FirstOrDefault(user => user.userName == usernameToFind);

            //if (foundUser )

            //The above lambda function is essentially iterating through and querying the list for us, 
            //as if we were doing the foreach loop below
            // foreach (User user in existingUsersList){
            //     if(user.userName == usernameToFind)
            //     {
            //         return user;
            //     }
            // }

            //If it exists, return that user
            

            //If it doesn't... do something else 


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return foundUser;

    }

}