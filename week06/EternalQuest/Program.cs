using System;

/*
 * EXCEEDING REQUIREMENTS:
 * 1. Leveling system: every 1000 points raises the player's level and gives a
 *    new title (up to "Ninja Unicorn"), with a LEVEL UP message.
 * 2. NegativeGoal: a fourth kind of goal for bad habits that subtracts points
 *    each time it is recorded.
 * 3. Input validation: numbers are re-requested until valid, goal numbers are
 *    range-checked, and loading checks that the file exists and is not empty.
 * 4. Safe save format: "|" is the separator, and it is removed from user text
 *    so goal names and descriptions can safely contain commas.
 */
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}