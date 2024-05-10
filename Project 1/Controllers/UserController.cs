public class UserController
{
    
    public static void CreateUser(string userName)
    {

        User newUser = new User(userName);
        UserStorage.StoreUser(newUser);
    }

    public static bool UserExists(string userName)
    {
        /*if(UserStorage.FindUser(userName) != null)
        {
            return true;
        }*/

        return false;
    }

    public static User GetUser(string userName)
    {
        return UserStorage.FindUser(userName);
    }
    
    
}