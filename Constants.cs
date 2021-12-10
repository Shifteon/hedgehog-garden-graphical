using System;

namespace hedgehog_garden_graphical
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 800;
        public const int MAX_Y = 600;
        public const int FRAME_RATE = 30;

        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;

        public const int PLAYER_SPEED = 15;

        public const int PLAYER_WIDTH = 39;
        public const int PLAYER_HEIGHT = 66;
        public const string IMAGE_PLAYER = "./Assets/player.png";
        public const string IMAGE_HEDGEHOG = "./Assets/hedgehog.png";
        public const string IMAGE_HEDGEHOG_SHINY = "./Assets/hedgehog(white).png";
        public const string IMAGE_STORE = "./Assets/store.png";

        public const int TEXTBOX_WIDTH = MAX_X / 2;
        public const int TEXTBOX_HEIGHT = 100;

        public const int TEXTBOX_X = 200;
        public const int TEXTBOX_Y = MAX_Y - 150;

        public const int BATHHOUSE_X = MAX_X / 2;
        public const int BATHHOUSE_Y = 100;

        public const int STORE_X = MAX_X / 2 - 200;
        public const int STORE_Y = 100;

        public const int GYM_X = MAX_X / 2 - 350;
        public const int GYM_Y = 100;

        public const int BUFFER_X = 300;
        public const int BUFFER_Y = 300;
        public const int BUFFER_WIDTH = 100;
        public const int BUFFER_HEIGHT = 50;

    }

}