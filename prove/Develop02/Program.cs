using System;

public class Program
{
    static void Main(string[] args)
    {
        PromptGenerator generator = new PromptGenerator();
        Journal journal = new Journal();

        Console.WriteLine("Welcome to the Journal Program!");
        string answer;
        do{
            Console.WriteLine("Please select one of the following choice");
            Console.WriteLine("1.Write");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.Load");
            Console.WriteLine("4.Save");
            Console.WriteLine("5.Quit");
            Console.Write("What would you like to do? ");
            answer = Console.ReadLine();
            if (answer == "1")
        {
            string prompt = generator.GetRandomPrompt();
            Console.WriteLine(prompt);
            string response = Console.ReadLine();
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            Entry entry = new Entry();
            entry._date = date;
            entry._entryText = response;
            entry._promptText = prompt;
            journal.AddEntry(entry);
        }
        else if (answer == "2")
        {
            journal.DisplayAll();
        }
        else if (answer == "3")
        {
               Console.WriteLine("Write the Filename ");
            string  filename = Console.ReadLine();
            journal.LoadFromFile(filename);
            
        }
        else if (answer == "4")
        {
            Console.WriteLine("Write the Filename ");
            string  filename = Console.ReadLine();
            journal.SaveToFile(filename);
        }
        else if (answer == "5")
        {
            Console.WriteLine("Goodbye");
        }
        else
        {
            Console.WriteLine("Invalid Choice");
        }
        Console.WriteLine();
        } while(answer != "5");
        
    }
}