namespace hedgehog_garden_graphical.Casting
{
    class Gym : Actor
    {
        public Gym()
        {
            SetImage(Constants.IMAGE_GYM);
            _width = 186;
            _height = 111;
            _position = new Point(Constants.GYM_X, Constants.GYM_Y - 50);
        }
    }
}