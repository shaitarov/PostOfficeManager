using PostOfficeManager.Models;

namespace PostOfficeManager.ParcelOverweightFeeCalculation
{
    public interface IParcelOverweightFeeCalculator
    {
        decimal CalculateOverWeightFee(ParcelSizeFactor sizeFactor);
    }
}