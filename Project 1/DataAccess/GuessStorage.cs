using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Linq;

public class GuessStorage ()
{
    public static string filePath = "GuessesFile.json";
    public static void StoreGuess(Guess guess)
    {   
            string existingGuesses = File.ReadAllText(filePath);

            List<Guess> existingGuessesList = ReadGuesses();

            //If loop if you already have a guess for the same trivia question
            existingGuessesList.Add(guess);

            string jsonGuessesString = JsonSerializer.Serialize(existingGuessesList);

            File.WriteAllText(filePath, jsonGuessesString);


            
    }

    public static List<Guess> ReadGuesses()
    {   
        string existingGuesses = File.ReadAllText(filePath);

        List<Guess> existingGuessesList = JsonSerializer.Deserialize<List<Guess>>(existingGuesses);

        return existingGuessesList;
    }




    public static bool FindGuess(Guid userId, Guid guessToFind)
    {

        try{
            string existingGuessesString = File.ReadAllText(filePath);

            List<Guess> existingGuessesList = JsonSerializer.Deserialize<List<Guess>>(existingGuessesString);
            //Guess foundGuess = new();
            //I need this to check by both userId and guessTofind
            //Guess foundGuess = existingGuessesList.FirstOrDefault(guess => guess.questionId == guessToFind);

            foreach (Guess guess in existingGuessesList){
            if(guess.questionId == guessToFind)
            {
                if(guess.guesserId == userId)
                {
                    //foundGuess = guess;
                    return true;
                }
            }
            }
            return false;

            /*if(foundGuess.guesserId==Guid.Empty)
            return true;
            else
            {
                return false;
            }*/
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return false;

    }

/*public static List<Guess> CompareGuess(Guid guessToFind)
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
    }*/

}