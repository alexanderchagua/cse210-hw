 class Word
    {
        private string _text;
        private bool hidden;

        public Word(string text)
        {
            _text = text;
            hidden = false;
        }
        // Hide the word
        public void Hide()
        {
            hidden = true;
        }
        // Check if the word is hidden
        public bool IsHidden()
        {
            return hidden;
        }
        // returns a string representation of the word
        public override string ToString()
        {
            if (hidden)
            {
                return "_";
            }
            else
            {
                return _text;
            }
        }
    }