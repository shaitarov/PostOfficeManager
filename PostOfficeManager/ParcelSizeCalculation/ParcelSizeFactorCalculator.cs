using PostOfficeManager.Models;

namespace PostOfficeManager.ParcelSizeCalculation
{
    /// <summary>
    /// An implementation of <see cref="IParcelSizeFactorCalculator"/>.
    /// </summary>
    public class ParcelSizeFactorCalculator : IParcelSizeFactorCalculator
    {
        ///<inheritdoc/>
        public ParcelSizeFactor CalculateParcelSizeFactor(ParcelSize parcelDimensions)
        {
            if (parcelDimensions.Width < 10
                && parcelDimensions.Height < 10
                && parcelDimensions.Height < 10)
            {
                return ParcelSizeFactor.Small;
            }

            if (parcelDimensions.Width < 50
                && parcelDimensions.Height < 50
                && parcelDimensions.Height < 50)
            {
                return ParcelSizeFactor.Medium;
            }

            if (parcelDimensions.Width < 100
                && parcelDimensions.Height < 100
                && parcelDimensions.Height < 100)
            {
                return ParcelSizeFactor.Large;
            }

            return ParcelSizeFactor.ExtraLarge;
        }
    }
}
