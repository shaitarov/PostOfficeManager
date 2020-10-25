namespace PostOfficeManager.Models
{
    /// <summary>
    /// Represents a post service.
    /// </summary>
    public class PostService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostService" /> class.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        public PostService(PostServiceType serviceType)
        {
            ServiceType = serviceType;
        }

        /// <summary>
        /// Gets a service type.
        /// </summary>
        public PostServiceType ServiceType { get; }
    }
}