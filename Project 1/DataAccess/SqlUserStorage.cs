using System.Data.SqlClient;

public class SqlUserStorage : IUserStorageRepo
{
    public static string path = "./../ConnectionString.txt";
    public void StoreUser(User user)
    {

        string connectionString = File.ReadAllText(path);

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        if(FindUser(user.userName)!=null)
        {
            Console.WriteLine("User found");

        }
        else
        {
            Console.WriteLine("User not found");

            string cmdText = "INSERT INTO Users (userId, userName) VALUES (@userId, @userName)";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@userId", user.userId);
            cmd.Parameters.AddWithValue("@userName", user.userName);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

    }

    public User FindUser(string usernameToFind)
    {

        string connectionString = File.ReadAllText(path);

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = @"SELECT userId, userName FROM Users WHERE userName=@usernameToFind;";
        //interpolate string cmdText = @"SELECT userId FROM Users WHERE userId=usernameToFind";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@usernameToFind", usernameToFind);

        using SqlDataReader reader = cmd.ExecuteReader();

        User myUser = new();

        while (reader.Read())
        {

            myUser.userId = new Guid(reader.GetString(0));
            myUser.userName = reader.GetString(1);
        }
        connection.Close();
        if (String.IsNullOrEmpty(myUser.userName))
        return null;
        else
        return myUser;
    }
}

