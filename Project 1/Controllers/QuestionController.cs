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
    
    public static TriviaQuestion ModifyQuestion(TriviaQuestion question)
    {
        TriviaQuestion modifiedQuestion = new();
        Console.WriteLine($"The current question is {question.questionText}?");
        Console.WriteLine("Do you want to change the question text?");
        Console.WriteLine("Enter 'Y' to change or 'N' to leave the same.");
        try{
        char userEntry = Char.ToUpper(Convert.ToChar(Console.ReadKey()));
        if(userEntry=='Y')
        {
            Console.WriteLine("Enter the updated question");
            modifiedQuestion.questionText = Console.ReadLine();
        }
        else if(userEntry=='N')
        {
            modifiedQuestion.questionText = question.questionText;
        }
        }
        catch
        {
            Console.WriteLine("Please enter 'Y' or 'N'");
        }
        Console.WriteLine($"The current correct answer is {question.correctAnswer}?");
        Console.WriteLine("Do you want to change the question text?");
        Console.WriteLine("Enter 'Y' to change or 'N' to leave the same.");
        try{
        char userEntry = Char.ToUpper(Convert.ToChar(Console.ReadKey()));
        if(userEntry=='Y')
        {
            Console.WriteLine("Enter the correct answer as an integer");
            modifiedQuestion.correctAnswer = Convert.ToInt32(Console.ReadLine().Trim());
        }
        else if(userEntry=='N')
        {
            modifiedQuestion.correctAnswer = question.correctAnswer;
        }
        }
        catch
        {
            Console.WriteLine("Please enter 'Y' or 'N'");
        }

        Console.WriteLine($"The current unit for the answer is {question.unit}?");
        Console.WriteLine("Do you want to change the unit?");
        Console.WriteLine("Enter 'Y' to change or 'N' to leave the same.");
        try{
        char userEntry = Char.ToUpper(Convert.ToChar(Console.ReadKey()));
        if(userEntry=='Y')
        {
            Console.WriteLine("Enter the updated question");
            modifiedQuestion.unit = Console.ReadLine();
        }
        else if(userEntry=='N')
        {
            modifiedQuestion.unit = question.unit;
        }
        }
        catch
        {
            Console.WriteLine("Please enter 'Y' or 'N'");
        }
        QuestionStorage.DeleteQuestion(question);
        QuestionStorage.StoreQuestion(modifiedQuestion);
        return modifiedQuestion;
    }
}