using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;

namespace Model.Core
{
    public partial class GameCatalog:IAnalizer
    {
        public int AverageMinAmount()
        {
            double ans = 0;
            foreach(var i in _catalog)
            {
                ans += i.NumberPlayers.Item1;
            }
            ans /= _catalog.Count();
            return (int)ans;
        }
        public int AverageMaxAmount()
        {
            double ans = 0;
            foreach(var i in _catalog)
            {
                ans += i.NumberPlayers.Item2;
            }
            ans /= _catalog.Count();
            return (int)ans;
        }
        public int MeanAmount()
        {
            double[] array = new double[0];
            foreach(var i in _catalog)
            {
                double tmp = (i.NumberPlayers.Item1 + i.NumberPlayers.Item2) / 2;
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = tmp;
            }
            double ans = 0;
            for(int i = 0; i < array.Length; i++)
            {
                ans += array[i];
            }
            return (int)(ans / array.Length);
        }
        public int MeanAgeRestriction()
        {
            double ans = 0;
            foreach(var i in _catalog)
            {
                ans += i.AgeLimit;
            }
            ans /= _catalog.Count();
            return (int)ans;
        }
    }
}
