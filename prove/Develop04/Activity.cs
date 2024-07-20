using System;
using System.Collections.Generic;
using System.IO;

public abstract class Activity
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }
    protected static Dictionary<string, int> ActivityLog = new Dictionary<string, int>();

    public void Start()
    {
        Console.WriteLine($"Starting activity: {Name}");
        Console.WriteLine($"{Description}");
        Console.Write("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(5);
    }

    public void End()
    {
        Console.WriteLine("Good job!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        ShowSpinner(3);

        if (ActivityLog.ContainsKey(Name))
        {
            ActivityLog[Name]++;
        }
        else
        {
            ActivityLog[Name] = 1;
        }

        SaveLog();
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void PerformActivity();

    protected void SaveLog()
    {
        using (StreamWriter writer = new StreamWriter("activity_log.txt"))
        {
            foreach (var entry in ActivityLog)
            {
                writer.WriteLine($"{entry.Key}:{entry.Value}");
            }
        }
    }

    public static void LoadLog()
    {
        if (File.Exists("activity_log.txt"))
        {
            using (StreamReader reader = new StreamReader("activity_log.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    ActivityLog[parts[0]] = int.Parse(parts[1]);
                }
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }
}

