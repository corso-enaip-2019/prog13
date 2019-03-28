using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramGame
{
    class Challenge : IGamePlay
    {
        readonly IWordsRepository _wordsRepository;

        public Challenge(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        public string Description => "I'll give you a word and you must write one of its anagram.";

        public void Run(IUiHandler uiHandler)
        {
            bool presence = true;
            string randomWord = _wordsRepository.GetRandomWord();   

            var anagrams = _wordsRepository.GetAnagrams(randomWord);

            while (presence)
            {
                /*if (anagrams.Count > 1)
                    presence = false;
                else
                anagrams = _wordsRepository.GetAnagrams(randomWord);
                uiHandler.WriteMessage(anagrams[1]);*/
            }

            uiHandler.WriteMessage($"\nHere's the word: { randomWord }\nNow insert a word and i'll tell you if it's an anagram");

            string userWord = uiHandler.AskForString("");

            for(int i = 0; i > anagrams.Count; i++)
            {
                if (userWord.Equals(anagrams[i]))
                {
                    uiHandler.WriteMessage($"{anagrams[i]}\n");
                    presence = true;
                }
                
            }

            if (!presence)
                uiHandler.WriteMessage("Your word is no anagram");

        }
    }
}
