namespace hedgehog_garden_graphical.Casting
{
    class Hedgehog : Actor
    {
        private string _name;

        public Hedgehog()
        {
            _width = 20;
            _height = 25;
            _position = new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2);
        }
    }
}