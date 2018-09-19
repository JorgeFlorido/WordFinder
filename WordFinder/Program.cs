using System;
using System.Collections.Generic;
using WordFinder.WordFinder.Services;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var wordFinder = AppInit.Run();
                var words = wordFinder.GetWords();
                Print(words);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ooops, sorry, something went wrong with {e.Message}");
            }
        }

        private static void Print(IEnumerable<Word> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word.Value);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
