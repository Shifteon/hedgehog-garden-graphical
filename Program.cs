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

            // Create a bathhouse
            cast["bathhouse"] = new List<Actor>();
            cast["bathhouse"].Add(new Bathhouse());

            // Create a store
            cast["store"] = new List<Actor>();
            cast["store"].Add(new Store());

            // Cretae a gym
            cast["gym"] = new List<Actor>();
            cast["gym"].Add(new Gym());

            // Create a hedgehog
            cast["hedgehogs"] = new List<Actor>();

            // Create a player
            cast["player"] = new List<Actor>();
            cast["player"].Add(new Player());
            Player p = (Player)cast["player"][0];

            // Create a textbox
            cast["textbox"] = new List<Actor>();

            // Create a buffer
            cast["buffer"] = new List<Actor>();

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();
            TextboxService textboxService = new TextboxService(cast);

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            script["update"].Add(new MoveActorsAction());
            script["update"].Add(new HandleOffScreenAction());
            script["update"].Add(new HandleCollisionsAction(physicsService, audioService));
            script["update"].Add(new InteractAction(inputService, physicsService, textboxService));
            script["update"].Add(new UpdateAction(textboxService));

            script["input"].Add(new ControlActorsAction(inputService, textboxService));
            script["input"].Add(new InputBufferAction(inputService));

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Hedgehog Garden", Constants.FRAME_RATE);
            audioService.StartAudio();
            // audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
