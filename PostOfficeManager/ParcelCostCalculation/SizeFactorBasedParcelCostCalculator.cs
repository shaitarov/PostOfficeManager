using PostOfficeManager.Models;

namespace PostOfficeManager.ParcelCostCalculation
{
    /// <summary>
    /// An implementation of <see cref="ISizeFactorBasedParcelCostCalculator"/>.
    /// </summary>
    public class SizeFactorBasedParcelCostCalculator: ISizeFactorBasedParcelCostCalculator
    {
        ///<inheritdoc/>
        public decimal CalculateDeliveryCost(ParcelSizeFactor sizeFactor)
        {
            throw new System.NotImplementedException();
        }
    }
}