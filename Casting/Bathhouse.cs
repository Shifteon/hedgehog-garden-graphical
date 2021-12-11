namespace hedgehog_garden_graphical.Casting
{
    class Bathhouse : Actor
    {
        public Bathhouse()
        {
            SetImage(Constants.IMAGE_BATHHOUSE);
            _width = 195;
            _height = 111;
            _position = new Point(Constants.BATHHOUSE_X, Constants.BATHHOUSE_Y - 50);
        }
    }
}