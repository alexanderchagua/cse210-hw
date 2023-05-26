using System;
using System.Collections.Generic;
// Class representing a write reference
class Reference
    {
        private string _boOk;
        private int _chapTer;
        private int _startVerse;
        private int _endVerse;

        public Reference(string boOk, int chapTer, int verse)
        {
            _boOk = boOk;
            _chapTer = chapTer;
            _startVerse = verse;
            _endVerse = verse;
        }

        public Reference(string boOk, int chapTer, int startVerse, int endVerse)
        {
            _boOk = boOk;
            _chapTer = chapTer;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public override string ToString()
        {
            if (_startVerse == _endVerse)
            {
                return _boOk + " " + _chapTer + ":" + _startVerse;
            }
            else
            {
                return _boOk + " " + _chapTer + ":" + _startVerse + "-" + _endVerse;
            }
        }
    }