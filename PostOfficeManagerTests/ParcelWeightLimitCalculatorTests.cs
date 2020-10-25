using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostOfficeManager.Models;
using PostOfficeManager.ParcelWeightLimitCalculation;

namespace PostOfficeManagerTests
{
    [TestClass]
    public class ParcelWeightLimitCalculatorTests
    {
        [TestMethod]
        public void CalculateWeightLimitOfSmallParcel()
        {
            var weightLimitCalculator = new ParcelWeightLimitCalculator();

            var weightLimit = weightLimitCalculator.CalculateWeightLimit(ParcelSizeFactor.Small);

            Assert.AreEqual(1, weightLimit);
        }

        [TestMethod]
        public void CalculateWeightLimitOfMediumParcel()
        {
            var weightLimitCalculator = new ParcelWeightLimitCalculator();

            var weightLimit = weightLimitCalculator.CalculateWeightLimit(ParcelSizeFactor.Medium);

            Assert.AreEqual(3, weightLimit);
        }

        [TestMethod]
        public void CalculateWeightLimitOfLargeParcel()
        {
            var weightLimitCalculator = new ParcelWeightLimitCalculator();

            var weightLimit = weightLimitCalculator.CalculateWeightLimit(ParcelSizeFactor.Large);

            Assert.AreEqual(6, weightLimit);
        }

        [TestMethod]
        public void CalculateWeightLimitOfExtraLargeParcel()
        {
            var weightLimitCalculator = new ParcelWeightLimitCalculator();

            var weightLimit = weightLimitCalculator.CalculateWeightLimit(ParcelSizeFactor.ExtraLarge);

            Assert.AreEqual(10, weightLimit);
        }
    }
}