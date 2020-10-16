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
            string prexPath = "HuffmanCode/Assert/";

            TreeBuilder builder = new TreeBuilder();
            var fileOccurencies = File.ReadAllText($"{prexPath}Alice.txt");

            var r = a.GuessNumberOfOccurenciesWithDictionnary(fileOccurencies);

            Node res = builder.BuildTree(r);
            Console.ReadLine();


            FileBuilder fileBuilder = new FileBuilder();
            string contentBin = fileBuilder.FileTobin($"{prexPath}Alice.txt");
            if (fileBuilder.CreateFile($"{prexPath}Output.txt", contentBin))
            {
                Console.WriteLine("Sauvegarder !!!");
            }


            Console.WriteLine($"Nombre de caractere dans le fichier Alice : {fileBuilder.CounterChar($"{prexPath}Alice.txt")}");
            Console.WriteLine($"Nombre de caractere dans le fichier Output : {fileBuilder.CounterChar($"{prexPath}Output.txt")}");

            var dict = new Dictionary<char, string>();
            dict = TreeBuilder.ReadNodeToDictionnary(res, "", dict);

            fileBuilder.DictoToFiles(dict, $"{prexPath}Dico.txt");
            var dictOfFiles = fileBuilder.FilesToDicto($"{prexPath}Dico.txt");


            Debug.Assert(dictOfFiles.Count == dict.Count);
            //******************************************************************************************************************
            //  2.4 f - Écrire une fonction qui traduit un texte en une suite binaire basée sur un dictionnaire de Huffman.
            //*******************************************************************************************************************
            // Création du chronomètre.
            Stopwatch stopwatch = new Stopwatch();

            // Démarrage du chronomètre.
            stopwatch.Start();

            Console.WriteLine(fileBuilder.TranslateContentToBinByHuffMan(dictOfFiles, $"{prexPath}Alice.txt"));

            stopwatch.Stop();
            Console.WriteLine("Durée d'exécution 2.4 f : {0} sec.", stopwatch.Elapsed.TotalSeconds);

            //*******************************************************************************************************************************************************************
            //  2.4 g - Écrire une fonction qui compresse un fichier texte. Le fichier d’entrée ne sera pas modifié, un autre fichier, contenant le texte compressé sera créé.
            //*******************************************************************************************************************************************************************
            bool isCompresse = fileBuilder.FileCompresse($"{prexPath}Alice.txt", $"{prexPath}Output2.txt", dictOfFiles);
            if (isCompresse)
            {
                Console.WriteLine("Compresse Succes !!");
                Console.WriteLine($"Nombre de caractere dans le fichier Output2 : {fileBuilder.CounterChar($"{prexPath}Output2.txt")}");
            }
            else
            {
                Console.WriteLine("Compresse Failed !!");
            }

            stopwatch = new Stopwatch();
            stopwatch.Start();
            bool isDecompresse = fileBuilder.FileDecompresse(dictOfFiles, $"{prexPath}Output3.txt", $"{prexPath}Output2.txt");
            stopwatch.Stop();
            Console.WriteLine("Durée d'exécution Decompress : {0} sec.", stopwatch.Elapsed.TotalSeconds);

            if (isDecompresse)
            {
                Console.WriteLine("Decompresse Succes !!");
            }
            else
            {
                Console.WriteLine("Decompresse Failed !!");
            }



        }

    }
}
