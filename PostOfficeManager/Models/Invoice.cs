using System;
using System.Collections.Generic;

namespace PostOfficeManager.Models
{
    /// <summary>
    /// Represents a post office delivery invoice.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice" /> class.
        /// </summary>
        /// <param name="order">The order to be invoiced.</param>
        /// <param name="parcelItems">The collection of items representing invoice details about parcels.</param>
        /// <param name="total">The total cost of the order.</param>
        public Invoice(Order order, IList<InvoiceParcelItem> parcelItems, decimal total)
        {
            RelatedOrder = order ?? throw new ArgumentNullException(nameof(order));
            Total = total;
            Parcels = parcelItems ?? new List<InvoiceParcelItem>();
        }

        /// <summary>
        /// Gets a unique identifier of the invoice.
        /// </summary>
        public Guid Id { get; } = new Guid();

        /// <summary>
        /// Gets a related order information about this invoice.
        /// </summary>
        public Order RelatedOrder { get; }

        /// <summary>
        /// Gets the total price of the order.
        /// </summary>
        public decimal Total { get; }

        /// <summary>
        /// Gets detailed information about parcels delivery cost.
        /// </summary>
        public IList<InvoiceParcelItem> Parcels { get; }
    }
}
