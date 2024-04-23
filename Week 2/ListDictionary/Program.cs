namespace ListDictionary;

class Program
{
    static void Main(string[] args)
    {
        List<string> myList = new List<string>();

        myList.Add("joe");
        myList.Add("Fred");
        Console.WriteLine(myList.Count());

        //myList.Find("James");
        foreach(string name in myList)
        {
            Console.WriteLine(name);
        }

        //myList.foreach(Console.WriteLine(name));

        Dictionary<string, List<string>> petDictionary = new();
        petDictionary.Add("Jonathan", new List<string>(){"Pancake", "Ellie"});
        petDictionary.Add("Ross", new List<string>(){"Brody"});
        petDictionary.Add("Adam", myList);
        //Console.WriteLine(petDictionary);

        /*foreach(KeyValuePair<string, List<string>> Key in petDictionary)
        {
            Console.WriteLine(Key);
            
        }*/

        /*Dictionary<string, string> petDictionary = new();
        petDictionary.Add("Jonathan", "Pancake");
        petDictionary.Add("Ross", "Brody");
        petDictionary.Add("Mike", "Carl");

        foreach(var owner in petDictionary)
        {
            Console.WriteLine(owner.GetType());
            Console.WriteLine(owner.Key +" owns " + pet.Value);
        }*/

        

        /*foreach(KeyValuePair<string, List<string>> Value in petDictionary)
        {
            Console.WriteLine( petDictionary.Key);
            foreach(var pets in petDictionary.Values)
            {
                Console.WriteLine(pets);
            }
        }*/

        foreach(var owner in petDictionary)
        {
            //Console.WriteLine(owner);
            //Console.WriteLine(owner.GetType());
            for (int i = 0; i < owner.Value.Count(); i++)
            {
                Console.WriteLine($"{owner.Key} owns {owner.Value[i]}");  
            }  
        }

        

    }
}
