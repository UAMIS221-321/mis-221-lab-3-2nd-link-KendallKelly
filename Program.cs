using System;

public class Program
{
    public static void Main()
    {
        string enjoymentLevel = GetEnjoymentLevel();
        string stadium = GetStadiumRecommendation(enjoymentLevel);
        string game = GetGameRecommendation(stadium);
        DisplayStadiumDetails(stadium, game);
    }

    // Get enjoyment level from the user
    static string GetEnjoymentLevel()
    {
        Console.WriteLine("Do you want the game to be Boring, Average, Fun, or Epic?");
        string input = Console.ReadLine();
        return input?.Trim().ToLower(); 
    }

    // Get stadium recommendation based on enjoyment level
    static string GetStadiumRecommendation(string enjoymentLevel)
    {
        switch (enjoymentLevel)
        {
            case "boring":
                return "Neyland Stadium";
            case "average":
                return "Jordan-Hare Stadium";
            case "fun":
                return "Tiger Stadium";
            case "epic":
                return "Bryant-Denny Stadium";
            default:
                return "Invalid input";
        }
    }

    static string GetGameRecommendation(string stadium)
    {
        switch (stadium)
        {
            case "Neyland Stadium":
                return "No specific game recommended.";
            case "Jordan-Hare Stadium":
                return "Auburn vs Kentucky";
            case "Tiger Stadium":
                return "LSU vs Alabama";
            case "Bryant-Denny Stadium":
                return "Iron Bowl";
            default:
                return "No game recommendation available.";
        }
    }

    // Shows stadium and game details
    static void DisplayStadiumDetails(string stadium, string game)
    {
        if (stadium == "Invalid input")
        {
            Console.WriteLine("Invalid enjoyment level input.");
        }
        else
        {
            Console.WriteLine($"You should go to {stadium} and watch the {game} game.");
        }
    }
}


