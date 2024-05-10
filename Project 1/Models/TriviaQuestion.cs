public class TriviaQuestion
{
    public Guid questionId {get; set;}
    public string? questionText {get; set;}

    public int correctAnswer {get; set;}
    
    public string unit {get; set;}

    public TriviaQuestion()
    {
        unit="";
    }

    public TriviaQuestion(string _questionText, int _correctAnswer, string _unit)
    {
        questionText = _questionText;
        correctAnswer = _correctAnswer;
        unit = _unit;
    }

    public void ExampleQuestion( )
    {
        questionText = "How tall is Mount Everest (in Feet)?";
        correctAnswer = 29032;
        unit = "feet";
    }
}