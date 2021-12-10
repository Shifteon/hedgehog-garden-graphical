using System.Collections.Generic;
using hedgehog_garden_graphical.Casting;
using hedgehog_garden_graphical.Services;

namespace hedgehog_garden_graphical.Scripting
{
    class UpdateAction : Action
    {
        TextboxService _textboxService;
        public UpdateAction(TextboxService ts)
        {
            _textboxService = ts;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            // DestroyTextbox(cast);
            GetNewHedgehog(cast);
            // TODO: See if wandering can be made better
            // HedgehogWander(cast);
        }

        private void GetNewHedgehog(Dictionary<string, List<Actor>> cast)
        {
            bool newHog = false;
            foreach (Hedgehog h in cast["hedgehogs"])
            {
                if (h.IsMaxed() && h.CanGetNewHog())
                {
                    newHog = true;
                    h.GotNewHog();
                    _textboxService.CreateTextbox("You got a new hedgehog!\nEnter a name for them!");
                }
            }
            if (newHog)
            {
                Hedgehog h = new Hedgehog();
                cast["buffer"].Add(new Buffer(h));
                cast["hedgehogs"].Add(h);
            }
        }

        private void HedgehogWander(Dictionary<string, List<Actor>> cast)
        {
            Player p = (Player)cast["player"][0];
            foreach (Hedgehog h in cast["hedgehogs"])
            {
                if (!p.GetHedgehogs().Contains(h))
                {
                    h.Wander();
                }
            }
        }

        // TODO: Decide if I want this still
        private void DestroyTextbox(Dictionary<string, List<Actor>> cast)
        {
            if (cast["textbox"].Count != 0)
            {
                TextBox t = (TextBox)cast["textbox"][0];
                if (t.GetDuration() != 0)
                {
                    if (t.GetCreationTime().AddSeconds(t.GetDuration()) > t.GetCreationTime())
                    {
                        // TODO: Uncomment this when the logic is fixed
                        // cast["textbox"].Remove(t);
                    }
                }
            }
        }
    }
}