using System;
using System.Collections.Generic;
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



            Node node = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();
            Node node7 = new Node();
            Node node8 = new Node();
            Node node9 = new Node();
            Node node10 = new Node();
            Node node11 = new Node();
            Node node12 = new Node();
            Node node13 = new Node();
            Node node14 = new Node();
            Node node15 = new Node();

            node2.Letter = 'E';
            node6.Letter = 'U';
            node7.Letter = 'D';
            node8.Letter = 'L';
            node10.Letter = 'C';
            node13.Letter = 'M';
            node14.Letter = 'Z';
            node15.Letter = 'K';

            node.ChildLeft = node2;
            node.ChildRight = node3;

            node3.ChildLeft = node4;
            node3.ChildRight = node5;

            node4.ChildLeft = node6;
            node4.ChildRight = node7;

            node5.ChildLeft = node8;
            node5.ChildRight = node9;

            node9.ChildLeft = node10;
            node9.ChildRight = node11;

            node11.ChildRight = node13;
            node11.ChildLeft = node12;

            node12.ChildRight = node15;
            node12.ChildLeft = node14;


            var dict = new Dictionary<char, string>();

             dict = TreeBuilder.ReadNodeToDictionnary(node, "", dict);

        }

    }
}
