namespace NEW_BALL_GAME2
{
    public class ShieldManager
    {
        private Game game;

        public ShieldManager(Game game)
        {
            this.game = game;
        }

        public void RemoveShield()
        {
            if (game.Matrix[game.Player.X, game.Player.Y] is ShieldLeft || game.Matrix[game.Player.X, game.Player.Y] is ShieldRight)
            {
                game.Matrix[game.Player.X, game.Player.Y] = new Space();
            }
        }

        public void SaveShieldLeft()
        {
            if (game.Matrix[game.Player.X, game.Player.Y] is Space)
            {
                game.Matrix[game.Player.X, game.Player.Y] = new ShieldLeft();
            }
        }

        public void SaveShieldRight()
        {
            if (game.Matrix[game.Player.X, game.Player.Y] is Space)
            {
                game.Matrix[game.Player.X, game.Player.Y] = new ShieldRight();
            }
        }
    }
}
