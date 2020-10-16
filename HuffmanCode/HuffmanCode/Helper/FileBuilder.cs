using HuffmanCode.HuffmanCode.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode.Helper
{
    public class FileBuilder
    {
        /// <summary>
        /// EXO 1 - Convertion du contenu d'un fichier en binaire.
        /// </summary>
        /// <param name="Path"></param>
        public string FileTobin(string Path)
        {
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                if (File.Exists(Path))
                {
                    string content = string.Empty;

                    using (StreamReader streamReader = new StreamReader(Path))
                    {
                        content = streamReader.ReadToEnd();
                        streamReader.Close();
                    }

                    foreach (char c in content.ToCharArray())
                    {
                        stringBuilder.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
                    }
                }
            }
            catch (Exception Exception)
            {
            }

            return stringBuilder.ToString();
        }


        /// <summary>
        /// EXO 1 - Création d'un fichier et sauvegarde du contenu
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="content"></param>
        public bool CreateFile(string Path, string content)
        {
            if (!File.Exists(Path))
            {
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(Path, false))
                    {
                        streamWriter.Write(content);
                    }
                }
                catch (Exception Exception)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// EXO 2 - Compter le nombre de caractère dans un fichier.
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public int CounterChar(string Path)
        {
            int size = 0;
            try
            {
                if (File.Exists(Path))
                {
                    string content = string.Empty;

                    using (StreamReader streamReader = new StreamReader(Path))
                    {
                        content = streamReader.ReadLine();
                        size = content.Length;
                        streamReader.Close();
                    }
                }
            }
            catch (Exception Exception)
            {

            }
            return size;
        }

        public string TranslateContentToBinByHuffMan(Dictionary<Char, String> DictionnaryeHuffman, string Path)
        {
            string content = string.Empty;
            try
            {
                if (File.Exists(Path))
                {
                    char[] charArrayContentFile = null;

                    using (StreamReader streamReader = new StreamReader(Path))
                    {
                        charArrayContentFile = (streamReader.ReadToEnd()).ToCharArray();
                        streamReader.Close();
                    }

                    foreach (var charArrayCurrent in charArrayContentFile)
                    {
                        string output = charArrayCurrent.ToString();

                        var isInDictionnary = DictionnaryeHuffman.TryGetValue(charArrayCurrent, out output);

                        content += isInDictionnary == false ? charArrayCurrent.ToString() : output;
                    }
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException);
            }
            return content;
        }


        public bool FileCompresse(string PathFileEnter, string PathFileLeave, Dictionary<Char, String> DictionnaryeHuffman)
        {
            bool isCompresse = false;
            try
            {
                if (File.Exists(PathFileEnter))
                {
                    string binHumanContentFile = TranslateContentToBinByHuffMan(DictionnaryeHuffman, PathFileEnter);

                    isCompresse = this.CreateFile(PathFileLeave, binHumanContentFile);
                }
            }
            catch (Exception eException)
            {
                isCompresse = false;
                Console.WriteLine(eException);
            }
            return isCompresse;
        }
    }
}
