namespace hedgehog_garden_graphical.Casting
{
    class SpecialHedgehog : Hedgehog
    {
        public SpecialHedgehog()
        {
            _width = 20;
            _height = 25;
            _position = new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2);
        }
    }
}