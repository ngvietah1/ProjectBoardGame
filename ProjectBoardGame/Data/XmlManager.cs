using Model.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Model.Data
{
    public class XmlManager:FileManager
    {
        public XmlManager() : base("boardgame.xml") { }
        public override void Serialize(IGameCatalog catalog)
        {
            List<DTOBoardGame> list=new List<DTOBoardGame>();
            File.WriteAllText(FilePath, "");
            foreach(var i in catalog.Catalog)
            {
                if (i.GetType().Name == "CardGame")
                {
                    list.Add(new DTOBoardGame(i.Name, i.NumberPlayers, i.AgeLimit, i.Description, (i as CardGame).NumberCards, (i as CardGame).NumberCardsEachPlayer, i.Rating, i.GetType().Name));
                }
                else if (i.GetType().Name == "EuroGame")
                {
                    list.Add(new DTOBoardGame(i.Name, i.NumberPlayers, i.AgeLimit, i.Description, (i as EuroGame).ResourceTypes, (i as EuroGame).StorageCapacity, i.Rating, i.GetType().Name));
                }
                else if(i.GetType().Name == "PartyGame")
                {
                    list.Add(new DTOBoardGame(i.Name, i.NumberPlayers, i.AgeLimit, i.Description, (i as PartyGame).Duration, (i as PartyGame).IsTeamBased, i.Rating, i.GetType().Name));
                }
            }
            DTO tmp = new DTO(list);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DTO));
            using(FileStream fs=new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, tmp);
            }
        }
        public override IGameCatalog Deserialize()
        {
            if (!File.Exists(FilePath)) return null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DTO));
            DTO tmp = null;
            string content = File.ReadAllText(FilePath);
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                tmp = xmlSerializer.Deserialize(fs) as DTO;
            }
            BoardGame[] array = new BoardGame[0];
            foreach(var i in tmp.Game)
            {
                if (i.Type == "CardGame")
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = new CardGame(i.Name, i.NumberPlayers, i.AgeLimit, i.Description, i.NumberCards, i.NumberCardsEachPlayer);
                }
                else if (i.Type == "EuroGame")
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = new EuroGame(i.Name, i.NumberPlayers, i.AgeLimit, i.Description, i.ResourceTypes, i.StorageCapacity);
                }
                else if (i.Type == "PartyGame")
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = new PartyGame(i.Name, i.NumberPlayers, i.AgeLimit, i.Description, i.Duration, i.IsTeamBased);
                }
            }
            IGameCatalog obj = new GameCatalog();
            obj.Add(array);
            return obj;
        }
    }
    public class DTO
    {
        public List<DTOBoardGame> Game { get; set; }
        public DTO(List<DTOBoardGame> game)
        {
            Game = game;
        }
        public DTO()
        {
            Game = null;
        }
    }
    public class DTOBoardGame
    {
        public string Name { get; set; }
        public (int, int) NumberPlayers { get; set; }
        public int AgeLimit { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int NumberCards { get; set; }
        public int NumberCardsEachPlayer { get; set; }
        public string ResourceTypes { get; set; }
        public int StorageCapacity { get; set; }
        public int Duration { get; set; }
        public bool IsTeamBased { get; set; }
        public string Type { get; set; }
        public DTOBoardGame(string name, (int, int) numberplayers, int agelimit, string description, int numbercards, int numberCardsEachPlayer, int rating, string type)
        {
            Name = name;
            NumberPlayers = numberplayers;
            AgeLimit = agelimit;
            Description = description;
            NumberCards = numbercards;
            NumberCardsEachPlayer = numberCardsEachPlayer;
            Rating = rating;
            Type = type;
        }
        public DTOBoardGame(string name, (int, int) numberplayers, int agelimit, string description, string resourcetypes, int storagecapacity, int rating, string type)
        {
            Name = name;
            NumberPlayers = numberplayers;
            AgeLimit = agelimit;
            Description = description;
            ResourceTypes = resourcetypes;
            StorageCapacity = storagecapacity;
            Rating = rating;
            Type = type;
        }
        public DTOBoardGame(string name, (int, int) numberplayers, int agelimit, string description, int duration, bool isteambased, int rating, string type)
        {
            Name = name;
            NumberPlayers = numberplayers;
            AgeLimit=agelimit;
            Description = description;
            Duration = duration;
            IsTeamBased = isteambased;
            Rating = rating;
            Type = type;
        }
        public DTOBoardGame() { }
    }
}
