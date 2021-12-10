using System.Collections.Generic;

namespace hedgehog_garden_graphical.Casting
{
    class Store : Actor
    {
        public Store()
        {
            SetImage(Constants.IMAGE_STORE);
            _width = 195;
            _height = 111;
            _position = new Point(Constants.STORE_X, Constants.STORE_Y - 50);
        }
    }
}