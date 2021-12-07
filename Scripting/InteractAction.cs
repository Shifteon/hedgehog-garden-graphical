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
                    _textboxService.CreateTextbox($"This is {h.GetName()}");
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
                    _textboxService.CreateTextbox("Press W to buy things at the store");
                }
                if (_inputService.IsWPressed())
                {
                    Player p = (Player)cast["player"][0];
                    _textboxService.CreateTextbox("Enter an item to purchase\n" + store.GetInventory());
                    cast["buffer"].Add(new Casting.Buffer(store));
                }
                // if (cast["buffer"].Count == 0)
                // {
                //     Player p = (Player)cast["player"][0];
                //     Food f = store.Purchase(store.GetSelection(), p.GetMoney());
                //     if (f != null)
                //         p.AddFood(f);
                //     else if (store.GetSelection() != "")
                //         cast["textbox"].Add(new TextBox("Please select an item in stock or make sure you have enough money."));
                // }
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
                    }
                }
            }
        }
    }
}