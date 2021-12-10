using hedgehog_garden_graphical.Casting;
using System.Collections.Generic;

namespace hedgehog_garden_graphical.Services
{
    public class TextboxService
    {
        private Dictionary<string, List<Actor>> _cast;

        public TextboxService(Dictionary<string, List<Actor>> cast)
        {
            _cast = cast;
        }
        public void CreateTextbox(string text, int duration = 0)
        {
            if (_cast["textbox"].Count == 0)
            {
                _cast["textbox"].Add(new TextBox(text, duration));
            }
            else
            {
                _cast["textbox"][0] = new TextBox(text, duration);
            }
            return;
        }

        public void DestroyTextBox(Actor t)
        {
            _cast["textbox"].Remove(t);
            return;
        }
    }
}