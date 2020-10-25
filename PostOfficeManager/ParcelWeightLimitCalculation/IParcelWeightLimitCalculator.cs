using PostOfficeManager.Models;

namespace PostOfficeManager.ParcelWeightLimitCalculation
{
    public interface IParcelWeightLimitCalculator
    {
        int CalculateWeightLimit(ParcelSizeFactor sizeFactor);
    }
}
