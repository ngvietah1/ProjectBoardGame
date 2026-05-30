using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public class PartyGame:BoardGame
    {
        public override string Type => "PartyGame";
        public int Duration { get; private set; }
        public bool IsTeamBased { get; private set; }

        public PartyGame(string name, (int, int) numberplayers, int agelimit, string description, int duration,
            bool isteambased) : base(name, numberplayers,
            agelimit, description)
        {
            Duration = duration;
            IsTeamBased = isteambased;
            CountRating();
        }
        public override void CountRating()
        {
            if (IsTeamBased)
            {
                Rating = (NumberPlayers.Item2 * 6 + Duration) * 2;
            }
            else
            {
                Rating = (NumberPlayers.Item2 * 3 + Duration * 2) * 3;
            }
        }
        public override string GetInformation()
        {
            string info = base.GetInformation();
            info += $"{Environment.NewLine}" +
                    $"-Продолжительность: {Duration}{Environment.NewLine}" +
                    $"-Командная игра: {IsTeamBased}{Environment.NewLine}" +
                    $"-Рейтинг: {Rating}";
            return info;
        }
    }
}
