namespace hedgehog_garden_graphical
{
    public class Food
    {
        protected int _calories = 100;
        protected string _name;
        protected int _price;

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

    public class Kibble: Food
    {
        public Kibble()
        {
            _name = "Kibble";
            _price = 50;
        }
        

        public override string ToString()
        {
            return "Kibble";
        }
    }
}