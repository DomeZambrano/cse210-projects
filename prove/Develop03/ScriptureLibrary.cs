using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScriptureLibrary
{
    private List<Scripture> scriptures;
    private static Random random = new Random();

    public ScriptureLibrary(string filePath)
    {
        scriptures = new List<Scripture>();
        LoadScripturesFromFile(filePath);
    }

    private void LoadScripturesFromFile(string filePath)
    {
        try
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 2)
                {
                    var referenceParts = parts[0].Split(':');
                    var bookAndChapter = referenceParts[0].Split(' ');
                    var book = string.Join(" ", bookAndChapter.Take(bookAndChapter.Length - 1));
                    var chapter = int.Parse(bookAndChapter.Last());

                    var verseParts = referenceParts[1].Split('-');
                    var startVerse = int.Parse(verseParts[0]);
                    int? endVerse = verseParts.Length > 1 ? int.Parse(verseParts[1]) : (int?)null;

                    var reference = endVerse.HasValue
                        ? new Reference(book, chapter, startVerse, endVerse.Value)
                        : new Reference(book, chapter, startVerse);

                    var scripture = new Scripture(reference, parts[1]);
                    scriptures.Add(scripture);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading scriptures: " + ex.Message);
        }
    }

    public Scripture GetRandomScripture()
    {
        return scriptures[random.Next(scriptures.Count)];
    }
}
