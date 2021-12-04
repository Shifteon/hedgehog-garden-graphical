namespace hedgehog_garden_graphical.Casting
{
    class Gym : Actor
    {
        public Gym()
        {
            _width = 100;
            _height = 100;
            _position = new Point(Constants.GYM_X, Constants.GYM_Y - 50);
        }
    }
}