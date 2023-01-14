using System;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main()
        {
            GameAccount p1 = new GameAccount("P1");
            GameAccount p2 = new GameAccount("P2");

            Console.WriteLine($"\nCurrent rating of {p1.UserName}: {p1.CurrentRating}");
            Console.WriteLine($"Current rating of {p2.UserName}: {p2.CurrentRating}");
            Console.WriteLine($"Current games count of {p1.UserName}: {p1.GamesCount}");
            Console.WriteLine($"Current games count of {p2.UserName}: {p2.GamesCount}");


            p1.WinGame(p2, 20);
            p2.LostGame(p1, 30);
            p1.LostGame(p2, 10);
            p2.WinGame(p1, 0);

            Console.WriteLine(p1.GetStats());
            Console.WriteLine(p2.GetStats());

            try
            {
                p1.WinGame(p2, -10);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ERROR: Rating of p2 < 0");
            }

            Console.WriteLine($"\nCurrent rating of {p1.UserName}: {p1.CurrentRating}");
            Console.WriteLine($"Current rating of {p2.UserName}: {p2.CurrentRating}");
            Console.WriteLine($"Current games count of {p1.UserName}: {p1.GamesCount}");
            Console.WriteLine($"Current games count of {p2.UserName}: {p2.GamesCount}");
        }
    }
}