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
            if (player.GetY() > Constants.MAX_Y - Constants.PLAYER_HEIGHT)
                player.SetPosition(new Point(player.GetX() ,Constants.MAX_Y - Constants.PLAYER_HEIGHT));
            if (player.GetY() <= Constants.BATHHOUSE_Y)
                player.SetPosition(new Point(player.GetX(), Constants.BATHHOUSE_Y));
            foreach (Hedgehog h in cast["hedgehogs"])
            {
                if (h.GetX() > Constants.MAX_X - Constants.HEDGEHOG_WIDTH || h.GetX() <= 0)
                    h.SetVelocity(new Point(h.GetVelocity().GetX() * -1, h.GetVelocity().GetY()));
                if (h.GetY() > Constants.MAX_Y - Constants.HEDGEHOG_HEIGHT || h.GetY() <= Constants.BATHHOUSE_Y)
                    h.SetVelocity(new Point(h.GetVelocity().GetX(), h.GetVelocity().GetY() * -1));
                if (h.GetX() > Constants.MAX_X || h.GetX() < 0 || h.GetY() > Constants.MAX_Y || h.GetY() < 0)
                    h.SetPosition(new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2));
            }
        }

    }
}