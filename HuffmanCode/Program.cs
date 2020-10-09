using System;
using System.IO;
﻿using HuffmanCode.Helper;

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

            FileBuilder fileBuilder = new FileBuilder();
            string prexPath = "HuffmanCode/Assert/";
            string contentBin = fileBuilder.FileTobin($"{prexPath}Alice.txt");
            if (fileBuilder.CreateFile($"{prexPath}Output.txt", contentBin))
            {
                Console.WriteLine("Sauvegarder !!!");
            }

            Console.WriteLine(fileBuilder.CounterChar($"{prexPath}Alice.txt"));
            Console.WriteLine(fileBuilder.CounterChar($"{prexPath}Output.txt"));
            Console.ReadLine();
        }

    }
}
