using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HuffmanCode
{
    public class TreeBuilder
    {
        public   TreeBuilder()
        {

        }

        public Node BuildTree(Dictionary<char,int> List)
        {
            List<Node> NodeList = new List<Node>();

            foreach (var occurence in List)
            {
                NodeList.Add(new Node(null,null,occurence.Value, occurence.Key));

            }

            while (NodeList.Count > 1)
            {

                Node temp = NodeList[0];
                Node temp2 = NodeList[1];
                Node NewNode = new Node(temp, temp2, (temp._item.Occurences + temp2._item.Occurences));
                int newidx = NodeList.FindIndex(0, (e) =>
                  {
                      return e._item.Occurences > NewNode._item.Occurences ? true : false;
                  });
                if (newidx != -1)
                {
                    NodeList.Insert(newidx, NewNode);
                }
                else
                {
                    NodeList.Add(NewNode);
                }
                NodeList.Remove(temp);
                NodeList.Remove(temp2);

            }
            Console.WriteLine(NodeList.Count);
            return NodeList[0];

        }


        public static void ReadNodeToDictionnary( Node node, string bit, StreamWriter file )
        {
            if (node == null)
            {
                return;
            }

            if (node._item.Letter != '\0')
            {
                file.WriteLine("{0} : {1}", node._item.Letter, bit);
            }

            if (node.ChildLeft != null)
            {
                bit = bit  + "0";
                ReadNodeToDictionnary(node.ChildLeft,bit,file);
                bit = bit.Remove(bit.Length - 1);
            }

            if (node.ChildRight != null)
            {
                bit = bit + "1";
                ReadNodeToDictionnary(node.ChildRight, bit, file);
            }

            return;

        }

    }

    public class OccurenceItem
    {
        public char Letter;
        public int Occurences; 
    }

    public class Node 
    {
        public Node ChildLeft;
        public Node ChildRight;
        public OccurenceItem _item;

        public Node(Node Left ,Node Right, int count, char letter = '\0' )
        {
            ChildLeft = Left;
            ChildRight = Right;
            _item = new OccurenceItem()
            {
                Letter = letter,
                Occurences = count

            };

            ChildLeft = Left;
            ChildRight = Right;

        }

    }

}
