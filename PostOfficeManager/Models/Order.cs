using System;
using System.Collections.Generic;
using System.Linq;

namespace PostOfficeManager.Models
{
    /// <summary>
    /// Represents a post office delivery order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="parcels">The collection of parcels to be delivered.</param>
        public Order(IList<Parcel> parcels)
        {
            Parcels = parcels ?? new List<Parcel>();
        }

        /// <summary>
        /// Gets a unique identifier of the order.
        /// </summary>
        public Guid Id { get; } = new Guid();

        /// <summary>
        /// Gets a collection of parcels to be delivered.
        /// </summary>
        public IList<Parcel> Parcels { get; } = new List<Parcel>();

        /// <summary>
        /// Gets a collection of post services like speedy delivery.
        /// </summary>
        public IList<PostService> Services { get; } = new List<PostService>();

        /// <summary>
        /// Adds a speedy shipping request to the order.
        /// </summary>
        /// <returns></returns>
        public Order WithSpeedyShipping()
        {
            if (Services.All(s => s.ServiceType != PostServiceType.SpeedyShipping))
            {
                Services.Add(new PostService(PostServiceType.SpeedyShipping));
            }

            return this;
        }
    }
}
