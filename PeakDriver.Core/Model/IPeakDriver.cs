namespace PeakDriver.Core
{
    public interface IPeakDriver
    {
        PeakChanelData[] GetAttachedChannels();
        PeakChanelData GetActualChannelData(ushort handleId, uint deviceId);
        IPeakDriver GetDriver(PeakChanelData data);
    }
}
