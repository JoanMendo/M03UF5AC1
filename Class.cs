namespace ClassLibrary1
{
    public class ScorePlayer 
    {
        public string Player { get; set; } = "";
        public string Mission { get; set; } = "";

        public int Score { get; set; } = 0;

        public override string ToString()
        {
            return $"{Player} - {Mission}: {Score}";
        }

       public ScorePlayer(string player, string mission, int score)
        {
            Player = player;    
            Mission = mission;
            Score = score;
        }
       


    }
}
