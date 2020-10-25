namespace PostOfficeManager.Models.Invoicing
{
    /// <summary>
    /// Represents a service item in <see cref="Invoice"/>.
    /// </summary>
    public class InvoiceServiceItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceServiceItem" /> class.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <param name="serviceCost">The cost of the postal service.</param>
        public InvoiceServiceItem(PostServiceType serviceType, decimal serviceCost)
        {
            ServiceType = serviceType;
            Cost = serviceCost;
        }

        /// <summary>
        /// Gets the service type.
        /// </summary>
        public PostServiceType ServiceType { get; }

        /// <summary>
        /// Gets the service cost.
        /// </summary>
        public decimal Cost { get; }
    }
}