namespace StringPractice;

class Program
{
    static void Main(string[] args)
    {
        int[] grades = {97, 93, 100, 85};

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(grades[i]);
        }

        string[] names = {"bob", "george", "jane"};
        foreach(string name in names)
        {
            Console.WriteLine(name);
        }

        string new_word = Console.ReadLine().ToLower();
        Console.WriteLine(new_word.ToUpper());

        foreach(char c in new_word)
        {
            Console.WriteLine(c);
        }


        /*int x = Int32.TryParse(Console.ReadLine());
        int[] ages = new int[x];

        ages[0] = 38;
        ages[1] = 44;

        foreach(int age in ages)
        {
            Console.WriteLine(age);
        }
        grades[2] = 45;*/

        foreach(int grade in grades)
        {
            Console.WriteLine(grade);
        }
    }
}

/*class Student
{
    char Grade (Get; Set; )
}*/