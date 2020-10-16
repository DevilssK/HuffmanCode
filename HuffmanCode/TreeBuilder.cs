using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HuffmanCode
{
    class TreeBuilder
    {
        List<OccurenceItem> _testOccurences = new List<OccurenceItem>();

        public   TreeBuilder()
        {
            _testOccurences.Add(new OccurenceItem()
            {
                Letter = 't',
                Occurences = 1
            });
            _testOccurences.Add(new OccurenceItem()
            {
                Letter = 'a',
                Occurences = 1
            });
            _testOccurences.Add(new OccurenceItem()
            {
                Letter = 's',
                Occurences = 3
            });
            _testOccurences.Add(new OccurenceItem()
            {
                Letter = 'e',
                Occurences = 1
            });

            BuildTree(_testOccurences);
        }

        public List<OccurenceItem> TestOccurences { get => _testOccurences; set => _testOccurences = value; }

        public Node BuildTree(List<OccurenceItem> List)
        {
            List<Node> NodeList = new List<Node>();

            foreach (OccurenceItem occurence in List)
            {
                NodeList.Add(new Node(null,null,occurence.Occurences, occurence.Letter));

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


        public void PrintTree(Node tree, String indent, Boolean last)
        {
            Console.Write(indent + "+- " + tree._item.Occurences );
            indent += last ? "   " : "|  ";
            if (!last)
            {
                if (tree.ChildLeft != null && tree.ChildRight != null) { last = false;  } else { last = true; };
               if(tree.ChildLeft!=null) PrintTree(tree.ChildLeft, indent, last);
                if (tree.ChildRight != null) PrintTree(tree.ChildRight, indent, last);
            }
        }

        //public void SaveInFileTxtTheDictionnary(File file,Node node,string bit)
        //{
        //    if(node == null)
        //    {
        //        return;
        //    }


        //}

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
