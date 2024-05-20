public interface IGuessStorageRepo
{
    public void StoreGuess(Guess guess);

    public List<Guess> ReadGuesses();

    public bool FindGuess(Guid userId, Guid guessToFind);
}