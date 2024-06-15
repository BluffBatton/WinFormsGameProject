namespace NEW_BALL_GAME2
{
    public partial class Window : Form
    {
        private Game game;
        private Info info;
        public PictureBox gamePictureBox;
        private InputHandler inputHandler;

        public Window()
        {
            InitializeComponent();

            game = new Game(this);
            info = new Info(game, this);
            inputHandler = new InputHandler(game, info, this);

            gamePictureBox = new PictureBox();
            gamePictureBox.Dock = DockStyle.Fill;
            gamePictureBox.Paint += GamePictureBox_Paint;
            this.Controls.Add(gamePictureBox);

            this.KeyDown += Window_KeyDown;

            info.StartGame();
        }

        public void GamePictureBox_Paint(object? sender, PaintEventArgs e)
        {
            if (game.KeepGame)
            {
                game.Render(e.Graphics);
            }
        }
        public void Window_KeyDown(object? sender, KeyEventArgs e)
        {
            if (game.KeepGame)
            {
                inputHandler.ProcessKey(e.KeyCode);
                gamePictureBox.Invalidate();
            }
        }
        public void UpdateScoreLabel()
        {
            scoreLabel.Text = "Score: " + game.Score;
        }

        public void BallTimer_Tick(object sender, EventArgs e)
        {
            if (game.KeepGame)
            {
                game.MoveBall();
                gamePictureBox.Invalidate();
                UpdateScoreLabel();
            }
        }
    }
}