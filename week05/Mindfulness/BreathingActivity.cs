using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        bool breathingIn = true;

        while (GetRemainingSeconds(startTime) > 0)
        {
            Console.WriteLine();

            if (breathingIn)
            {
                Console.Write("Breathe in... ");
            }
            else
            {
                Console.Write("Breathe out... ");
            }

            int breathDuration = Math.Min(4, GetRemainingSeconds(startTime));

            ShowCountdown(breathDuration);

            breathingIn = !breathingIn;
        }

        DisplayEndingMessage();
    }
}