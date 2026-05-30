using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public interface IAnalizer
    {
        int AverageMinAmount();
        int AverageMaxAmount();
        int MeanAmount();
        int MeanAgeRestriction();
    }
}
