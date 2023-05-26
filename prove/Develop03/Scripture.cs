using System;
using System.Collections.Generic;

class Scripture
    {
        private Reference reference;
        private List<Word> words;

        public Scripture(string book, int chapter, int verse,int endVerse, string text)
        {
            reference = new Reference(book, chapter, verse, endVerse);
            
            words = new List<Word>();
            // Split the text into words and add them to the word list
            string[] splitText = text.Split(' ');
            for (int i = 0; i < splitText.Length; i++)
            {
                words.Add(new Word(splitText[i]));
            }
        }
        public Scripture(string book, int chapter, int verse,string text)
        {
            reference = new Reference(book, chapter, verse);
            
            words = new List<Word>();
            string[] splitText = text.Split(' ');
            for (int i = 0; i < splitText.Length; i++)
            {
                words.Add(new Word(splitText[i]));
            }
        }

        public void HideRandomWord()
        {
            Random rand = new Random();
            int index = rand.Next(words.Count);
            words[index].Hide();
        }

        public bool AllWordsHidden()
        {
            foreach (Word word in words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string output = reference.ToString() + " ";
            foreach (Word word in words)
            {
                output += word.ToString() + " ";
            }
            return output;
        }
    }