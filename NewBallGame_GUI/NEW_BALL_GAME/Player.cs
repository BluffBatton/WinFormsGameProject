namespace NEW_BALL_GAME2
{
    public class Player: BaseElement
    {
        public int X;
        public int Y;
        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Output = Properties.Resources.Player;
        }
    }
}
