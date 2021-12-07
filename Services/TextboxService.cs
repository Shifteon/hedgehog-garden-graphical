using hedgehog_garden_graphical.Casting;
using System.Collections.Generic;

namespace hedgehog_garden_graphical.Services
{
    class TextboxService
    {
        private Dictionary<string, List<Actor>> _cast;

        public TextboxService(Dictionary<string, List<Actor>> cast)
        {
            _cast = cast;
        }
        public void CreateTextbox(string text)
        {
            if (_cast["textbox"].Count == 0)
                _cast["textbox"].Add(new TextBox(text));
            else
                _cast["textbox"][0] = new TextBox(text);
            return;
        }
    }
}