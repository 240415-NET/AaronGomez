public class GuessController
{
    public static IGuessStorageRepo _guessData = new SqlGuessStorage();
    public static void MakeGuess(User currentUser, TriviaQuestion currentQuestion)
    {
        DateTime AnswerStart = DateTime.Now;
        //Add error handling here
        int answer = Convert.ToInt32(Console.ReadLine());

        DateTime AnswerEnd = DateTime.Now;
        TimeSpan answerTime = AnswerEnd - AnswerStart;
        Guess newGuess = new(currentUser.userId, currentQuestion.questionId, answer, answerTime);

        Console.WriteLine($"You guessed {answer} {currentQuestion.unit}");
        Console.WriteLine($"The correct answer was {currentQuestion.correctAnswer} {currentQuestion.unit}");
        string formattedTime = string.Format("{0:mm\\:ss}", newGuess.guessTime);
        Console.WriteLine($"You answered in {formattedTime} seconds");

        List<Guess> existingGuesses = _guessData.ReadGuesses();

        List<Guess> relevantGuesses = new();


        foreach (var g in existingGuesses)
        {
            if (g.questionId == newGuess.questionId)
            {
                relevantGuesses.Add(g);
            }
            //sumGuesses += q.guessText;}
        }
        //Do comparisons here and return them?
        int numberOfGuesses = relevantGuesses.Count();


        if (numberOfGuesses == 0)
        {
            Console.WriteLine("There is no one to compare you too.");
        }
        else
        {
            int sumGuesses = newGuess.guessText;


            Console.WriteLine($"{relevantGuesses.Count} other people answered this question");

            int distanceFromCorrectAnswer = Math.Abs(currentQuestion.correctAnswer - newGuess.guessText);
            int countCloserThan = 0;
            int countFasterThan = 0;
            foreach (var q in relevantGuesses)
            {
                //if(q.questionId == newGuess.questionId)
                sumGuesses += q.guessText;
                if (Math.Abs(q.guessText - currentQuestion.correctAnswer) > distanceFromCorrectAnswer)
                    countCloserThan += 1;
                //This is never finding a slower guess
                if (TimeSpan.Compare(q.guessTime, newGuess.guessTime) == 1)
                {
                    countFasterThan += 1;
                }
                /*if(q.guessTime < newGuess.guessTime)
                countFasterThan+=1;*/
            }
            int averageGuess = sumGuesses / relevantGuesses.Count;

            
            Console.WriteLine($"Your answer was closer than {countCloserThan} other guessers.");

            if (countFasterThan == relevantGuesses.Count)
            Console.WriteLine("You are the fastest person to ever answer this question.");
            else if (countFasterThan == 0)
            Console.WriteLine("You took the longest of anyone to ever answer this question.");
            else
            Console.WriteLine($"You answered faster than {countFasterThan / numberOfGuesses} other guessers.");
        }
        _guessData.StoreGuess(newGuess);
        Console.WriteLine("---------------------------------");
        return;
    }


    public static bool FindGuess(User currentUser, TriviaQuestion currentQuestion)
    {
        return _guessData.FindGuess(currentUser.userId, currentQuestion.questionId);
    }

    public static List<Guess> ReadGuesses()
    {
        return _guessData.ReadGuesses();
    }
}