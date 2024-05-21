public class TriviaQuestion
{
    public Guid questionId {get; set;}
    public string? questionText {get; set;}

    public int correctAnswer {get; set;}
    
    public string unit {get; set;}

    // public TriviaQuestion()
    // {
    //     unit="";
    // }

    public TriviaQuestion(string _questionText, int _correctAnswer, string _unit)
    {
        questionId = Guid.NewGuid();
        questionText = _questionText;
        correctAnswer = _correctAnswer;
        unit = _unit;
    }

    public TriviaQuestion(Guid _questionId, string _questionText, int _correctAnswer, string _unit)
    {
        questionId = _questionId;
        questionText = _questionText;
        correctAnswer = _correctAnswer;
        unit = _unit;
    }


    public void ExampleQuestion( )
    {
        questionId = Guid.NewGuid();
        questionText = "How tall is Mount Everest (in Feet)?";
        correctAnswer = 29032;
        unit = "feet";
    }
}