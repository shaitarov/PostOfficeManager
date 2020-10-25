using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PostOfficeManager.Models;
using PostOfficeManager.OrderDeliveryCostCalculation;
using PostOfficeManager.ParcelCostCalculation;
using PostOfficeManager.ParcelSizeCalculation;

namespace PostOfficeManagerTests
{
    [TestClass]
    public class OrderDeliverCostCalculatorTests
    {
        private Mock<IParcelSizeFactorCalculator> _sizeCalculatorMock;
        private Mock<ISizeFactorBasedParcelCostCalculator> _parcelCostCalculatorMock;
        private readonly Parcel _dummyParcel = new Parcel(new ParcelSize(1, 1, 1));

        [TestInitialize]
        public void TestInitialize()
        {
            _sizeCalculatorMock = new Mock<IParcelSizeFactorCalculator>();
            _parcelCostCalculatorMock = new Mock<ISizeFactorBasedParcelCostCalculator>();
        }

        [TestMethod]
        public void CalculateCostOfOrderWithOneParcel()
        {
            _sizeCalculatorMock.Setup(c => c.CalculateParcelSizeFactor(It.IsAny<ParcelSize>())).Returns(ParcelSizeFactor.ExtraLarge);
            _parcelCostCalculatorMock.Setup(c => c.CalculateDeliveryCost(It.IsAny<ParcelSizeFactor>())).Returns(25m);

            var costCalculator = new OrderDeliveryCostCalculator(
                _sizeCalculatorMock.Object,
                _parcelCostCalculatorMock.Object);

            var order = new Order(new List<Parcel> { _dummyParcel });

            var invoice = costCalculator.CalculateOrderDeliveryCost(order);

            Assert.IsNotNull(invoice);
            Assert.AreEqual(order.Id, invoice.RelatedOrder.Id);
            Assert.AreEqual(1, invoice.Parcels.Count);
            Assert.AreEqual(25, invoice.Parcels.First().Cost);
            Assert.AreEqual(25, invoice.Total);
        }

        [TestMethod]
        public void CalculateCostOfOrderWithMultipleParcels()
        {
            _sizeCalculatorMock.Setup(c => c.CalculateParcelSizeFactor(It.IsAny<ParcelSize>())).Returns(ParcelSizeFactor.ExtraLarge);
            _parcelCostCalculatorMock.Setup(c => c.CalculateDeliveryCost(It.IsAny<ParcelSizeFactor>())).Returns(25m);

            var costCalculator = new OrderDeliveryCostCalculator(
                _sizeCalculatorMock.Object,
                _parcelCostCalculatorMock.Object);

            var parcel1 = new Parcel(new ParcelSize(1, 1, 1));
            var parcel2 = new Parcel(new ParcelSize(1, 1, 1));
            var parcel3 = new Parcel(new ParcelSize(1, 1, 1));

            var order = new Order(new List<Parcel> { parcel1, parcel2, parcel3 });

            var invoice = costCalculator.CalculateOrderDeliveryCost(order);

            Assert.IsNotNull(invoice);
            Assert.AreEqual(3, invoice.Parcels.Count);
            Assert.AreEqual(75, invoice.Total);
        }
    }
}
