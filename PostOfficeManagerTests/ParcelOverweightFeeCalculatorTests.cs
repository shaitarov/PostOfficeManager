using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostOfficeManager.Models;
using PostOfficeManager.ParcelOverweightFeeCalculation;

namespace PostOfficeManagerTests
{
    [TestClass]
    public class ParcelOverweightFeeCalculatorTests
    {
        [TestMethod]
        public void CalculateOverweightFeeOfSmallParcel()
        {
            var feeCalculator = new ParcelOverweightFeeCalculator();

            var fee = feeCalculator.CalculateOverWeightFee(ParcelSizeFactor.Small);

            Assert.AreEqual(2, fee);
        }

        [TestMethod]
        public void CalculateOverweightFeeMediumParcel()
        {
            var feeCalculator = new ParcelOverweightFeeCalculator();

            var fee = feeCalculator.CalculateOverWeightFee(ParcelSizeFactor.Medium);

            Assert.AreEqual(2, fee);
        }

        [TestMethod]
        public void CalculateOverweightFeeOfLargeParcel()
        {
            var feeCalculator = new ParcelOverweightFeeCalculator();

            var fee = feeCalculator.CalculateOverWeightFee(ParcelSizeFactor.Large);

            Assert.AreEqual(2, fee);
        }

        [TestMethod]
        public void CalculateOverweightFeeExtraLargeParcel()
        {
            var feeCalculator = new ParcelOverweightFeeCalculator();

            var fee = feeCalculator.CalculateOverWeightFee(ParcelSizeFactor.ExtraLarge);

            Assert.AreEqual(2, fee);
        }
    }
}