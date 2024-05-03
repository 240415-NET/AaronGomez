public class Guess
{
    //guesserId ties to userId in User
    int guesserId {get; set;}
    //questionId ties to TriviaQuestion questionId
    int questionId {get; }
    float guess {get; set;}
}