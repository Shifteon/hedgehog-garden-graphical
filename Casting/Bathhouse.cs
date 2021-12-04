namespace hedgehog_garden_graphical.Casting
{
    class Bathhouse : Actor
    {
        public Bathhouse()
        {
            _width = 100;
            _height = 100;
            _position = new Point(Constants.BATHHOUSE_X, Constants.BATHHOUSE_Y - 50);
        }
    }
}