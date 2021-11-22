namespace hedgehog_garden_graphical.Casting
{
    public class Ball : Actor
    {
        private bool _isAlive = true;
        public Ball(int x, int y)
        {
            _position = new Point(x, y);
            SetImage(Constants.IMAGE_BALL);
            _height = Constants.BALL_HEIGHT;
            _width = Constants.BALL_WIDTH;
            _velocity = new Point(Constants.BALL_DX, Constants.BALL_DY);
        }

        public void BounceHorizontal()
        {
            _velocity = new Point(_velocity.GetX() * -1, _velocity.GetY());
            return;
        }

        public void BounceVertical()
        {
            _velocity = new Point(_velocity.GetX(), _velocity.GetY() * -1);
            return;
        }

        public bool GetAlive()
        {
            return _isAlive;
        }

        public void kill()
        {
            _isAlive = false;
        }
    }
}