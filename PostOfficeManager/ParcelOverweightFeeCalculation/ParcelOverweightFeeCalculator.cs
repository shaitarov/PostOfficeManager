using PostOfficeManager.Models;

namespace PostOfficeManager.ParcelOverweightFeeCalculation
{
    public class ParcelOverweightFeeCalculator : IParcelOverweightFeeCalculator
    {
        public decimal CalculateOverWeightFee(ParcelSizeFactor sizeFactor) => 2m;
    }
}