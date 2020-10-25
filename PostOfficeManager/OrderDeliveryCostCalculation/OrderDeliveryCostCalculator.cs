using System;
using PostOfficeManager.Models;
using PostOfficeManager.OrderDeliveryCostCalculation;
using PostOfficeManager.ParcelCostCalculation;
using PostOfficeManager.SizeCalculation;

namespace PostOfficeManager.OrderCostCalculation
{    /// <summary>
     /// An implementation of <see cref="IOrderDeliveryCostCalculator"/>.
     /// </summary>
    public class OrderDeliveryCostCalculator : IOrderDeliveryCostCalculator
    {
        private readonly IParcelSizeFactorCalculator _sizeCalculator;
        private readonly ISizeFactorBasedParcelCostCalculator _parcelCostCalculator;

        public OrderDeliveryCostCalculator(
            IParcelSizeFactorCalculator sizeCalculator,
            ISizeFactorBasedParcelCostCalculator parcelCostCalculator)
        {
            _sizeCalculator = sizeCalculator ?? throw new ArgumentNullException(nameof(sizeCalculator));
            _parcelCostCalculator = parcelCostCalculator ?? throw new ArgumentNullException(nameof(parcelCostCalculator));
        }

        ///<inheritdoc/>
        public Invoice CalculateOrderDeliveryCost(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
