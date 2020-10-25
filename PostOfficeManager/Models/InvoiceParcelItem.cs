namespace PostOfficeManager.Models
{
    /// <summary>
    /// Represents a parcel item in <see cref="Invoice"/>.
    /// </summary>
    public class InvoiceParcelItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceParcelItem" /> class.
        /// </summary>
        /// <param name="parcel">The related parcel information.</param>
        /// <param name="cost">The cost of delivery of an individual parcel.</param>
        public InvoiceParcelItem(Parcel parcel, decimal cost)
        {
            Parcel = parcel;
            Cost = cost;
        }

        /// <summary>
        /// Gets the parcel information.
        /// </summary>
        public Parcel Parcel { get; }

        /// <summary>
        /// Gets a cost of delivery of the parcel.
        /// </summary>
        public decimal Cost { get; }
    }
}