using Model.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public class JsonManager:FileManager
    {
        public JsonManager() : base("boardgame.json") { }
        public override void Serialize(IGameCatalog catalog)
        {
            string content = JsonConvert.SerializeObject(catalog, Formatting.Indented);
            File.WriteAllText(FilePath, content);
        }
        public override IGameCatalog Deserialize()
        {
            if (File.Exists(FilePath))
            {
                string content = File.ReadAllText(FilePath);
                string[] strings = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> dict = new Dictionary<string, string>();
                BoardGame[] array = new BoardGame[0];
                int count = 0;
                for (int i = 0; i < strings.Length; i++)
                {
                    if (strings[i].Contains("ResourceTypes"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["ResourceTypes"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("Type"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["Type"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("NumberCardsEachPlayer"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["NumberCardsEachPlayer"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("NumberCards"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["NumberCards"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("Name"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["Name"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("Item"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict[$"Item{count}"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                        count++;
                    }
                    else if (strings[i].Contains("AgeLimit"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["AgeLimit"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("Description"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["Description"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("StorageCapacity"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["StorageCapacity"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("Duration"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["Duration"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("IsTeamBased"))
                    {
                        string[] tmp = strings[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        dict["IsTeamBased"] = tmp[1].Trim(new char[] { ' ', '"', ',' });
                    }
                    else if (strings[i].Contains("Rating"))
                    {
                        Array.Resize(ref array, array.Length + 1);
                        if (dict["Type"] == "CardGame")
                        {
                            array[array.Length - 1] = new CardGame(dict["Name"], (int.Parse(dict["Item0"]), int.Parse(dict["Item1"])), int.Parse(dict["AgeLimit"]), dict["Description"], int.Parse(dict["NumberCards"]), int.Parse(dict["NumberCardsEachPlayer"]));
                        }
                        else if (dict["Type"] == "EuroGame")
                        {
                            array[array.Length - 1] = new EuroGame(dict["Name"], (int.Parse(dict["Item0"]), int.Parse(dict["Item1"])), int.Parse(dict["AgeLimit"]), dict["Description"], dict["ResourceTypes"], int.Parse(dict["StorageCapacity"]));
                        }
                        else if (dict["Type"] == "PartyGame")
                        {
                            array[array.Length - 1] = new PartyGame(dict["Name"], (int.Parse(dict["Item0"]), int.Parse(dict["Item1"])), int.Parse(dict["AgeLimit"]), dict["Description"], int.Parse(dict["Duration"]), bool.Parse(dict["IsTeamBased"]));
                        }
                        count = 0;
                    }                   
                }
                IGameCatalog obj = new GameCatalog(FilePath);
                obj.Add(array);
                return obj;
            }
            return null;
        }
    }
}
