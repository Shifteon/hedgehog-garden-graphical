namespace hedgehog_garden_graphical.Casting
{
    class Player : Actor
    {
        private string _name;

        public Player()
        {
            _width = Constants.PLAYER_WIDTH;
            _height = Constants.PLAYER_HEIGHT;
            _position = new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2);
            _name = "Bob";
        }
    }
}