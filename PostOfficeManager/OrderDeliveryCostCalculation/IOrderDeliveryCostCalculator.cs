using PostOfficeManager.Models;

namespace PostOfficeManager.OrderDeliveryCostCalculation
{
    /// <summary>
    /// Represents an interface to calculate an order delivery cost.
    /// </summary>
    public interface IOrderDeliveryCostCalculator
    {
        /// <summary>
        /// Calculates a detailed invoice for an order delivery.
        /// </summary>
        /// <param name="order">The order with parcels to be delivered.</param>
        /// <returns>The resulting invoice information.</returns>
        Invoice CalculateOrderDeliveryCost(Order order);
    }
}
