public class Guess
{
    //guesserId ties to userId in User
    public Guid guesserId {get; set;}
    //questionId ties to TriviaQuestion questionId
    public Guid questionId {get; set;}

    public int guessText{get; set;}
    public TimeSpan guessTime {get; set;}

    public Guess()
    {}

    public Guess(Guid _userId, Guid _questionId, int _guessText, TimeSpan _guessTime){
        guesserId = _userId;
        questionId = _questionId;
        guessText = _guessText;
        guessTime = _guessTime;
    }
}