using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using HuffmanCode.Helper;

namespace HuffmanCode
{
    class Program
    {
        static void Main(string[] args)
        {
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


            Console.WriteLine($"Nombre de caractere dans le fichier Alice : {fileBuilder.CounterChar($"{prexPath}Alice.txt")}");
            Console.WriteLine($"Nombre de caractere dans le fichier Output : {fileBuilder.CounterChar($"{prexPath}Output.txt")}");


            Dictionary<char, string> ee = new Dictionary<char, string>();
            ee.Add('A', "1");
            ee.Add('a', "11");
            ee.Add('e', "0");
            ee.Add('i', "100");
            ee.Add('o', "111");
            ee.Add('u', "011");
            ee.Add(' ', "101");



            //******************************************************************************************************************
            //  2.4 f - Écrire une fonction qui traduit un texte en une suite binaire basée sur un dictionnaire de Huffman.
            //*******************************************************************************************************************
            // Création du chronomètre.
            Stopwatch stopwatch = new Stopwatch();

            // Démarrage du chronomètre.
            stopwatch.Start();

            Console.WriteLine(fileBuilder.TranslateContentToBinByHuffMan(ee, $"{prexPath}Alice.txt"));

            stopwatch.Stop();
            Console.WriteLine("Durée d'exécution 2.4 f : {0} sec.", stopwatch.Elapsed.TotalSeconds);

            //*******************************************************************************************************************************************************************
            //  2.4 g - Écrire une fonction qui compresse un fichier texte. Le fichier d’entrée ne sera pas modifié, un autre fichier, contenant le texte compressé sera créé.
            //*******************************************************************************************************************************************************************
            bool isCompresse = fileBuilder.FileCompresse($"{prexPath}Alice.txt", $"{prexPath}Output2.txt", ee);
            if (isCompresse)
            {
                Console.WriteLine("Compresse Succes !!");
            }
            else
            {
                Console.WriteLine("Compresse Failed !!");
            }

            Console.ReadLine();
            TreeBuilder builder = new TreeBuilder();

        }

    }
}
