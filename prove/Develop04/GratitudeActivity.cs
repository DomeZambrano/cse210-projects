using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "List things you are grateful for today.",
        "List people you are thankful for in your life.",
        "List opportunities you are grateful for.",
        "List experiences you are thankful for.",
        "List personal achievements you are proud of."
    };

    private List<string> usedPrompts = new List<string>();

    public GratitudeActivity()
    {
        Name = "Gratitude Activity";
        Description = "This activity will help you reflect on the things you are grateful for, promoting a positive mindset.";
    }

    public override void PerformActivity()
    {
        Start();
        string prompt = GetUniquePrompt();
        Console.WriteLine(prompt);

        Console.WriteLine("Begin listing things you are grateful for:");
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

        Console.WriteLine($"You listed {items.Count} things you are grateful for.");
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
