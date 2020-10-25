using PostOfficeManager.Models;

namespace PostOfficeManager.SizeCalculation
{
    /// <summary>
    /// Represents an interface to calculate a parcel size factor based on parcel dimensions.
    /// </summary>
    public interface IParcelSizeFactorCalculator
    {
        /// <summary>
        /// Calculates a parcel size factor based on parcel dimensions.
        /// </summary>
        /// <param name="parcelDimensions">The parcel dimensions.</param>
        /// <returns>The parcel size factor.</returns>
        ParcelSizeFactor CalculateParcelSizeFactor(ParcelSize parcelDimensions);
    }
}
