using System;
using System.Collections.Generic;
using System.Text;

namespace HuffmanCode
{
    class TreeBuilder
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
