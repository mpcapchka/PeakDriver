namespace PeakDriver.Core
{
    public interface IPeakDriver
    {
        PeakChannelData[] GetAttachedChannels();
        PeakChannelData GetActualChannelData(ushort handleId, uint deviceId);
        IPeakChannel GetDriver(PeakChannelData data);
    }
}
