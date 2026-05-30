using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public abstract class BoardGame
    {
        public string Name { get; private set; }
        public (int, int) NumberPlayers { get; private set; }
        public int AgeLimit { get; private set; }
        public string Description { get; private set; }
        public int Rating { get; protected set; }
        public virtual string Type => "BoardGame";

        public BoardGame(string name, (int, int) numberplayers, int agelimit, string description)
        {
            Name = name;
            NumberPlayers = numberplayers;
            AgeLimit = agelimit;
            Description = description;
            Rating = 0;
        }
        public BoardGame() { }
        public virtual string GetInformation()
        {
            return $"-Название: {Name}{Environment.NewLine}" +
                   $"-Тип: {Type}{Environment.NewLine}" +
                   $"-Количество игроков: {NumberPlayers.Item1}-{NumberPlayers.Item2}{Environment.NewLine}" +
                   $"-Возрастное ограничение: {AgeLimit}{Environment.NewLine}" +
                   $"-Описание: {Description}";
        }
        public abstract void CountRating();
    }
}
