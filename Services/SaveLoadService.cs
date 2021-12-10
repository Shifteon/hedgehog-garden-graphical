using System;
using Raylib_cs;
using hedgehog_garden_graphical.Casting;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace hedgehog_garden_graphical.Services
{
    class SaveLoadService
    {
        public void Save(Dictionary<string, List<Actor>> cast)
        {
            Player p = (Player)cast["player"][0];

            Dictionary<string, Dictionary<string, string>> save = new Dictionary<string, Dictionary<string, string>>();

            save["player"] = new Dictionary<string, string>();
            save["player"].Add("numKibble", p.GetKibble().Count.ToString());
            save["player"].Add("money", p.GetMoney().ToString());

            // Dictionary<string, string> hedgehogs = new Dictionary<string, string>();
            int i = 0;
            foreach (Hedgehog h in cast["hedgehogs"])
            {
                save[$"hedgehog{i}"] = new Dictionary<string, string>();
                save[$"hedgehog{i}"].Add("name", h.GetName());
                save[$"hedgehog{i}"].Add("hunger", h.GetHunger().ToString());
                save[$"hedgehog{i}"].Add("health", h.GetHealth().ToString());
                save[$"hedgehog{i}"].Add("hygiene", h.GetHygiene().ToString());
                save[$"hedgehog{i}"].Add("shiny", h.IsShiny().ToString());
                save[$"hedgehog{i}"].Add("newHog", h.CanGetNewHog().ToString());
                i++;
            }

            string json = JsonConvert.SerializeObject(save, Formatting.Indented);
            File.WriteAllText("save.json", json);
        }

        public void Load(Dictionary<string, List<Actor>> cast)
        {
            string json = File.ReadAllText("save.json");
            Dictionary<string, Dictionary<string, string>> save = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            
            Player p = (Player)cast["player"][0];
            p.InitializePlayer(save["player"]["numKibble"], save["player"]["money"]);
            List<Actor> hedgehogs = cast["hedgehogs"];
            foreach (KeyValuePair<string, Dictionary<string, string>> data in save)
            {
                if (data.Key.Contains("hedgehog"))
                {
                    Hedgehog h = new Hedgehog(data.Value["name"], data.Value["hunger"], data.Value["health"], data.Value["hygiene"], data.Value["shiny"], data.Value["newHog"]);
                    hedgehogs.Add(h);
                }
            }
        }
    }
}