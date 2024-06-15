namespace NEW_BALL_GAME2
{
    public class BallVector
    {
        public const int RIGHT = 1, DOWN = 2, LEFT = 3, UP = 4;

        public (int dx, int dy) GetBallMovementVector(int ballStatus)
        {
            switch (ballStatus)
            {
                case RIGHT:
                    return (0, 1);
                case DOWN:
                    return (1, 0);
                case LEFT:
                    return (0, -1);
                case UP:
                    return (-1, 0);
                default:
                    return (0, 0);
            }
        }

        public int GetNextBallStatus(int currentStatus)
        {
            switch (currentStatus)
            {
                case RIGHT:
                    return LEFT;
                case DOWN:
                    return UP;
                case LEFT:
                    return RIGHT;
                case UP:
                    return DOWN;
                default:
                    return RIGHT;
            }
        }

        public int GetBallStatusAfterShieldLeft(int currentStatus) // (\)
        {
            switch (currentStatus)
            {
                case RIGHT:
                    return DOWN;
                case UP:
                    return LEFT;
                case LEFT:
                    return UP;
                case DOWN:
                    return RIGHT;
                default:
                    return currentStatus;
            }
        }

        public int GetBallStatusAfterShieldRight(int currentStatus) // (/)
        {
            switch (currentStatus)
            {
                case RIGHT:
                    return UP;
                case DOWN:
                    return LEFT;
                case LEFT:
                    return DOWN;
                case UP:
                    return RIGHT;
                default:
                    return currentStatus;
            }
        }
    }
}
