public class UserController
{
    public static IUserStorageRepo userData = new SqlUserStorage();
    public static User CreateUser(string userName)
    {

        User newUser = new User(userName);
        userData.StoreUser(newUser);
        return newUser;
    }

    public static bool UserExists(string userName)
    {
        if(userData.FindUser(userName) != null)
        {
            return true;
        }

        return false;
    }

    public static User GetUser(string userName)
    {
        return userData.FindUser(userName);
    }
    
    
}