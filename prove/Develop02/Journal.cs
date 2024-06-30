using System;
using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach(Entry entry in _entries){
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file + ".txt")){
            outputFile.WriteLine("Date~prompt~response");
            foreach(Entry entry in _entries){
                outputFile.WriteLine($"{entry._date}~{entry._promptText}~{entry._entryText}");
                
            }
        }
        Console.WriteLine("Saved");
    }
    public void LoadFromFile(string file)
    {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(file + ".txt")){
            reader.ReadLine();
            while(!reader.EndOfStream)
            {
                string entryline = reader.ReadLine();
                string[] fields = entryline.Split("~");
                Entry entry = new Entry();
                entry._date = fields[0];
                entry._promptText = fields[1];
                entry._entryText = fields[2];
                _entries.Add(entry);
            }
        }
        Console.WriteLine("Loaded");
        
    }
}