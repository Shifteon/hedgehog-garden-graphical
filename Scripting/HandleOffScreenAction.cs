using System.Collections.Generic;
using hedgehog_garden_graphical.Casting;
using hedgehog_garden_graphical.Services;


namespace hedgehog_garden_graphical.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class HandleOffScreenAction : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor player = cast["player"][0];
            // Keep the player from going off screen
            if (player.GetX() > Constants.MAX_X - Constants.PLAYER_WIDTH)
                player.SetPosition(new Point(Constants.MAX_X - Constants.PLAYER_WIDTH, player.GetY()));
            if (player.GetX() <= 0)
                player.SetPosition(new Point(0, player.GetY()));
        }

    }
}