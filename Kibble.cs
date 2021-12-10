namespace hedgehog_garden_graphical
{
    public class Kibble
    {
        protected int _calories = 100;
        protected string _name = "Kibble";
        protected int _price = 50;

        public string GetInfo()
        {
            return _name + ": $" + _price;
        }
        public int GetCalories()
        {
            return _calories;
        }
        public int GetPrice()
        {
            return _price;
        }
    }
}