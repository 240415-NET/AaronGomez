using System.Data.SqlClient;
public class SqlQuestionStorage : IQuestionStorageRepo
{
    public static string path = "./../ConnectionString.txt";
    
    public void StoreQuestion(TriviaQuestion question)
    {
        string connectionString = File.ReadAllText(path);

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = "INSERT INTO TriviaQuestions (questionId, questionText, correctAnswer, unit) VALUES (@questionId, @questionText, @correctAnswer, @unit)";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        cmd.Parameters.AddWithValue("@questionId", question.questionId);
        cmd.Parameters.AddWithValue("@questionText", question.questionText);
        cmd.Parameters.AddWithValue("@correctAnswer", question.correctAnswer);
        cmd.Parameters.AddWithValue("unit", question.unit);

        cmd.ExecuteNonQuery();

        connection.Close();
        //Console.WriteLine($"{question.questionText} saved");
    }
    
    public List<TriviaQuestion> ViewAllQuestions()
    {
        string connectionString = File.ReadAllText(path);

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = "SELECT questionId, questionText, correctAnswer, unit from TriviaQuestions;";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        using SqlDataReader reader = cmd.ExecuteReader();

        List<TriviaQuestion> existingQuestionList = new();

        while (reader.Read())
        {
            //Guid not being read
            Guid questionId = new Guid(reader.GetString(0));
            //Guid questionId = reader.GetGuid(0);
            string questionText = reader.GetString(1);
            int correctAnswer = reader.GetInt32(2);
            string unit = reader.GetString(3);
            TriviaQuestion question = new(questionId, questionText, correctAnswer, unit);
            existingQuestionList.Add(question);

        }

        if (existingQuestionList.Count > 0)
            return existingQuestionList;
        else
            return null;
    }

    public void DeleteQuestion(TriviaQuestion question)
    {
        string connectionString = File.ReadAllText(path);

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = "DELETE from TriviaQuestions WHERE questionId=@IdToDelete;";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        cmd.Parameters.AddWithValue("@IdToDelete", question.questionId);

                cmd.ExecuteNonQuery();

        connection.Close();

        //Console.WriteLine($"{question.questionText} Deleted");
    }
}