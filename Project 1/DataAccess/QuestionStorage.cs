using System.Text.Json;

public class QuestionStorage : IQuestionStorageRepo
{
    public static string filePath = "QuestionsFile.json";

    public void StoreQuestion(TriviaQuestion question)
    {   

            string existingQuestionsJson = File.ReadAllText(filePath);

            List<TriviaQuestion> existingQuestionsList = JsonSerializer.Deserialize<List<TriviaQuestion>>(existingQuestionsJson);

            existingQuestionsList.Add(question);

            string jsonExistingUsersListString = JsonSerializer.Serialize(existingQuestionsList);

            File.WriteAllText(filePath, jsonExistingUsersListString);
    }

    public List<TriviaQuestion> ViewAllQuestions()
    {   

        string existingQuestionsJson = File.ReadAllText(filePath);

        List<TriviaQuestion> existingQuestionsList = JsonSerializer.Deserialize<List<TriviaQuestion>>(existingQuestionsJson);

        return existingQuestionsList;

    }

    //FindQuestion can be used to modify by an Admin
    /*public static TriviaQuestion FindQuestion(string usernameToFind)
    {
        TriviaQuestion foundQuestion = new();

        try{
            string existingUsersJson = File.ReadAllText(filePath);

            List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);

            foundQuestion = existingUsersList.FirstOrDefault(user => user.userName == usernameToFind);

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
        
        return foundQuestion;
    }*/


    /*public static TriviaQuestion RandomQuestion(string usernameToFind)
    {
        TriviaQuestion selectedQuestion = new();

        try{
            string existingQuestionsJson = File.ReadAllText(filePath);

            List<TriviaQuestion> existingQuestionsList = JsonSerializer.Deserialize<List<TriviaQuestion>>(existingQuestionsJson);

            Random rand = new();
            selectedQuestion = existingQuestionsList[rand.Next()];

            return selectedQuestion;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return selectedQuestion;
    }*/

    /*public static void StoreAllQuestions(List<TriviaQuestion> questions)
    {   
        {
            File.Delete(filePath);
            
            List<TriviaQuestion> initialQuestionsList = new List<TriviaQuestion>();

            //initialQuestionsList.Add(question);

            string jsonUsersListString = JsonSerializer.Serialize(initialQuestionsList);

            File.WriteAllText(filePath, jsonUsersListString);
        }

    }*/

    public void DeleteQuestion(TriviaQuestion question)
    {   

        if(File.Exists(filePath))
        {
            string existingQuestionsJson = File.ReadAllText(filePath);

            List<TriviaQuestion> existingQuestionsList = JsonSerializer.Deserialize<List<TriviaQuestion>>(existingQuestionsJson);

            existingQuestionsList.Remove(question);

            string jsonExistingUsersListString = JsonSerializer.Serialize(existingQuestionsList);

            File.WriteAllText(filePath, jsonExistingUsersListString);

        }
        else if (!File.Exists(filePath)) 
        {
            List<TriviaQuestion> initialQuestionsList = new List<TriviaQuestion>();

            initialQuestionsList.Remove(question);

            string jsonUsersListString = JsonSerializer.Serialize(initialQuestionsList);

            File.WriteAllText(filePath, jsonUsersListString);
        }

    }

}