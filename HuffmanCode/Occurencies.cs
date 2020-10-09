using System;
using System.Collections.Generic;
using System.Text;

namespace HuffmanCode
{
   public class Occurencies
   {

        public Dictionary<char, int> GuessNumberOfOccurenciesWithDictionnary(string text)
        {
            Dictionary<char, int>  _occurenciesDictionnary = new Dictionary<char, int>();

            foreach (var item in text)
            {
                if (_occurenciesDictionnary.ContainsKey(item))
                {
                    _occurenciesDictionnary[item] = _occurenciesDictionnary[item] + 1;
                }
                else
                {
                    _occurenciesDictionnary.Add(item, 1);
                }
            }
            return _occurenciesDictionnary;

        }
    }
}
