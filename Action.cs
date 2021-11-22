using System;
using System.Collections.Generic;
using hedgehog_garden_graphical.Casting;

namespace hedgehog_garden_graphical
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public abstract class Action
    {
        public abstract void Execute(Dictionary<string, List<Actor>> cast);
    }
}