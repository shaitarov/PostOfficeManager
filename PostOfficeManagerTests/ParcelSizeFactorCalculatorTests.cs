using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostOfficeManager.Models;
using PostOfficeManager.ParcelSizeCalculation;

namespace PostOfficeManagerTests
{
    [TestClass]
    public class ParcelSizeFactorCalculatorTests
    {
        [TestMethod]
        public void CalculateSizeFactorOfSmallSquareParcel()
        {
            var sizeCalculator = new ParcelSizeFactorCalculator();

            var parcelSize = new ParcelSize(1, 1, 1);

            var sizeType = sizeCalculator.CalculateParcelSizeFactor(parcelSize);

            Assert.AreEqual(ParcelSizeFactor.Small, sizeType);
        }


        [TestMethod]
        public void CalculateSizeFactorOfMediumSquareParcel()
        {
            var sizeCalculator = new ParcelSizeFactorCalculator();

            var parcelSize = new ParcelSize(10, 10, 10);

            var sizeType = sizeCalculator.CalculateParcelSizeFactor(parcelSize);

            Assert.AreEqual(ParcelSizeFactor.Medium, sizeType);
        }

        [TestMethod]
        public void CalculateSizeFactorOfLargeSquareParcel()
        {
            var sizeCalculator = new ParcelSizeFactorCalculator();

            var parcelSize = new ParcelSize(50, 50, 50);

            var sizeType = sizeCalculator.CalculateParcelSizeFactor(parcelSize);

            Assert.AreEqual(ParcelSizeFactor.Large, sizeType);
        }

        [TestMethod]
        public void CalculateSizeFactorOfExtraLargeSquareParcel()
        {
            var sizeCalculator = new ParcelSizeFactorCalculator();

            var parcelSize = new ParcelSize(100, 100, 100);

            var sizeType = sizeCalculator.CalculateParcelSizeFactor(parcelSize);

            Assert.AreEqual(ParcelSizeFactor.ExtraLarge, sizeType);
        }

        [TestMethod]
        public void CalculateSizeFactorOfSmallMultidimensionalParcel()
        {
            var sizeCalculator = new ParcelSizeFactorCalculator();

            var parcelSize = new ParcelSize(1, 50, 100);

            var sizeType = sizeCalculator.CalculateParcelSizeFactor(parcelSize);

            Assert.AreEqual(ParcelSizeFactor.ExtraLarge, sizeType);
        }
    }
}
