using System;
using PostOfficeManager.Models;

namespace PostOfficeManager.ParcelWeightLimitCalculation
{
    public class ParcelWeightLimitCalculator : IParcelWeightLimitCalculator
    {
        public int CalculateWeightLimit(ParcelSizeFactor sizeFactor) =>
            sizeFactor switch
            {
                ParcelSizeFactor.Small => 1,
                ParcelSizeFactor.Medium => 3,
                ParcelSizeFactor.Large => 6,
                ParcelSizeFactor.ExtraLarge => 10,
                _ => throw new NotImplementedException()
            };
    }
}
