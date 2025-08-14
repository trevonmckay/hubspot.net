namespace HubSpot.NET.Models
{
    public class PropertyOption
    {
        /// <summary>
        /// A human-readable option label that will be shown in HubSpot.
        /// </summary>
        public required string Label { get; set; }

        /// <summary>
        /// The internal value of the option, which must be used when setting the property value through the API.
        /// </summary>
        public required string Value { get; set; }

        /// <summary>
        /// Hidden options won't be shown in HubSpot.
        /// </summary>
        public required bool Hidden { get; set; }

        /// <summary>
        /// A description of the option.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Options are shown in order starting with the lowest positive integer value.
        /// </summary>
        /// <remarks>Values of -1 will cause the option to be displayed after any positive values.</remarks>
        public int? DisplayOrder { get; set; }
    }
}
