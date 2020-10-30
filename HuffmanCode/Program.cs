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
            Stopwatch stopwatchglob = new Stopwatch();

            stopwatchglob.Start();

            Occurencies a = new Occurencies();
            string prexPath = "../../../HuffmanCode/Assert/";

            TreeBuilder builder = new TreeBuilder();
            var fileOccurencies = File.ReadAllText($"{prexPath}input.txt");

            var r = a.GuessNumberOfOccurenciesWithDictionnary(fileOccurencies);

            Node res = builder.BuildTree(r);

            FileBuilder fileBuilder = new FileBuilder();
            string contentBin = fileBuilder.FileTobin($"{prexPath}input.txt");
            fileBuilder.CreateFile($"{prexPath}Output.txt", contentBin);
           
            using (StreamWriter file = new StreamWriter($"{prexPath}Dico.txt"))
            {
                TreeBuilder.ReadNodeToDictionnary(res, "", file);
                file.Close();
            }

            //Old way 
            //fileBuilder.DictoToFiles(dict, $"{prexPath}Dico.txt");
            var dictOfFiles = fileBuilder.FilesToDicto($"{prexPath}Dico.txt");


            //Debug.Assert(dictOfFiles.Count == dict.Count);
            //******************************************************************************************************************
            //  2.4 f - Écrire une fonction qui traduit un texte en une suite binaire basée sur un dictionnaire de Huffman.
            //*******************************************************************************************************************
            // Création du chronomètre.
            //Stopwatch stopwatch = new Stopwatch();
            // Démarrage du chronomètre.
            //stopwatch.Start();
           // fileBuilder.TranslateContentToBinByHuffMan(dictOfFiles, $"{prexPath}Alice.txt");
            //stopwatch.Stop();
            //Console.WriteLine("Durée d'exécution 2.4 f : {0} sec.", stopwatch.Elapsed.TotalSeconds);

            //stopwatch = new Stopwatch();
            // Démarrage du chronomètre pour le replace
            //stopwatch.Start();
            //fileBuilder.TranslateContentToBinByHuffManReplace(dictOfFiles, $"{prexPath}input.txt");
            //stopwatch.Stop();
            //Console.WriteLine("Durée d'exécution replace : {0} sec.", stopwatch.Elapsed.TotalSeconds);

            //*******************************************************************************************************************************************************************
            //  2.4 g - Écrire une fonction qui compresse un fichier texte. Le fichier d’entrée ne sera pas modifié, un autre fichier, contenant le texte compressé sera créé.
            //*******************************************************************************************************************************************************************

            Stopwatch CompresseTime = new Stopwatch();

            CompresseTime.Start();
            bool isCompresse = fileBuilder.FileCompresse($"{prexPath}input.txt", $"{prexPath}Output2.txt", dictOfFiles);
            CompresseTime.Stop();
            Console.WriteLine($"Compresse TIme {CompresseTime.Elapsed.TotalSeconds}");

            if (isCompresse)
            {
                //Console.WriteLine("Compresse Succes !!");
                Console.WriteLine($"Nombre de caractere dans le fichier Output2 : {fileBuilder.CounterChar($"{prexPath}Output2.txt")}");
            }
            else
            {
                //Console.WriteLine("Compresse Failed !!");
            }


            //stopwatch = new Stopwatch();
            //stopwatch.Start();
            Stopwatch DeCompresseTime = new Stopwatch();

            DeCompresseTime.Start();
            bool isDecompresse = fileBuilder.FileDecompresse(dictOfFiles, $"{prexPath}Output3.txt", $"{prexPath}Output2.txt");
            DeCompresseTime.Stop();
            Console.WriteLine($"DeCompresse TIme {DeCompresseTime.Elapsed.TotalSeconds}");
            //stopwatch.Stop();
            //Console.WriteLine("Durée d'exécution Decompress : {0} sec.", stopwatch.Elapsed.TotalSeconds);

            if (isDecompresse)
            {
                //Console.WriteLine("Decompresse Succes !!");
            }
            else
            {
                Console.WriteLine("Decompresse Failed !!");
            }


            stopwatchglob.Stop();
            Console.WriteLine("Durée d'exécution TOTAAAAAAL : {0} sec.", stopwatchglob.Elapsed.TotalSeconds);

            Console.ReadLine();

        }

    }
}
