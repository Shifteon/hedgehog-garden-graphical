using System.Collections.Generic;

namespace hedgehog_garden_graphical.Casting
{
    class Player : Actor
    {
        private string _name;
        private List<Hedgehog> _hedeghogs = new List<Hedgehog>();
        private int _money = 100;
        private List<Food> _food = new List<Food>();

        public Player()
        {
            _width = Constants.PLAYER_WIDTH;
            _height = Constants.PLAYER_HEIGHT;
            _position = new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2);
            _name = "Bob";
            _food.Add(new Kibble());
        }

        public void AddHedgehog(Hedgehog h)
        {
            _hedeghogs.Add(h);
        }

        public List<Hedgehog> GetHedgehogs()
        {
            return _hedeghogs;
        }

        public int GetMoney()
        {
            return _money;
        }

        public void AddMoney(int money)
        {
            _money += money;
        }

        public void AddFood(Food food)
        {
            _food.Add(food);
        }

        public List<Food> GetFood()
        {
            return _food;
        }
    }
}