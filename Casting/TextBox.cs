namespace hedgehog_garden_graphical.Casting
{
    /// <summary>
    /// Defines a textbox
    /// </summary>
    class TextBox : Actor
    {
        public TextBox(string text)
        {
            _width = Constants.TEXTBOX_WIDTH;
            _height = Constants.TEXTBOX_HEIGHT;
            _text = text;
            _position = new Point(Constants.TEXTBOX_X, Constants.TEXTBOX_Y);

            SetIsTextbox(true);
        }
    }
}