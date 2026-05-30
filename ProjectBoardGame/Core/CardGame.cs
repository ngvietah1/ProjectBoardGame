using Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public class CardGame:BoardGame
    {
        public override string Type => "CardGame";
        public int NumberCards { get; private set; }
        public int NumberCardsEachPlayer { get; private set; }

        public CardGame(string name, (int, int) numberplayers, int agelimit, string description, int numbercards, int numberCardsEachPlayer) : base(name, numberplayers,
            agelimit, description)
        {
            NumberCards = numbercards;
            NumberCardsEachPlayer = numberCardsEachPlayer;
            CountRating();
        }
        public override void CountRating()
        {
            Rating = (NumberPlayers.Item2 * 2 + NumberCards - NumberCardsEachPlayer) * 5;
        }
        public override string GetInformation()
        {
            string info = base.GetInformation();
            info += $"{Environment.NewLine}" +
                    $"-Количество карт: {NumberCards}{Environment.NewLine}" +
                    $"-Количество карт у каждого игрока: {NumberCardsEachPlayer}{Environment.NewLine}" +
                    $"-Рейтинг: {Rating}";
            return info;
        }
    }
}
