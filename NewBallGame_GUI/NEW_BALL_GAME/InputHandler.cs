namespace NEW_BALL_GAME2
{
    public class InputHandler
    {
        Game game;
        Info info;
        Window window;

        public InputHandler(Game game, Info info, Window window)
        {
            this.game = game;
            this.info = info;
            this.window = window;
        }

        public void ProcessKey(Keys key)
        {
            if (game.KeepGame)
            {
                switch (key)
                {
                    case Keys.Up:
                        game.MovePlayer(-1, 0);
                        break;
                    case Keys.Down:
                        game.MovePlayer(1, 0);
                        break;
                    case Keys.Left:
                        game.MovePlayer(0, -1);
                        break;
                    case Keys.Right:
                        game.MovePlayer(0, 1);
                        break;
                    case Keys.A:
                        game.ShieldManager.SaveShieldLeft();
                        break;
                    case Keys.D:
                        game.ShieldManager.SaveShieldRight();
                        break;
                    case Keys.S:
                        game.ShieldManager.RemoveShield();
                        break;
                    case Keys.Escape:
                        info.EndGame();
                        break;
                }
                Application.DoEvents();
            }
        }
    }
}