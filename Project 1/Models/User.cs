
public class User
{
    public Guid userId {get; set;}
    public string? userName {get; set;}
    public User()
    {}

    public User(string _userName){
        userId = Guid.NewGuid(); //This creates a random Guid for us, without us having to worry about it
        userName = _userName;
    }

}