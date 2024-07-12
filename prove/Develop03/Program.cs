using System;
using System.Collections.Generic;
using System.Linq;
//Explanation of Enhancements
//ScriptureLibrary Class: Manages a collection of scriptures loaded from a file and provides a method to get a random scripture.
//Scripture Class Enhancements: Adds a Reset method to unhide all words, preparing the scripture for a fresh start.
//Word Class Enhancements: Adds an Unhide method to make a hidden word visible again.
//Program Class Enhancements: Updates the main loop to support multiple scriptures, allow the user to move to the next scripture, and handle file loading.
class Program
{
    static void Main(string[] args)
    {
        var scriptureLibrary = new ScriptureLibrary("scripture.txt");

        while (true)
        {
            var scripture = scriptureLibrary.GetRandomScripture();
            scripture.Reset();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words, type 'next' for a new scripture, or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    return;
                }
                else if (input.ToLower() == "next")
                {
                    break;
                }

                scripture.HideRandomWords(3);

                if (scripture.AreAllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine("All words are hidden. Moving to the next scripture.");
                    break;
                }
            }
        }
    }
}

