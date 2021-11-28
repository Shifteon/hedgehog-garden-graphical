using System.Collections.Generic;
using hedgehog_garden_graphical.Casting;
using hedgehog_garden_graphical.Services;


namespace hedgehog_garden_graphical.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class ControlActorsAction : Action
    {
        InputService _inputService;

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            // We can only move left and right
            direction = new Point(direction.GetX(), 0);
            Actor player = cast["player"][0];

            Point velocity = direction.Scale(Constants.PLAYER_SPEED);
            player.SetVelocity(velocity);
        }

    }
}