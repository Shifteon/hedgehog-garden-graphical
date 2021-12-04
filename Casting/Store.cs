using System.Collections.Generic;

namespace hedgehog_garden_graphical.Casting
{
    class Store : Actor
    {
        private Dictionary<string, Food> _inventory = new Dictionary<string, Food>();
        public Store()
        {
            _width = 100;
            _height = 100;
            _position = new Point(Constants.STORE_X, Constants.STORE_Y - 50);
            _inventory["kibble"] = new Kibble();
        }

        public string GetInventory()
        {
            string inventory = "";
            foreach (Food f in _inventory.Values)
            {
                inventory += f.GetInfo() + "\n";
            }
            return inventory;
        }

        public Food Purchase(string item, int money)
        {
            item = item.ToLower();
            Food food = null;
            if (_inventory.ContainsKey(item))
            {
                switch (item)
                {
                    case "kibble":
                        if (money >= _inventory["kibble"].GetPrice())
                            food = new Kibble();
                        break;
                    default:
                        break;
                }       
            }
            _selection = " ";
            return food;
        }
    }
}