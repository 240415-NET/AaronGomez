public interface IQuestionStorageRepo
{
    public void StoreQuestion(TriviaQuestion question);
    public List<TriviaQuestion> ViewAllQuestions();
    public void DeleteQuestion(TriviaQuestion question);

}