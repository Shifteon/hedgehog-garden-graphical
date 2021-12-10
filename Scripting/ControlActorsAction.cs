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
        private InputService _inputService;
        private TextboxService _textboxService;

        public ControlActorsAction(InputService inputService, TextboxService textboxService)
        {
            _inputService = inputService;
            _textboxService = textboxService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            Actor player = cast["player"][0];

            Point velocity = direction.Scale(Constants.PLAYER_SPEED);
            player.SetVelocity(velocity);

            MoveHedgehogs(cast);
            DisplayStatus(cast);
        }

        private void MoveHedgehogs(Dictionary<string, List<Actor>> cast)
        {
            Player p = (Player)cast["player"][0];
            foreach (Hedgehog h in p.GetHedgehogs())
            {
                h.SetPosition(new Point(p.GetX() + 30, p.GetY() + 30));
            }
        }

        private void DisplayStatus(Dictionary<string, List<Actor>> cast)
        {
            Player p = (Player)cast["player"][0];
            if (_inputService.IsDPressed())
            {
                _textboxService.CreateTextbox($"You have {p.GetKibble().Count} kibble\n" +
                                              $"You have ${p.GetMoney()}\n" +
                                              $"You have {cast["hedgehogs"].Count} hedgehogs");
            }
        }

    }
}