using System;
using System.Collections.Generic;
using System.Text;

namespace HuffmanCode.HuffmanCode.Helper
{
    public class Whatever
    {
        public Whatever()
        {

        }
        public Whatever(char _Value, string _BinHeffman)
        {
            this._value = _Value;
            this._binHeffman = _BinHeffman;
        }

        private char _value;

        public char Value
        {
            get { return _value; }
            set { _value = value; }
        }


        private string _binHeffman;

        public string BinHeffman
        {
            get { return _binHeffman; }
            set { _binHeffman = value; }
        }


    }
}
