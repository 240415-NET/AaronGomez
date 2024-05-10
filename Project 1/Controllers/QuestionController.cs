public class QuestionController
{
    
    public static void CreateQuestion(string questionText, int answer, string unit)
    {

        TriviaQuestion newQuestion = new(questionText, answer, unit);
        QuestionStorage.StoreQuestion(newQuestion);
    }

    public static bool QuestionAnswered(User currentUser, TriviaQuestion currentQuestion)
    {
        bool GuessFound = GuessStorage.FindGuess(currentUser.userId, currentQuestion.questionId);
        return GuessFound;
    }

    public static void DeleteQuestion(TriviaQuestion question)
    {
        QuestionStorage.DeleteQuestion(question);

    }

    public static List<TriviaQuestion> DisplayAllQuestions()
    {
        List<TriviaQuestion> myList = QuestionStorage.ViewAllQuestions();

        for(int i = 0; i <= myList.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {myList[i].questionText}");
        }
        return myList;
    }
    
    public static TriviaQuestion RandomQuestion()
    {
        List<TriviaQuestion> allQuestions = QuestionStorage.ViewAllQuestions();

        Random rand = new();
        TriviaQuestion selectedQuestion = allQuestions[rand.Next(0,allQuestions.Count())];

        return selectedQuestion;
    }
    
}