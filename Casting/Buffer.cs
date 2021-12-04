using System;

namespace hedgehog_garden_graphical.Casting
{
    public class Buffer : Actor
    {
        private Actor _callBack;

        public Buffer(Actor a)
        {
            _position = new Point(Constants.BUFFER_X, Constants.BUFFER_Y);
            _width = Constants.TEXTBOX_WIDTH;
            _height = Constants.TEXTBOX_HEIGHT;
            _callBack = a;
            SetIsTextbox(true);
        }

        public void Update(char keyPress)
        {
            if (keyPress != '\0')
            {
                _text = _text + keyPress;
            }
            if (keyPress == 'ă' && _text != "ă")
            {
                _text = _text.Remove(_text.Length - 2, 2);
            }
        }

        public void Clear()
        {
            _callBack.SetSelection(_text);
            _text = "";
        }
    }
}
