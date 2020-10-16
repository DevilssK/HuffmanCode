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
            //TreeBuilder builder = new TreeBuilder();

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


            Node node2 = new Node(null, null, 0, 'a');
            Node node6 = new Node(null, null, 0, 'i');
            Node node7 = new Node(null, null, 0, 'o');
            Node node8 = new Node(null, null, 0, 'l');
            Node node10 = new Node(null, null, 0, 'C');
            Node node14 = new Node(null, null, 0, 'Z');
            Node node15 = new Node(null, null, 0, 'K');
            Node node13 = new Node(null, null, 0, 'M');
            Node node4 = new Node(node6, node7, 0, '\0');
            Node node12 = new Node(node14, node15, 0, '\0');
            Node node11 = new Node(node12, node13, 0, '\0');
            Node node9 = new Node(node10, node11, 0, '\0');
            Node node5 = new Node(node8, node9, 0, '\0');
            Node node3 = new Node(node4, node5, 0, '\0');
            Node node = new Node(node2, node3, 0, '\0');

            var dict = new Dictionary<char, string>();
            dict = TreeBuilder.ReadNodeToDictionnary(node, "", dict);

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

            bool isDecompresse = fileBuilder.FileDecompresse(dictOfFiles, $"{prexPath}Output3.txt",$"{prexPath}Output2.txt" );
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
