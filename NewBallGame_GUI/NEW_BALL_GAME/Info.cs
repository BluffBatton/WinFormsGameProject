namespace NEW_BALL_GAME2
{
    public class Info
    {

        Game game;
        Window window;
        public char Tier;
        List<int> TierList = new List<int> { 105, 120, 135, 150, 160, 170 };
        
        public Info(Game game, Window window) 
        {
            this.game = game;
            this.window = window; 
        }

        public int CountEnChar(BaseElement[,] matrix)
        {
            int count = 0;
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x, y] is EnChar)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void Rank()
        {
            if (game.Steps <= TierList[0])
            {
                Tier = 'S';
            }
            else if (game.Steps > TierList[0] && game.Steps <= TierList[1])
            {
                Tier = 'A';
            }
            else if (game.Steps > TierList[1] && game.Steps <= TierList[2])
            {
                Tier = 'B';
            }
            else if (game.Steps > TierList[2] && game.Steps <= TierList[3])
            {
                Tier = 'C';
            }
            else if (game.Steps > TierList[3] && game.Steps <= TierList[4])
            {
                Tier = 'D';
            }
            else
            {
                Tier = 'F';
            }
        }  

        public void StartGame()
        {
            MessageBox.Show("Press OK to start the game", "Start Game", MessageBoxButtons.OK);
            game.KeepGame = true;
        }

        public void EndGame()
        {
            game.KeepGame = false;      
            Rank();
            MessageBox.Show($"Total Steps: {game.Steps}\nYour score: {game.Score}\nYour rank: {Tier}", "End Game", MessageBoxButtons.OK);
            Application.Exit();
        }
    }
}