using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void PerformActivity()
    {
        Start();
        int timeElapsed = 0;
        while (timeElapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            ShowBreathingAnimation(5);
            timeElapsed += 5;

            if (timeElapsed >= Duration) break;

            Console.WriteLine("Breathe out...");
            ShowBreathingAnimation(5);
            timeElapsed += 5;
        }
        End();
    }

    private void ShowBreathingAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.WriteLine(new string('*', i + 1));
            Thread.Sleep(1000);
        }
    }
}

