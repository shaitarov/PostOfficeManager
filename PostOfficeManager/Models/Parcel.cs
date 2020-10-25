using System;

namespace PostOfficeManager.Models
{
    /// <summary>
    /// Represents a post office parcel model.
    /// </summary>
    public class Parcel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parcel" /> class.
        /// </summary>
        /// <param name="dimensions">The parcel dimensions.</param>
        public Parcel(ParcelSize dimensions)
        {
            Dimensions = dimensions;
        }

        /// <summary>
        /// Gets a unique identifier of the parcel.
        /// </summary>
        public Guid Id { get; } = new Guid();

        /// <summary>
        /// Gets parcel dimensions.
        /// </summary>
        public ParcelSize Dimensions { get; }
    }
}
