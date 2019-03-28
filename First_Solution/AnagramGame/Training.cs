using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramGame
{
    class Training : IGamePlay
    {
        readonly IWordsRepository _wordsRepository;

        public Training(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        public string Description => "\nInsert a word and I'll give you all possible anagrams.";
        
        public void Run(IUiHandler uiHandler)
        {
            string word = uiHandler.AskForString("");

            var anagrams = _wordsRepository.GetAnagrams(word);

            if (anagrams.Count > 1)
            {
                uiHandler.WriteMessage($"I found these anagrams:");
                foreach (var anagram in anagrams)
                {
                    uiHandler.WriteMessage(anagram);
                }
            }
            else
                uiHandler.WriteMessage("\nI didn't find any anagrams");
        }
    }
}
