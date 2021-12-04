using Raylib_cs;
using System;

namespace hedgehog_garden_graphical.Casting
{
    /// <summary>
    /// Defines a textbox
    /// </summary>
    class TextBox : Actor
    {
        // TODO: Change reszie back to true after fixing the function
        public TextBox(string text, bool resize = false)
        {
            _text = text;
            _height = Constants.TEXTBOX_HEIGHT;
            _width = Constants.TEXTBOX_WIDTH;
            if (resize)
            {
                Resize();
            }
            else
            {
                _position = new Point(Constants.TEXTBOX_X, Constants.TEXTBOX_Y);
            }

            SetIsTextbox(true);
        }

        private void Resize()
        {
            int width = Raylib.MeasureText("Benjamin Wyatt", Constants.DEFAULT_FONT_SIZE);
            Console.WriteLine($"width: {width}");

            // int length = _text.Length;
            // if (width > Constants.TEXTBOX_WIDTH)
            // {
            //     int index = 35;
            //     int y = Constants.TEXTBOX_Y;
            //     while (index < length)
            //     {
            //         _text = _text.Insert(index, "\n");
            //         index += 35;
            //         _height += 20;
            //         y -= 20;
            //     }
            //     _position = new Point(Constants.TEXTBOX_X, y);
            // }
        }
    }
}