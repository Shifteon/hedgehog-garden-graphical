using System;
using hedgehog_garden_graphical.Services;
using hedgehog_garden_graphical.Casting;
using hedgehog_garden_graphical.Scripting;
using System.Collections.Generic;

namespace hedgehog_garden_graphical
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Create a hedgehog
            cast["hedgehogs"] = new List<Actor>();
            cast["hedgehogs"].Add(new Hedgehog());

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            script["update"].Add(new MoveActorsAction());
            script["update"].Add(new HandleOffScreenAction());
            script["update"].Add(new HandleCollisionsAction(physicsService, audioService));

            script["input"].Add(new ControlActorsAction(inputService));

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Hedgehog Garden", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
