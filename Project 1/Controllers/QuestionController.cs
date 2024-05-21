public class QuestionController
{
    public static IQuestionStorageRepo _questionData = new SqlQuestionStorage();
    public static void CreateQuestion(string questionText, int answer, string unit)
    {

        TriviaQuestion newQuestion = new(questionText, answer, unit);
        _questionData.StoreQuestion(newQuestion);
    }

    public static bool QuestionAnswered(User currentUser, TriviaQuestion currentQuestion)
    {
        return GuessController.FindGuess(currentUser, currentQuestion);
    }

    public static void StoreQuestion(TriviaQuestion question)
    {
        _questionData.StoreQuestion(question);

    }

    public static void DeleteQuestion(TriviaQuestion question)
    {
        _questionData.DeleteQuestion(question);

    }

    public static List<TriviaQuestion> DisplayAllQuestions()
    {
        List<TriviaQuestion> myList = _questionData.ViewAllQuestions();

        for(int i = 0; i < myList.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {myList[i].questionText}");
        }
        return myList;
    }

    public static TriviaQuestion PickAQuestion(User currentUser)
    {
        List<TriviaQuestion> allQuestions = _questionData.ViewAllQuestions();
        List<TriviaQuestion> unansweredQuestions = new();

        for(int i = 0; i < allQuestions.Count(); i++)
        {  
            if(QuestionAnswered(currentUser, allQuestions[i])==false)
            {
                unansweredQuestions.Add(allQuestions[i]);
            }
            
        }
        if(unansweredQuestions.Count()>0)
        {
        Random rand = new();
        TriviaQuestion selectedQuestion = unansweredQuestions[rand.Next(0,unansweredQuestions.Count())];
        return selectedQuestion;
        }
        else
        {
            return null;
        }
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
        string modifiedQuestionText = "";
        int modifiedCorrectAnswer = 0;
        string modifiedUnit = "";
        bool validInput = false;
        Console.WriteLine($"The current question is {question.questionText}?");
        Console.WriteLine("Do you want to change the question text?");
        Console.WriteLine("Enter 'Y' to change or 'N' to leave the same.");
        do
        {
        try{
        char userEntry = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
        if(userEntry=='Y')
        {
            Console.WriteLine("Enter the updated question");
            modifiedQuestionText = Console.ReadLine();
            validInput = true;
        }
        else if(userEntry=='N')
        {
            modifiedQuestionText = question.questionText;
            validInput = true;
        }
        }
        catch
        {
            Console.WriteLine("Please enter 'Y' or 'N'");
        }
        }
        while(!validInput);

        validInput = false;

        do 
        {
        Console.WriteLine($"The current correct answer is {question.correctAnswer}?");
        Console.WriteLine("Do you want to change the question text?");
        Console.WriteLine("Enter 'Y' to change or 'N' to leave the same.");
        try{
        char userEntry = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
        if(userEntry=='Y')
        {
            Console.WriteLine("Enter the correct answer as an integer");
            modifiedCorrectAnswer = Convert.ToInt32(Console.ReadLine().Trim());
            validInput = true;
        }
        else if(userEntry=='N')
        {
            modifiedCorrectAnswer = question.correctAnswer;
            validInput = true;
        }
        }
        catch
        {
            Console.WriteLine("Please enter 'Y' or 'N'");
        }
        }
        while (!validInput);

        validInput = false;

        do
        {
        Console.WriteLine($"The current unit for the answer is {question.unit}?");
        Console.WriteLine("Do you want to change the unit?");
        Console.WriteLine("Enter 'Y' to change or 'N' to leave the same.");
        try{
        char userEntry = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
        if(userEntry=='Y')
        {
            Console.WriteLine("Enter the updated question");
            modifiedUnit = Console.ReadLine();
            validInput = true;
        }
        else if(userEntry=='N')
        {
            modifiedUnit = question.unit;
            validInput = true;
        }
        }
        catch
        {
            Console.WriteLine("Please enter 'Y' or 'N'");
        }
        }
        while(!validInput);

        TriviaQuestion modifiedQuestion = new(modifiedQuestionText, modifiedCorrectAnswer, modifiedUnit);
        _questionData.DeleteQuestion(question);
        _questionData.StoreQuestion(modifiedQuestion);
        return modifiedQuestion;
    }
}