using System.Collections.Generic;
using System;

namespace hedgehog_garden_graphical.Casting
{
    class Hedgehog : Actor
    {
        protected string _name = "Harry";
        protected int _hunger = 200;
        protected int _health = 100;
        protected int _hygiene = 100;
        protected bool _canGetNewHog = true;
        protected bool _isShiny = false;
        protected bool _isSpecial = false;
        protected Dictionary<string, int> _maxStats = new Dictionary<string, int>();

        public Hedgehog()
        {
            Shiny(); // Check if it is shiny
            if (_isShiny)
                SetImage(Constants.IMAGE_HEDGEHOG_SHINY);
            else
                SetImage(Constants.IMAGE_HEDGEHOG);
            _width = Constants.HEDGEHOG_WIDTH;
            _height = Constants.HEDGEHOG_HEIGHT;
            Random r = new Random();
            _position = new Point(r.Next(100, Constants.MAX_X - 100), r.Next(200, Constants.MAX_Y - 200));
            if (r.Next(1,20) < 11)
                _velocity = new Point(2, 0);
            else
                _velocity = new Point(0, 2);
            // Set up the max stats
            _maxStats["maxHunger"] = 0;
            _maxStats["maxHealth"] = 300;
            _maxStats["maxHygiene"] = 300;
        }

        public Hedgehog(string name, string hunger, string health, string hygiene, string shiny, string newHog)
        {
            InitializeHedgehog(name, hunger, health, hygiene, shiny, newHog);
            if (_isShiny)
                SetImage(Constants.IMAGE_HEDGEHOG_SHINY);
            else
                SetImage(Constants.IMAGE_HEDGEHOG);
            _width = Constants.HEDGEHOG_WIDTH;
            _height = Constants.HEDGEHOG_HEIGHT;
            Random r = new Random();
            _position = new Point(r.Next(100, Constants.MAX_X - 100), r.Next(200, Constants.MAX_Y - 200));
            if (r.Next(1,20) < 11)
                _velocity = new Point(2, 0);
            else
                _velocity = new Point(0, 2);
            // Set up the max stats
            _maxStats["maxHunger"] = 0;
            _maxStats["maxHealth"] = 300;
            _maxStats["maxHygiene"] = 300;
        }

        private void Shiny()
        {
            Random r = new Random();
            if (r.Next(1, 100) == 10)
                _isShiny = true;
        }

        public override void SetSelection(string selection)
        {
            base.SetSelection(selection);
            _name = selection;
        }

        public bool IsShiny()
        {
            return _isShiny;
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

        public void Feed(Kibble kibble)
        {
            if (_hunger > 0)
                _hunger -= kibble.GetCalories();
            if (_hunger < 0)
                _hunger = 0;
        }

        public int GetHealth()
        {
            return _health;
        }

        public int GetHunger()
        {
            return _hunger;
        }

        public int GetHygiene()
        {
            return _hygiene;
        }

        public string GetName()
        {
            return _name;
        }

        public bool IsMaxed()
        {
            return _health == _maxStats["maxHealth"] && _hygiene == _maxStats["maxHygiene"]
             && _hunger == _maxStats["maxHunger"];
        }

        public bool CanGetNewHog()
        {
            return _canGetNewHog;
        }

        public void GotNewHog()
        {
            _canGetNewHog = false;
        }

        public bool IsSpecial()
        {
            return _isSpecial;
        }

        public void Wander()
        {
            Random r = new Random();
            if (r.Next(1, 100) == 10)
                _velocity = new Point(0, 2);
            else if (r.Next(1, 100) == 20)
                _velocity = new Point(2, 0);
        }

        protected void InitializeHedgehog(string name, string hunger, string health, string hygiene, string shiny, string newHog)
        {
            _name = name;
            _hunger = Int32.Parse(hunger);
            _health = Int32.Parse(health);
            _hygiene = Int32.Parse(hygiene);
            if (shiny == "True")
                _isShiny = true;
            else
                _isShiny = false;
            if (newHog == "True")
                _canGetNewHog = true;
            else
                _canGetNewHog = false;
        }

        public override string ToString()
        {
            return $"{_name}: Stats = {_hunger}, {_health}, {_hygiene}";
        }
    }
}