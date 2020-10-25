using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostOfficeManager.Models;
using PostOfficeManager.ParcelCostCalculation;

namespace PostOfficeManagerTests
{
    [TestClass]
    public class SizeFactorBasedParcelCostCalculatorTests
    {
        private readonly ISizeFactorBasedParcelCostCalculator _costCalculator = new SizeFactorBasedParcelCostCalculator();

        [TestMethod]
        public void CalculateCostOfSmallParcel()
        {
            var deliveryCost = _costCalculator.CalculateDeliveryCost(ParcelSizeFactor.Small);

            Assert.AreEqual(3, deliveryCost);
        }

        [TestMethod]
        public void CalculateCostOfMediumParcel()
        {
            var deliveryCost = _costCalculator.CalculateDeliveryCost(ParcelSizeFactor.Medium);

            Assert.AreEqual(8, deliveryCost);
        }

        [TestMethod]
        public void CalculateCostOfLargeParcel()
        {
            var deliveryCost = _costCalculator.CalculateDeliveryCost(ParcelSizeFactor.Large);

            Assert.AreEqual(15, deliveryCost);
        }

        [TestMethod]
        public void CalculateCostOfExtraLargeParcel()
        {
            var deliveryCost = _costCalculator.CalculateDeliveryCost(ParcelSizeFactor.ExtraLarge);

            Assert.AreEqual(25, deliveryCost);
        }
    }
}
