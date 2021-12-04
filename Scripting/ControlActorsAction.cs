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

            DisplayHedgehogs(cast);
        }

        private void DisplayHedgehogs(Dictionary<string, List<Actor>> cast)
        {
            if (_inputService.IsSPressed() && cast["buffer"].Count == 0)
            {
                Player p = (Player)cast["player"][0];
                string text = "";
                int height = Constants.TEXTBOX_HEIGHT;
                int y = Constants.TEXTBOX_Y;
                // TODO: Fix how the textbox resizes and moves. See if this can be moved to the textbox
                foreach (Hedgehog h in p.GetHedgehogs())
                {
                    text += $"{h.ToString()}\n";
                    height += 20;
                    y -= 20;
                } 
                cast["textbox"].Add(new TextBox(text, false));
            }
        }

        private void DisplayFood(Dictionary<string, List<Actor>> cast)
        {
            
        }

    }
}