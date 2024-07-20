using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> usedPrompts = new List<string>();

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void PerformActivity()
    {
        Start();
        string prompt = GetUniquePrompt();
        Console.WriteLine(prompt);

        Console.WriteLine("Begin listing items in:");
        ShowCountdown(5);

        List<string> items = new List<string>();
        int timeElapsed = 0;
        while (timeElapsed < Duration)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
            timeElapsed++;
        }

        Console.WriteLine($"You listed {items.Count} items.");
        End();
    }

    private string GetUniquePrompt()
    {
        if (usedPrompts.Count == prompts.Count)
        {
            usedPrompts.Clear();
        }

        string prompt;
        do
        {
            prompt = prompts[new Random().Next(prompts.Count)];
        } while (usedPrompts.Contains(prompt));

        usedPrompts.Add(prompt);
        return prompt;
    }
}

