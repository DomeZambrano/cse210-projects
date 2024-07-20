using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> usedPrompts = new List<string>();
    private List<string> usedQuestions = new List<string>();

    public ReflectionActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void PerformActivity()
    {
        Start();
        string prompt = GetUniquePrompt();
        Console.WriteLine(prompt);

        int timeElapsed = 0;
        while (timeElapsed < Duration)
        {
            string question = GetUniqueQuestion();
            Console.WriteLine(question);
            ShowSpinner(5);
            timeElapsed += 5;
        }
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

    private string GetUniqueQuestion()
    {
        if (usedQuestions.Count == questions.Count)
        {
            usedQuestions.Clear();
        }

        string question;
        do
        {
            question = questions[new Random().Next(questions.Count)];
        } while (usedQuestions.Contains(question));

        usedQuestions.Add(question);
        return question;
    }
}


