namespace hedgehog_garden_graphical.Casting
{
    public class Paddle : Actor
    {
        public Paddle(int x, int y)
        {
            _position = new Point(x, y);
            SetImage(Constants.IMAGE_PADDLE);
            _height = Constants.PADDLE_HEIGHT;
            _width = Constants.PADDLE_WIDTH;
        }
    }
}