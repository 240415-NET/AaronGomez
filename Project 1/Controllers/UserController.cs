public class UserController
{
    
    public static User CreateUser(string userName)
    {

        User newUser = new User(userName);
        UserStorage.StoreUser(newUser);
        return newUser;
    }

    public static bool UserExists(string userName)
    {
        if(UserStorage.FindUser(userName) != null)
        {
            return true;
        }

        return false;
    }

    public static User GetUser(string userName)
    {
        return UserStorage.FindUser(userName);
    }
    
    
}