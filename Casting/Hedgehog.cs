using System.Collections.Generic;

namespace hedgehog_garden_graphical.Casting
{
    class Hedgehog : Actor
    {
        private string _name = "Harry";
        private int _hunger = 300;
        private int _health = 100;
        private int _hygiene = 100;
        private Dictionary<string, int> _maxStats = new Dictionary<string, int>();

        public Hedgehog()
        {
            _width = 20;
            _height = 25;
            _position = new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2);
            // Set up the max stats
            _maxStats["maxHunger"] = 0;
            _maxStats["maxHealth"] = 300;
            _maxStats["maxHygiene"] = 300;
        }

        public void Wash()
        {
            if (_hygiene < _maxStats["maxHygiene"])
                _hygiene += 20;
            if (_hygiene > _maxStats["maxHygiene"])
                _hygiene = _maxStats["maxHygiene"];
        }

        public void Exercise()
        {
            if (_health < _maxStats["maxHealth"])
                _health += 20;
            if (_health > _maxStats["maxHealth"])
                _health = _maxStats["maxHealth"];
            if (_hygiene >= 10)
                _hygiene -= 10;
        }

        public void Feed(Food food)
        {
            if (_hunger > 0)
                _hunger -= food.GetCalories();
            if (_hunger < 0)
                _hunger = 0;
        }

        public int GetHealth()
        {
            return _health;
        }

        public override string ToString()
        {
            return $"{_name}: Stats = {_hunger}, {_health}, {_hygiene}";
        }
    }
}