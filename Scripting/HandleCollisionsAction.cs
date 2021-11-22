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
            Ball ball = (Ball)cast["balls"][0];
            Actor paddle = cast["paddle"][0];

            if (_physicsService.IsCollision(ball, paddle))
            {
                _audioService.PlaySound(Constants.SOUND_BOUNCE);
                ball.BounceVertical();
            }

            List<Brick> bricksToRemove = new List<Brick>();
            foreach (Brick brick in cast["bricks"])
            {
                if (_physicsService.IsCollision(ball, brick))
                {
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    ball.BounceVertical();
                    bricksToRemove.Add(brick);
                    // Add points
                    ScoreBoard score = (ScoreBoard)cast["scoreboard"][0];
                    score.AddPoints(5);
                }
            }

            foreach (Brick brick in bricksToRemove)
            {
                if (cast["bricks"].Contains(brick))
                    cast["bricks"].Remove(brick);
            }
            
        }

    }
}