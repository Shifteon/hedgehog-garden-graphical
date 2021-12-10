using System.Collections.Generic;
using System;

namespace hedgehog_garden_graphical.Casting
{
    class Player : Actor
    {
        private List<Hedgehog> _hedeghogs = new List<Hedgehog>();
        private int _money = 100;
        private List<Kibble> _kibble = new List<Kibble>();

        public Player()
        {
            SetImage(Constants.IMAGE_PLAYER);
            _width = Constants.PLAYER_WIDTH;
            _height = Constants.PLAYER_HEIGHT;
            _position = new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2);
        }

        public void InitializePlayer(string numKibble, string money)
        {
            int kibble = Int32.Parse(numKibble);
            for (int i = 0; i < kibble; i++)
            {
                _kibble.Add(new Kibble());
            }
            _money = Int32.Parse(money);
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

        public void AddKibble(Kibble kibble)
        {
            _kibble.Add(kibble);
        }

        public List<Kibble> GetKibble()
        {
            return _kibble;
        }
    }
}