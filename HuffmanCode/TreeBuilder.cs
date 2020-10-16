using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HuffmanCode
{
    public class TreeBuilder
    {
        List<OccurenceItem> Occurences = new List<OccurenceItem>();

        TreeBuilder()
        {
            Occurences.Add(new OccurenceItem()
            {
                Letter = 't',
                Occurences = 1
            });
            Occurences.Add(new OccurenceItem()
            {
                Letter = 'a',
                Occurences = 1
            });
            Occurences.Add(new OccurenceItem()
            {
                Letter = 's',
                Occurences = 3
            });
            Occurences.Add(new OccurenceItem()
            {
                Letter = 'e',
                Occurences = 1
            });
        }

        public void BuildTree(List<OccurenceItem> List)
        {
            Node tree = null;
            foreach (OccurenceItem item in List)
            {
                if (tree == null)
                {
                    tree = new Node();
                }
                else
                {

                }
            }
        }


        public static Dictionary<char,string> ReadNodeToDictionnary( Node node, string bit, Dictionary<char, string> dict )
        {
            if (node == null)
            {
                return dict;
            }

            if (node.Letter != '\0')
            {
                dict.Add(node.Letter, bit);
            }

            if (node.ChildLeft != null)
            {
                bit = bit  + "0";
                dict = ReadNodeToDictionnary(node.ChildLeft,bit,dict);
                bit = bit.Remove(bit.Length - 1);
            }

            if (node.ChildRight != null)
            {
                bit = bit + "1";
                dict = ReadNodeToDictionnary(node.ChildRight, bit, dict);
            }

            return dict;

        }

    }

    public class OccurenceItem
    {
        public char Letter;
        public int Occurences; 
    }

    public class Node : OccurenceItem
    {
        public Node ChildLeft;
        public Node ChildRight;
    }
}
