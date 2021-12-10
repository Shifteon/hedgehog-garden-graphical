using System.Collections.Generic;
using hedgehog_garden_graphical.Casting;
using hedgehog_garden_graphical.Services;
using System;


namespace hedgehog_garden_graphical.Scripting
{
    class InteractAction : Action
    {
        InputService _inputService;
        PhysicsService _physics;
        TextboxService _textboxService;

        public InteractAction(InputService inputService, PhysicsService physics, TextboxService textboxService)
        {
            _inputService = inputService;
            _physics = physics;
            _textboxService = textboxService;
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
            // Handle interctions with the bathhouse, store, gym, and hedgehogs
            if (cast["buffer"].Count == 0)
            {
                BathhouseInteraction(cast);
                StoreInteraction(cast);
                GymInteraction(cast);
                HedgehogInteraction(cast);
            }
        }

        private void HedgehogInteraction(Dictionary<string, List<Actor>> cast)
        {
            Player p = (Player)cast["player"][0];
            foreach (Hedgehog h in cast["hedgehogs"])
            {
                if (_physics.IsCollision(h, p))
                {
                    if (_inputService.IsSpacePressed())
                    {
                        _textboxService.CreateTextbox($"This is {h.ToString()}\nPress F to feed and W to have\nthem follow.", 5);
                    }
                    if (_inputService.IsWPressed())
                            p.AddHedgehog(h);
                    if (_inputService.IsFPressed())
                    {
                        if (p.GetKibble().Count != 0)
                        {
                            h.Feed(p.GetKibble()[p.GetKibble().Count - 1]);
                            p.GetKibble().RemoveAt(p.GetKibble().Count - 1);
                            _textboxService.CreateTextbox($"You fed {h.GetName()}!");
                        }
                        else
                            _textboxService.CreateTextbox("You have no food!");
                    }
                }
            }
            if (p.GetHedgehogs().Count != 0)
            {
                if (_inputService.IsSPressed())
                {
                    p.GetHedgehogs().Clear();
                }
            }
        }

        private void BathhouseInteraction(Dictionary<string, List<Actor>> cast)
        {
            if (_physics.IsCollision(cast["player"][0], cast["bathhouse"][0]))
            {
                if (_inputService.IsSpacePressed())
                {
                    _textboxService.CreateTextbox("Press W to wash all hedgehogs.");
                }
                if (_inputService.IsWPressed())
                {
                    Player p = (Player)cast["player"][0];
                    foreach (Hedgehog h in p.GetHedgehogs())
                    {
                        h.Wash();
                        p.AddMoney(10);
                    }
                }
            }
        }

        private void StoreInteraction(Dictionary<string, List<Actor>> cast)
        {
            Store store = (Store)cast["store"][0];
            if (_physics.IsCollision(cast["player"][0], store))
            {
                if (_inputService.IsSpacePressed())
                {
                    _textboxService.CreateTextbox("Press W to buy kibble at the store");
                }
                if (_inputService.IsWPressed())
                {
                    Player p = (Player)cast["player"][0];
                    Kibble k = new Kibble();
                    if (p.GetMoney() >= k.GetPrice())
                    {
                        p.AddKibble(k);
                        // Charge the player
                        p.AddMoney(-k.GetPrice());
                        _textboxService.CreateTextbox("You got kibble!");
                    }
                    else
                    {
                        _textboxService.CreateTextbox("You don't have enough money!\n" +
                                                      "Go to the gym or bathhouse to earn\nsome.");
                    }
                    
                }
            }
        }

        private void GymInteraction(Dictionary<string, List<Actor>> cast)
        {
            if (_physics.IsCollision(cast["player"][0], cast["gym"][0]))
            {
                if (_inputService.IsSpacePressed())
                {
                    _textboxService.CreateTextbox("Press W to exercise all hedgehogs");
                }
                if (_inputService.IsWPressed())
                {
                    Player p = (Player)cast["player"][0];
                    foreach (Hedgehog h in p.GetHedgehogs())
                    {
                        h.Exercise();
                        p.AddMoney(10);
                    }
                }
            }
        }
    }
}