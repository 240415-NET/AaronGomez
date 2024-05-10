public class GuessController
{
    public static void MakeGuess(User currentUser, TriviaQuestion currentQuestion)
    {
        DateTime AnswerStart = DateTime.Now;
        int answer = 0;
        try{
            answer = Int32.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Please enter a number");
        }
        DateTime AnswerEnd = DateTime.Now;
        TimeSpan answerTime = AnswerEnd - AnswerStart;
        Guess newGuess = new(currentUser.userId, currentQuestion.questionId, answer, answerTime);
        //Refactor to add a unit property to trivia question
        //Writeline should probably be in presentation layer
        Console.WriteLine($"You guessed {answer} {currentQuestion.unit}");
        Console.WriteLine($"The correct answer was {currentQuestion.correctAnswer} {currentQuestion.unit}");
        string formattedTime = string.Format("{0:mm\\:ss}", newGuess.guessTime);
        Console.WriteLine($"You answered in {formattedTime} seconds");
        //Add call to data access layer to get comparisons to other guesses for the current trivia question
        List<Guess> myList = GuessStorage.CompareGuess(newGuess.questionId);
        Console.WriteLine($"{myList.Count} other people answered this question");

        int sumGuesses = 0;
        int distanceFromCorrectAnswer = Math.Abs(currentQuestion.correctAnswer - newGuess.guessText);
        int countCloserThan = 0;
        int countFasterThan = 0;
        foreach(var q in myList)
        {
            if(q.questionId == newGuess.questionId)
                sumGuesses += q.guessText;
            if(Math.Abs(q.guessText-currentQuestion.correctAnswer)<distanceFromCorrectAnswer)
                countCloserThan+=1;
            if(q.guessTime < newGuess.guessTime)
            countFasterThan+=1;
        }
        int numberOfGuesses = myList.Count();
        int averageGuess = sumGuesses/numberOfGuesses;

        Console.WriteLine($"Your answer was closer than {countCloserThan} other guessers.");
        Console.WriteLine($"You answered faster than {countFasterThan/numberOfGuesses}% of other guessers.");

        GuessStorage.StoreGuess(newGuess);
        Console.WriteLine("---------------------------------");
        return;
    }
}