namespace IntroClass;

class Program
{
    static void Main(string[] args)
    {
        Dog pancake = new Dog();

        Console.WriteLine(pancake.age);

        //calling an instance method
        pancake.Bark();

        Dog.DefineDog();

        
    }
}
