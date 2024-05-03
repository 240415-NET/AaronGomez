Create a console application where users answer a trivia question and see how close their answer was compared to other's answers.

Data Model
User
-userId (int)
-userName (string)
-password (string) //Extra Functionality

Guess
-int guesserId (referencing userId)
-guess (float)



Possible Extensions of the Project
Admin - extends User base class
//Ability to select the Question

Question
-int questionId
-string questionText