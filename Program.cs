using System;
using System.Reflection.Metadata;
using ClassLibrary1;
namespace SI;

public class A
{
    public static void Main()
    {
        List<ScorePlayer> lista = new List<ScorePlayer>();
        string player;
        string mission;
        int score;
        for (int i = 0; i < 2; i++)
        {
            try
            {
                Console.WriteLine("Escriu el teu nom");
                player = Console.ReadLine();
                while (PlayerCheck(player) == false || player.Length < 1)
                {

                    Console.WriteLine("El nom només pot contenir caracters alfabetics i numerics");
                    player = Console.ReadLine();
                }
                Console.WriteLine("Introdueix el nom de la missió");
                mission = Console.ReadLine();
                while (MissionCheck(mission) == false)
                {

                    Console.WriteLine("El format ha de ser una lletra romana i tres nombres, per exemple: Alfa-028");
                    mission = Console.ReadLine();
                }
                Console.WriteLine("Introdueix la teva puntuacio");
                score = Convert.ToInt32(Console.ReadLine());
                while (score < 0 || score > 500)
                {
                    Console.WriteLine("La puntuació ha d'estar entre 0 i 500");
                    score = Convert.ToInt32(Console.ReadLine());

                }

                ScorePlayer newPlayer = new ScorePlayer(player, mission, score);
                lista.Add(newPlayer);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message} Torna a escriure les dades");
                i--;
            }
        }
        Console.WriteLine("Puntuacions");
        Console.WriteLine("==============================================");
        GenerateUniqueRanking(lista);
    }

    public static bool PlayerCheck(string player)
    {
        foreach(char c in player)
        {
            if (!Char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        return true;
    }
    public static bool MissionCheck(string mission)
    {
        string[] letrasGriegas = {"alfa", "beta", "gamma", "delta", "epsilon", "zeta",
                "eta", "theta", "iota", "kappa", "lambda", "mi", "ni", "ksi", "omicron", "pi", "ro",
                "sigma", "tau", "ipsilon", "fi", "khi", "psi", "omega"};
        mission = mission.ToLower();
        string[] missionName = mission.Split('-');
        int number = Convert.ToInt32(missionName[1]);
        if (letrasGriegas.Contains(missionName[0]) && missionName[1].Length == 3)
        {
            foreach (string s in letrasGriegas)
            {
                if (missionName[0].StartsWith(s))
                {
                    if (number > 0 && number < 1000)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        return false;
    }
    public static void GenerateUniqueRanking(List<ScorePlayer> lista)
    {

        lista = lista.OrderByDescending(ScorePlayer => ScorePlayer.Score).ToList();
        List<ScorePlayer> listb = new List<ScorePlayer>();
        foreach (ScorePlayer player in lista)
        {

            if (!listb.Any(p => p.Player == player.Player && p.Mission == player.Mission && p.Score == player.Score))
            {

                listb.Add(player);
                Console.WriteLine(player.ToString());   
            }
        }
        

    }
    
}
