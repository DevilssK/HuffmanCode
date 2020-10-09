using System;
using System.Collections.Generic;
using System.IO;
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
    }
}
