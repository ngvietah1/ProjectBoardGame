using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public class EuroGame:BoardGame
    {
        public override string Type => "EuroGame";
        public string ResourceTypes { get; private set; }
        public int StorageCapacity { get; private set; }

        public EuroGame(string name, (int, int) numberplayers, int agelimit, string description, string resourcetypes,
            int storagecapacity) : base(name, numberplayers,
            agelimit, description)
        {
            ResourceTypes = resourcetypes;
            StorageCapacity = storagecapacity;
            CountRating();
        }
        public override void CountRating()
        {
            Rating = (NumberPlayers.Item2 * 6 + StorageCapacity * 2) * 3;
        }
        public override string GetInformation()
        {
            string info = base.GetInformation();
            info += $"{Environment.NewLine}" +
                    $"-Типы ресурсов: {ResourceTypes}{Environment.NewLine}" +
                    $"-Вместимость хранилища: {StorageCapacity}{Environment.NewLine}" +
                    $"-Рейтинг: {Rating}{Environment.NewLine}";
            return info;
        }
    }
}
