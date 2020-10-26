using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PostOfficeManager.Models;
using PostOfficeManager.OrderDeliveryCostCalculation;
using PostOfficeManager.ParcelCostCalculation;
using PostOfficeManager.ParcelOverweightFeeCalculation;
using PostOfficeManager.ParcelSizeCalculation;
using PostOfficeManager.ParcelWeightLimitCalculation;

namespace PostOfficeManagerTests
{
    [TestClass]
    public class OrderDeliverCostCalculatorTests
    {
        private Mock<IParcelSizeFactorCalculator> _sizeCalculatorMock;
        private Mock<ISizeFactorBasedParcelCostCalculator> _parcelCostCalculatorMock;
        private Mock<IParcelWeightLimitCalculator> _weightLimitCalculatorMock;
        private Mock<IParcelOverweightFeeCalculator> _overweightFeeCalculatorMock;
        private readonly Parcel _dummyParcel = new Parcel(new ParcelSize(1, 1, 1), 1);

        [TestInitialize]
        public void TestInitialize()
        {
            _sizeCalculatorMock = new Mock<IParcelSizeFactorCalculator>();
            _parcelCostCalculatorMock = new Mock<ISizeFactorBasedParcelCostCalculator>();
            _weightLimitCalculatorMock = new Mock<IParcelWeightLimitCalculator>();
            _overweightFeeCalculatorMock = new Mock<IParcelOverweightFeeCalculator>();
        }

        [TestMethod]
        public void CalculateCostOfOrderWithOneParcel()
        {
            _sizeCalculatorMock.Setup(c => c.CalculateParcelSizeFactor(It.IsAny<ParcelSize>())).Returns(ParcelSizeFactor.ExtraLarge);
            _parcelCostCalculatorMock.Setup(c => c.CalculateDeliveryCost(It.IsAny<ParcelSizeFactor>())).Returns(25m);

            var costCalculator = new OrderDeliveryCostCalculator(
                _sizeCalculatorMock.Object,
                _parcelCostCalculatorMock.Object,
                _weightLimitCalculatorMock.Object,
                _overweightFeeCalculatorMock.Object);

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
                _parcelCostCalculatorMock.Object,
                _weightLimitCalculatorMock.Object,
                _overweightFeeCalculatorMock.Object);

            var parcel1 = new Parcel(new ParcelSize(1, 1, 1), 1);
            var parcel2 = new Parcel(new ParcelSize(1, 1, 1), 1);
            var parcel3 = new Parcel(new ParcelSize(1, 1, 1), 1);

            var order = new Order(new List<Parcel> { parcel1, parcel2, parcel3 });

            var invoice = costCalculator.CalculateOrderDeliveryCost(order);

            Assert.IsNotNull(invoice);
            Assert.AreEqual(3, invoice.Parcels.Count);
            Assert.AreEqual(75, invoice.Total);
        }

        [TestMethod]
        public void CalculateCostOfOrderWithSpeedyShipping()
        {
            _sizeCalculatorMock.Setup(c => c.CalculateParcelSizeFactor(It.IsAny<ParcelSize>())).Returns(ParcelSizeFactor.ExtraLarge);
            _parcelCostCalculatorMock.Setup(c => c.CalculateDeliveryCost(It.IsAny<ParcelSizeFactor>())).Returns(25m);

            var costCalculator = new OrderDeliveryCostCalculator(
                _sizeCalculatorMock.Object,
                _parcelCostCalculatorMock.Object,
                _weightLimitCalculatorMock.Object,
                _overweightFeeCalculatorMock.Object);

            var parcel1 = new Parcel(new ParcelSize(1, 1, 1), 1);
            var parcel2 = new Parcel(new ParcelSize(1, 1, 1), 1);
            var parcel3 = new Parcel(new ParcelSize(1, 1, 1), 1);

            var order = new Order(new List<Parcel>() { parcel1, parcel2, parcel3 }).WithSpeedyShipping();

            var invoice = costCalculator.CalculateOrderDeliveryCost(order);

            Assert.IsNotNull(invoice);
            Assert.AreEqual(1, invoice.Services.Count);
            Assert.AreEqual(PostServiceType.SpeedyShipping, invoice.Services.First().ServiceType);
            Assert.AreEqual(75, invoice.Services.First().Cost);
            Assert.AreEqual(150, invoice.Total);
        }

        [TestMethod]
        public void CalculateCostOfEmptyOrderWithSpeedyShipping()
        {
            var costCalculator = new OrderDeliveryCostCalculator(
                _sizeCalculatorMock.Object,
                _parcelCostCalculatorMock.Object,
                _weightLimitCalculatorMock.Object,
                _overweightFeeCalculatorMock.Object);

            var order = new Order(new List<Parcel>()).WithSpeedyShipping();

            var invoice = costCalculator.CalculateOrderDeliveryCost(order);

            Assert.IsNotNull(invoice);
            Assert.AreEqual(1, invoice.Services.Count);
            Assert.AreEqual(PostServiceType.SpeedyShipping, invoice.Services.First().ServiceType);
            Assert.AreEqual(0, invoice.Services.First().Cost);
            Assert.AreEqual(0, invoice.Total);
        }

        [TestMethod]
        public void CalculateCostOfOverweightedParcel()
        {
            var costCalculator = new OrderDeliveryCostCalculator(
                _sizeCalculatorMock.Object,
                _parcelCostCalculatorMock.Object,
                _weightLimitCalculatorMock.Object,
                _overweightFeeCalculatorMock.Object);

            var overweightedParcel = new Parcel(new ParcelSize(1,1,1), 10);

            var overweightFee = 5m;
            var weightLimit = 5;

            _sizeCalculatorMock.Setup(c => c.CalculateParcelSizeFactor(It.IsAny<ParcelSize>())).Returns(ParcelSizeFactor.Small);
            _parcelCostCalculatorMock.Setup(c => c.CalculateDeliveryCost(It.IsAny<ParcelSizeFactor>())).Returns(0);
            _weightLimitCalculatorMock.Setup(c => c.CalculateWeightLimit(It.IsAny<ParcelSizeFactor>())).Returns(weightLimit);
            _overweightFeeCalculatorMock.Setup(c => c.CalculateOverWeightFee(It.IsAny<ParcelSizeFactor>())).Returns(overweightFee);

            var deliverCost = costCalculator.CalculateParcelCost(overweightedParcel);

            Assert.AreEqual((overweightedParcel.Weight - weightLimit) * overweightFee, deliverCost);
        }
    }
}
