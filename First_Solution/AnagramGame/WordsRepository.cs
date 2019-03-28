using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramGame
{
    public class WordsRepository : IWordsRepository
    {
        readonly List<string> _wordsDictionary;

        public WordsRepository(IDictionaryLoader dictionaryLoader)
        {
            _wordsDictionary = dictionaryLoader.LoadDictionary();
        }

        public List<string> GetAnagrams(string word)
        {
            List<string> anagrams = new List<string>();

            for(int i = 0; i < _wordsDictionary.Count; i++)
            {
                if (IsAnagram(word, _wordsDictionary[i]))
                {
                    if (!word.Equals(_wordsDictionary[i]))
                        anagrams.Add(_wordsDictionary[i]);
                    else { }
                }
                    
            }
            return anagrams;
        }

        public string GetRandomWord()
        {
            Random rnd = new Random();
            int r = rnd.Next(_wordsDictionary.Count);
            return _wordsDictionary[r];
        }

        public bool IsAnagram(string sourceWord, string candidateAnagram)
        {
            bool anag;

            if (String.Concat(sourceWord.OrderBy(c => c)).Equals(String.Concat(candidateAnagram.OrderBy(c => c))))
                anag = true;
            else
                anag = false;

            return anag;
        }
    }
}
