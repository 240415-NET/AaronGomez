using System.Security.Cryptography.X509Certificates;

//Admin Menu
//View all user inputs (from database)
//Possible select the active trivia question

public class Menu
{
   
   //This method displays the initial menu when the user runs the program
   public static User currentUser = new();
    public static void StartMenu() {

        int userChoice = 0;
        bool validInput = true;

        User myUser = new();

        Console.WriteLine("Welcome to TrackMyStuff!");
        Console.WriteLine("1. New user");
        Console.WriteLine("2. Returning user");
        Console.WriteLine("3. Exit program");
        
        //Setting up the try-catch to handle user input with
        //do-while to let them try again
        do
        {
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1: // Creating a new user profile
                        UserCreationMenu(myUser);
                        MainMenu(myUser);
                        break;
                    case 2:
                        UserLoginMenu(myUser);
                        MainMenu(myUser);
                        break;
                    case 3: //User chooses to exit the program
                        return; //This return exits this method, and returns us to where it was called.
                    default: // If the user enters an integer that is not 1, 2, or 3
                        Console.WriteLine("Please enter a valid choice (from the default)!");
                        validInput = false;
                        break;
                }

            }
            catch (Exception ex) 
            {   
                validInput = false;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please enter a valid choice! (from the catch)");
            }

        } while (!validInput);

        
    }

    public static User UserCreationMenu(User myUser) 
    {
        bool validInput = true;
        string userInput = "";

        do
        {   
            Console.WriteLine("Please enter a username: ");

            userInput = Console.ReadLine() ?? "";

            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank, please try again.");
                validInput = false;
            }
            else if(UserController.UserExists(userInput))
            {
                Console.WriteLine("Username already exists, please choose another.");
                validInput = false;
            }
            else
            { 
                UserController.CreateUser(userInput);
                Console.WriteLine("Profile created!");
                validInput = true;
            }

        } while (!validInput); 
        return myUser;

    }

    public static void UserLoginMenu(User currentUser)
    {
        bool exitCondition = false;
        do
        {
            Console.WriteLine("Please enter your username");
            string userInput = (Console.ReadLine()??"").Trim();
            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Please enter a name");
                exitCondition = false;
            }
            else
            {
                currentUser = UserController.GetUser(userInput);
                if (currentUser == null)
                {
                    Console.WriteLine("user not found");
                    exitCondition = false;
                }
                else if (currentUser.userName.ToLower() == "admin")
                {
                    Console.WriteLine($"Welcome back {currentUser.userName}");
                    do
                    {
                    Console.WriteLine("Please enter your admin password");
                    try
                    {
                    string? adminPassword = Console.ReadLine();
                    if (adminPassword == "admin")
                    {
                        AdminMenu(currentUser);
                        exitCondition = true;
                    }
                    else
                    {
                        Console.WriteLine("That was the wrong password. Please try again");
                    }
                    }
                    catch
                    {
                        Console.WriteLine("I didn't understand");
                    }
                    }
                    while (!exitCondition);

                }
                else
                {
                    Console.WriteLine($"Welcome back, {currentUser.userName}!");
                    //return currentUser;
                    exitCondition = true;
                }
            }
        }while(!exitCondition);
    }

    public static void MainMenu(User myUser)
    {
        bool validInput = true;
  
        do
        {
            Console.WriteLine("1. Answer a Trivia Question");
            Console.WriteLine("2. Exit program");
            try
            {
                int userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1: // Answer a Trivia Question
                        //Call QuestionController to set Trivia Question
                        TriviaQuestion chosenQuestion = new();
                        chosenQuestion = QuestionController.RandomQuestion();
                        /*do
                        {
                        
                        }
                        while(QuestionController.QuestionAnswered(myUser, chosenQuestion) ==true)*/
                        ;
                        //TriviaQuestion chosenQuestion = new TriviaQuestion("How tall is Mount Everest (in Feet)?", 29032, "feet");
                        Console.WriteLine(chosenQuestion.questionText);
                        GuessController.MakeGuess(myUser, chosenQuestion);
                        //MainMenu(myUser);
                        return;
                    case 2: //User chooses to exit the program
                        return; //This return exits this method, and returns us to where it was called.
                    default: // If the user enters an integer that is not 1, 2, or 3
                        Console.WriteLine("Please select one of the menu options");
                        validInput = false;
                        break;
                }

            }
            catch
            {   
                validInput = false;
                Console.WriteLine("Please enter an integer");
            }

        } while (!validInput);
        return;
    
    } 

    public static void AdminMenu(User myUser)
    {
        bool validInput = true;
  
        do
        {
            Console.WriteLine("1. Add a Trivia Question");
            Console.WriteLine("2. Modify a Trivia Question");
            Console.WriteLine("3. Delete a Trivia Question");
            Console.WriteLine("4. Return to the Main Menu");
            //Console.WriteLine("5. Exit program");
            try
            {
                int userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1: //Add a TriviaQuestion
                        //Call QuestionController to set Trivia Question
                        Console.WriteLine("What is the new Trivia Question?");
                        string questionText = Console.ReadLine();
                        Console.WriteLine("What is the correct answer?");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("What unit is the answer in?");
                        string unit = Console.ReadLine();
                        QuestionController.CreateQuestion(questionText, answer, unit);
                        //MainMenu(myUser);
                        return;
                    case 2: //ModifyQuestion method needed
                        Console.WriteLine("Select a question to modify?");
                        List<TriviaQuestion> myList = QuestionController.DisplayAllQuestions();
                        int selectedQuestion = Convert.ToInt32(Console.ReadLine());
                        QuestionController.DeleteQuestion(myList[selectedQuestion]);
                        return; 
                    case 3: //DeleteQuestion method needed
                        Console.WriteLine("Select a question to remove");
                        QuestionController.DisplayAllQuestions();
                        Console.ReadLine();
                        return;
                    case 4: //Return to Main Menu
                        MainMenu(myUser);
                        return;
                    //case 5: //User chooses to exit the program
                        //return;
                    default: // If the user enters an integer that is not 1, 2, or 3
                        Console.WriteLine("Please select one of the menu options");
                        validInput = false;
                        break;
                }
            }
            catch
            {   
                validInput = false;
                Console.WriteLine("Please enter an integer");
            }

        } while (!validInput);
        return;
    } 
}