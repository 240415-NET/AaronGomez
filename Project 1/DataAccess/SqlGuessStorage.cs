using System.Data.SqlClient;

public class SqlGuessStorage : IGuessStorageRepo
{
    public static string path = "./../ConnectionString.txt";
    public void StoreGuess(Guess guess)
    {

        string connectionString = File.ReadAllText(path);

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = "INSERT INTO Guesses (questionId, userId, guessText, guessTime) VALUES (@questionId, @userId, @guessText, @guessTime)";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        cmd.Parameters.AddWithValue("@questionId", guess.questionId);
        cmd.Parameters.AddWithValue("@userId", guess.guesserId);
        cmd.Parameters.AddWithValue("@guessText", guess.guessText);
        cmd.Parameters.AddWithValue("@guessTime", guess.guessTime);

        cmd.ExecuteNonQuery();

        connection.Close();

    }

    public List<Guess> ReadGuesses()
    {

        string connectionString = File.ReadAllText(path);

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = "SELECT questionId, userId, guessText, guessTime from Guesses;";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        using SqlDataReader reader = cmd.ExecuteReader();

        List<Guess> GuessList = new();

        while (reader.Read())
        {

            Guid questionId = new Guid(reader.GetString(0));
            Guid guesserId = new Guid(reader.GetString(1));
            int guessText = reader.GetInt32(2);
            DateTime guessTime = reader.GetDateTime(3);
            TimeSpan guessTimeSpan = guessTime.TimeOfDay;
            Guess guess = new(guesserId, questionId, guessText, guessTimeSpan);
            GuessList.Add(guess);

        }

        if (GuessList.Count > 0)
            return GuessList;
        else
            return null;
    }

    public bool FindGuess(Guid userId, Guid guessToFind)
    {

        string connectionString = File.ReadAllText(path);

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = @"SELECT userId, userName FROM Users WHERE userName=@usernameToFind;";
        //interpolate string cmdText = @"SELECT userId FROM Users WHERE userId=usernameToFind";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@guessToFind", guessToFind);

        using SqlDataReader reader = cmd.ExecuteReader();

        Guess myGuess = new();

        while (reader.Read())
        {
            Guid questionId = new Guid(reader.GetString(0));
            Guid guesserId = new Guid(reader.GetString(1));
            int guessText = reader.GetInt32(2);
            DateTime guessTime = reader.GetDateTime(3);
            TimeSpan guessTimeSpan = guessTime.TimeOfDay;
            //Guess guess = new(guesserId, questionId, guessText, guessTimeSpan);

        }
        connection.Close();
        if (myGuess.guesserId==Guid.Empty)
            return false;
        else
            return true;

    }

}