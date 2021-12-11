using System;

namespace hedgehog_garden_graphical.Casting
{
    class SpecialHedgehog : Hedgehog
    {
        public SpecialHedgehog()
        {
            _isSpecial = true;
            SetImage(Constants.IMAGE_HEDGEHOG_SPECIAL);
            _width = Constants.SPECIAL_HEDGEHOG_WIDTH;
            _height = Constants.SPECIAL_HEDGEHOG_HEIGHT;
            Random r = new Random();
            _position = new Point(r.Next(100, Constants.MAX_X - 100), r.Next(200, Constants.MAX_Y - 200));
            if (r.Next(1,20) < 11)
                _velocity = new Point(2, 0);
            else
                _velocity = new Point(0, 2);
            _hunger = 400;
            // Set up the max stats
            _maxStats["maxHunger"] = 0;
            _maxStats["maxHealth"] = 500;
            _maxStats["maxHygiene"] = 500;
        }

        public SpecialHedgehog(string name, string hunger, string health, string hygiene, string shiny, string newHog)
        {
            _isSpecial = true;
            SetImage(Constants.IMAGE_HEDGEHOG_SPECIAL);
            InitializeHedgehog(name, hunger, health, hygiene, shiny, newHog);
            _width = Constants.SPECIAL_HEDGEHOG_WIDTH;
            _height = Constants.SPECIAL_HEDGEHOG_HEIGHT;
            Random r = new Random();
            _position = new Point(r.Next(100, Constants.MAX_X - 100), r.Next(200, Constants.MAX_Y - 200));
            if (r.Next(1,20) < 11)
                _velocity = new Point(2, 0);
            else
                _velocity = new Point(0, 2);
            _hunger = 400;
            // Set up the max stats
            _maxStats["maxHunger"] = 0;
            _maxStats["maxHealth"] = 500;
            _maxStats["maxHygiene"] = 500;
        }
    }
}