using System.Collections.Generic;
using hedgehog_garden_graphical.Casting;
using hedgehog_garden_graphical.Services;
using System;


namespace hedgehog_garden_graphical.Scripting
{
    class InputBufferAction : Action
    {
        InputService _inputService;

        public InputBufferAction(InputService inputService)
        {
            _inputService = inputService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            if (cast["buffer"].Count != 0)
            {
                Casting.Buffer buffer = (Casting.Buffer)cast["buffer"][0];
                // Console.WriteLine(buffer.GetText());
                buffer.Update(_inputService.GetChar());
                if (_inputService.IsEnterPressed())
                {
                    buffer.Clear();
                    cast["buffer"].Remove(buffer);
                }
            }
        }
    }
}