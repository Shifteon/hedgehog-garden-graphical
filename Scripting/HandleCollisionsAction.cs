using System.Collections.Generic;
using hedgehog_garden_graphical.Casting;
using hedgehog_garden_graphical.Services;


namespace hedgehog_garden_graphical.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private PhysicsService _physicsService;
        private AudioService _audioService;
        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor p = cast["player"][0];
            // Actor s = cast["store"][0];
            // Actor b = cast["bathhouse"][0];
            // Actor g = cast["gym"][0];

            // if (_physicsService.IsCollision(p, s))
            // {
            //     p.SetPosition(new Point(p.GetX() + Constants.PLAYER_WIDTH, p.GetY() + Constants.PLAYER_HEIGHT));
            // }
            // if (_physicsService.IsCollision(p, b))
            // {
            //     p.SetPosition(new Point(p.GetX() + Constants.PLAYER_WIDTH, p.GetY() + Constants.PLAYER_HEIGHT));
            // }
            // if (_physicsService.IsCollision(p, g))
            // {
            //     p.SetPosition(new Point(p.GetX() + Constants.PLAYER_WIDTH, p.GetY() + Constants.PLAYER_HEIGHT));
            // }

            foreach (Actor hedge in cast["hedgehogs"])
            {
                foreach (Actor hog in cast["hedgehogs"])
                {
                    if (hedge != hog)
                    {
                        if (_physicsService.IsCollision(hedge, hog))
                        {
                            hog.SetPosition(new Point(hog.GetX() + 30, hog.GetY() + 30));
                        }
                    }
                }
            }
        }

    }
}