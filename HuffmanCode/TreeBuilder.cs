﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HuffmanCode
{
    class TreeBuilder
    {
        List<OccurenceItem> Occurences = new List<OccurenceItem>();

        public   TreeBuilder()
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

            BuildTree(Occurences);
        }

        public void BuildTree(List<OccurenceItem> List)
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
                NodeList.Insert(newidx , NewNode);
                NodeList.Remove(temp);
                NodeList.Remove(temp2);

            }
            Console.WriteLine(NodeList.Count);
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
            _item = new OccurenceItem()
            {
                Letter = letter,
                Occurences = count

            };
            
        }
    }
}
