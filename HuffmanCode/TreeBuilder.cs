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
                Occurences = 2
            });
        }

    }

    public class OccurenceItem
    {
       public char Letter;
       public int Occurences; 
    }
}
