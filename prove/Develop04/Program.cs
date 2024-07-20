using System;
using System.Collections.Generic;
using System.IO;
//EXCEEDING REQUIREMENTS 
//New Activity: Added a new GratitudeActivity class for users to list things they are grateful for.
//Activity Log: Keeps track of how many times each activity has been performed and saves this log to a file.
//Unique Prompts/Questions: Ensures no prompt or question is repeated within a session until all have been used.
//Log File: Saves and loads activity logs from a file to maintain user progress across sessions.
//Enhanced Animation: Improved the breathing activity animation to provide a more engaging experience.

public class Program
{
    public static void Main(string[] args)
    {
        Activity.LoadLog();

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.PerformActivity();
        }
    }
}
