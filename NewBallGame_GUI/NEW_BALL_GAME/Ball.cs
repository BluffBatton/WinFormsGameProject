namespace NEW_BALL_GAME2
{
    public class Ball: BaseElement
    {
        public int X;
        public int Y;
        public Ball(int x, int y)
        {
            X = x;
            Y = y;
            Output = Properties.Resources.Ball;
        }
    }
}
