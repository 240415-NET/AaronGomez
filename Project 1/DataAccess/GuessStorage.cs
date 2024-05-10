using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Linq;

public class GuessStorage ()
{
    public static string filePath = "GuessesFile.json";
    public static void StoreGuess(Guess guess)
    {   
            string existingGuesses = File.ReadAllText(filePath);

            List<Guess> existingGuessesList = JsonSerializer.Deserialize<List<Guess>>(existingGuesses);

            //If loop if you already have a guess for the same trivia question
            existingGuessesList.Add(guess);

            string jsonExistingUsersListString = JsonSerializer.Serialize(existingGuessesList);

            File.WriteAllText(filePath, jsonExistingUsersListString);
    }



    public static bool FindGuess(Guid userId, Guid guessToFind)
    {
        //Guess foundGuess = new(userId, guessToFind);

        try{
            string existingGuessesString = File.ReadAllText(filePath);

            List<Guess> existingUsersList = JsonSerializer.Deserialize<List<Guess>>(existingGuessesString);

            Guess foundGuess = existingUsersList.FirstOrDefault(guess => guess.questionId == guessToFind);

            if (foundGuess==null)
            return false;
            else
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return false;

    }

public static List<Guess> CompareGuess(Guid guessToFind)
    {
        //Guess foundGuess = new(guessToFind);

        try{
            string existingGuessesString = File.ReadAllText(filePath);

            List<Guess> existingGuesses = JsonSerializer.Deserialize<List<Guess>>(existingGuessesString);

            List<Guess> relevantGuesses = new();

            int sumGuesses = 0;
            foreach(var q in existingGuesses)
            {
                if(q.questionId == guessToFind)
                relevantGuesses.Add(q);
                sumGuesses += q.guessText;
            }
            //Do comparisons here and return them?
            int numberOfGuesses = relevantGuesses.Count();
            int averageGuess = sumGuesses/relevantGuesses.Count();

            return relevantGuesses;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            List<Guess> emptyList = new();
            return emptyList;
        }
    }

}