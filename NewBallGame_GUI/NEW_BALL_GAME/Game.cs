namespace NEW_BALL_GAME2
{
    public class Game
    {
        public int[] GameSize = [20, 40]; //fieldHeight and fieldWidth
        public BaseElement[,] Matrix;
        public bool KeepGame;

        public Player Player = new Player(1, 4);
        public Ball Ball = new Ball(1, 1);

        public int Score = 0;
        public int Steps = 0;
        public int TargetScore;

        public BallVector ball = new BallVector();
        public int BallStatus = BallVector.RIGHT;

        public Info Info;
        public ShieldManager ShieldManager;


        public Game(Window window)
        {
            Info = new Info(this, window); 
            Matrix = new BaseElement[GameSize[0], GameSize[1]];
            InitializeMatrix();
            ShieldManager = new ShieldManager(this);
        }

        public void InitializeMatrix()
        {
            for (int x = 0; x < GameSize[0]; x++)
            {
                for (int y = 0; y < GameSize[1]; y++)
                {
                    if (x == 0 || x == GameSize[0] - 1 || y == 0 || y == GameSize[1] - 1)
                    {
                        Matrix[x, y] = new Wall();
                    }
                    else
                    {
                        Matrix[x, y] = new Space();
                    }
                }
            }

            Matrix[Ball.X, Ball.Y] = Ball;

            for (int j = 3; j <= 16; j++)
            {
                Matrix[j, 19] = new Wall();
                Matrix[j, 21] = new Wall();
                Matrix[j, 20] = new EnChar();
            }

            for (int j = 3; j <= 36; j++)
            {
                Matrix[8, j] = new Wall();
                Matrix[10, j] = new Wall();
                Matrix[9, j] = new EnChar();
            }

            Matrix[8, 20] = new EnChar();
            Matrix[10, 20] = new EnChar();
            Matrix[9, 19] = new EnChar();
            Matrix[9, 21] = new EnChar();

            TargetScore = Info.CountEnChar(Matrix) * 50;
        }

        public void Render(Graphics g)
        {
            int cellWidth = 20;
            int cellHeight = 20;
            for (int x = 0; x < GameSize[0]; x++)
            {
                for (int y = 0; y < GameSize[1]; y++)
                {
                    DrawElement(g, Matrix[x, y], x, y, cellWidth, cellHeight);
                }
            }
            DrawElement(g, Player, Player.X, Player.Y, cellWidth, cellHeight);
        }

        private void DrawElement(Graphics g, BaseElement element, int x, int y, int cellWidth, int cellHeight)
        {
            int offsetX = 30;
            int offsetY = 30;

            Image? image = element.Output;
            if (image != null)
            {
                g.DrawImage(image, offsetX + y * cellWidth, offsetY + x * cellHeight, cellWidth, cellHeight);
            }
        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            if (KeepGame)
            {
                int newX = Player.X + deltaX;
                int newY = Player.Y + deltaY;
                if (newX >= 0 && newX < GameSize[0] && newY >= 0 && newY < GameSize[1])
                {
                    Player.X = newX;
                    Player.Y = newY;
                }
            }
        }

        public void MoveBall()
        {
            if (KeepGame)
            {
                var ballMovementVector = ball.GetBallMovementVector(BallStatus);
                int nextX = Ball.X + ballMovementVector.dx;
                int nextY = Ball.Y + ballMovementVector.dy;
                Steps++;
                int oldX = Ball.X;
                int oldY = Ball.Y;
                if (nextX >= 0 && nextX < GameSize[0] && nextY >= 0 && nextY < GameSize[1])
                {
                    switch (Matrix[nextX, nextY])
                    {
                        case Wall _:
                            BallStatus = ball.GetNextBallStatus(BallStatus);
                            break;

                        case ShieldLeft _:
                            BallStatus = ball.GetBallStatusAfterShieldLeft(BallStatus);
                            break;

                        case ShieldRight _:
                            BallStatus = ball.GetBallStatusAfterShieldRight(BallStatus);
                            break;

                        case EnChar _:
                            Matrix[oldX, oldY] = new Space();
                            Ball.X = nextX;
                            Ball.Y = nextY;
                            Matrix[Ball.X, Ball.Y] = Ball;
                            Score += 50;
                            break;
                        default:
                            Matrix[oldX, oldY] = new Space();
                            Ball.X = nextX;
                            Ball.Y = nextY;
                            Matrix[Ball.X, Ball.Y] = Ball;
                            break;
                    }
                }
                else
                {
                    BallStatus = ball.GetNextBallStatus(BallStatus);
                }
                CheckEnCharAndEndGame();
            }
        }
        public async void CheckEnCharAndEndGame()
        {
            if (Score == TargetScore)
            {
                await Task.Delay(100);
                Info.EndGame();
            }
        }
    }
}