using System;
using PostOfficeManager.Models;

namespace PostOfficeManager.ParcelCostCalculation
{
    /// <summary>
    /// An implementation of <see cref="ISizeFactorBasedParcelCostCalculator"/>.
    /// </summary>
    public class SizeFactorBasedParcelCostCalculator: ISizeFactorBasedParcelCostCalculator
    {
        ///<inheritdoc/>
        public decimal CalculateDeliveryCost(ParcelSizeFactor sizeFactor) =>
            sizeFactor switch
            {
                ParcelSizeFactor.Small => 3,
                ParcelSizeFactor.Medium => 8,
                ParcelSizeFactor.Large => 15,
                ParcelSizeFactor.ExtraLarge => 25,
                _ => throw new NotImplementedException()
            };
    }
}
