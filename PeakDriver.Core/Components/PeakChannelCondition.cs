namespace PeakDriver.Core
{
    public enum PeakChannelCondition
    {
        /// <summary>
        /// The PCAN Channel handle i.e. its associated hardware is not available.
        /// </summary>
        ChannelUnavailable,
        /// <summary>
        /// The hardware represented by the PCAN Channel is plugged-in, and valid to connect/initialize.
        /// </summary>
        ChannelAvailable,
        /// <summary>
        /// The PCAN Channel handle is valid, and is currently being used.
        /// </summary>
        ChannelOccupied,
        /// <summary>
        /// The PCAN Channel handle is currently being used by a PCAN-View application and is valid to connect.
        /// </summary>
        ChannelPCanView
    }
}
