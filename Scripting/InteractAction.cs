using System.Collections.Generic;
using hedgehog_garden_graphical.Casting;
using hedgehog_garden_graphical.Services;


namespace hedgehog_garden_graphical.Scripting
{
    class InteractAction : Action
    {
        InputService _inputService;

        public InteractAction(InputService inputService)
        {
            _inputService = inputService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            // Remove the textbox if the user presses the space bar
            if (cast["textbox"].Count != 0)
            {
                if (_inputService.IsSpacePressed())
                {
                    cast["textbox"].Remove(cast["textbox"][0]);
                }
            }
        }
    }
}