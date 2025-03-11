namespace PeakDriver.Core
{
    public class PeakChannelData
    {
        public ushort HandleId { get; init; }
        public uint DeviceId { get; init; }
        public string DeviceName { get; init; } = string.Empty;
        public bool SupportsFd { get; init; }
        public PeakChannelCondition Condition { get; init; }
    }
}
