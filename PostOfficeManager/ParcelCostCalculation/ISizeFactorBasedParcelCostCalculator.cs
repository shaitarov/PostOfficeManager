using PostOfficeManager.Models;

namespace PostOfficeManager.ParcelCostCalculation
{
    /// <summary>
    /// Represents an interface to calculate a parcel delivery cost based on a parcel size factor.
    /// </summary>
    public interface ISizeFactorBasedParcelCostCalculator
    {
        /// <summary>
        /// Calculates a parcel delivery cost based on the parcel size factor.
        /// </summary>
        /// <param name="sizeFactor">The parcel size factor.</param>
        /// <returns>The delivery cost.</returns>
        decimal CalculateDeliveryCost(ParcelSizeFactor sizeFactor);
    }
}