public class QuestionController
{
    public static IQuestionStorageRepo _questionData = new QuestionStorage();
    public static void CreateQuestion(string questionText, int answer, string unit)
    {

        TriviaQuestion newQuestion = new(questionText, answer, unit);
        _questionData.StoreQuestion(newQuestion);
    }

    // public static bool QuestionAnswered(User currentUser, TriviaQuestion currentQuestion)
    // {
    //     bool GuessFound = GuessController.FindGuess(currentUser, currentQuestion);
    //     return GuessFound;
    // }

    public static void DeleteQuestion(TriviaQuestion question)
    {
        _questionData.DeleteQuestion(question);

    }

    public static List<TriviaQuestion> DisplayAllQuestions()
    {
        List<TriviaQuestion> myList = _questionData.ViewAllQuestions();

        for(int i = 0; i <= myList.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {myList[i].questionText}");
        }
        return myList;
    }

    public static TriviaQuestion PickAQuestion(User currentUser)
    {
        List<TriviaQuestion> allQuestions = _questionData.ViewAllQuestions();
        List<TriviaQuestion> unansweredQuestions = new();

        for(int i = 0; i <= allQuestions.Count(); i++)
        {  
            // if(QuestionAnswered(currentUser, allQuestions[i])==false)
            // {
            //     unansweredQuestions.Add(allQuestions[i]);
            // }
            
        }
        Random rand = new();
        TriviaQuestion selectedQuestion = unansweredQuestions[rand.Next(0,unansweredQuestions.Count())];

        return selectedQuestion;
    }
    
    public static TriviaQuestion RandomQuestion()
    {
        List<TriviaQuestion> allQuestions = _questionData.ViewAllQuestions();

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
        _questionData.DeleteQuestion(question);
        _questionData.StoreQuestion(modifiedQuestion);
        return modifiedQuestion;
    }
}