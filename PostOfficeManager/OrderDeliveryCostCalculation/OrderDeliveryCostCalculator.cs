using System;
using System.Collections.Generic;
using System.Linq;
using PostOfficeManager.Models;
using PostOfficeManager.Models.Invoicing;
using PostOfficeManager.ParcelCostCalculation;
using PostOfficeManager.ParcelSizeCalculation;

namespace PostOfficeManager.OrderDeliveryCostCalculation
{
     /// <summary>
     /// An implementation of <see cref="IOrderDeliveryCostCalculator"/>.
     /// </summary>
    public class OrderDeliveryCostCalculator : IOrderDeliveryCostCalculator
    {
        private readonly IParcelSizeFactorCalculator _sizeCalculator;
        private readonly ISizeFactorBasedParcelCostCalculator _parcelCostCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDeliveryCostCalculator" /> class.
        /// </summary>
        /// <param name="sizeCalculator">The calculator of a parcel size factor.</param>
        /// <param name="parcelCostCalculator">The calculator of the individual parcel cost deliver.</param>
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
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            var parcels = new List<InvoiceParcelItem>();
            var services = new List<InvoiceServiceItem>();

            foreach (var orderParcel in order.Parcels)
            {
                var item = new InvoiceParcelItem(orderParcel, CalculateParcelCost(orderParcel));
                parcels.Add(item);
            }

            var parcelsCost = parcels.Aggregate(0m, (acc, parcelCost) => acc + parcelCost.Cost);

            foreach (var orderService in order.Services)
            {
                switch (orderService.ServiceType)
                {
                    case PostServiceType.SpeedyShipping:
                        services.Add(new InvoiceServiceItem(PostServiceType.SpeedyShipping, parcelsCost));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            var servicesCost = services.Aggregate(0m, (acc, serviceCost) => acc + serviceCost.Cost);

            var total = parcelsCost + servicesCost;

            return new Invoice(order, parcels, services, total);
        }

        /// <summary>
        /// Calculates a delivery cost for an individual parcel.
        /// </summary>
        /// <param name="parcel">The parcel to be calculated.</param>
        /// <returns>The delivery cost.</returns>
        internal decimal CalculateParcelCost(Parcel parcel)
        {
            if (parcel is null)
            {
                throw new ArgumentNullException(nameof(parcel));
            }

            var sizeType = _sizeCalculator.CalculateParcelSizeFactor(parcel.Dimensions);

            return _parcelCostCalculator.CalculateDeliveryCost(sizeType);
        }
    }
}
