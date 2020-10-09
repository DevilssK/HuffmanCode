using HuffmanCode.Helper;
using System;

namespace HuffmanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            FileBuilder fileBuilder = new FileBuilder();
            string prexPath = @"../../../Assert/";
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
