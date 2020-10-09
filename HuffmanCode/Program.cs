using System;
using System.IO;

namespace HuffmanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Occurencies a = new Occurencies();

            var fileOccurencies = File.ReadAllText(Directory.GetCurrentDirectory() + "/TestOccurencies.txt");

            a.GuessNumberOfOccurenciesWithDictionnary(fileOccurencies);

            foreach (var item in a.GuessNumberOfOccurenciesWithDictionnary(fileOccurencies))
            {
                Console.WriteLine(item.Key.ToString() + ":" + item.Value.ToString());

            }

        }

    }
}
