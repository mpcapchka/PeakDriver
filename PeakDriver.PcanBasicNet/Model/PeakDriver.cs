using Peak.Can.Basic;
using PeakDriver.Core;

namespace PeakDriver.PcanBasicNet
{
    public class PeakDriver : IPeakDriver
    {
        #region Methods
        public PeakChannelData GetActualChannelData(ushort handleId, uint deviceId)
        {
            var attachedChannels = GetAttachedChannels();
            if (attachedChannels.Any(x => x.HandleId == handleId && x.DeviceId == deviceId))
                return attachedChannels.First(x => x.HandleId == handleId && x.DeviceId == deviceId);
            else return new PeakChannelData()
            {
                HandleId = handleId,
                DeviceId = deviceId,
                Condition = PeakChannelCondition.ChannelUnavailable,
                DeviceName = "Unkown",
                SupportsFd = false
            };
        }
        public PeakChannelData[] GetAttachedChannels()
        {
            var result = new List<PeakChannelData>();
            if (Api.GetAttachedChannels(out var channels) != PcanStatus.OK) 
                return result.ToArray();
            foreach(var channel in channels)
            {
                var data = new PeakChannelData()
                {
                    Condition = channel.ChannelCondition.ToCondition(),
                    DeviceId = channel.DeviceID,
                    DeviceName = channel.DeviceName,
                    SupportsFd = channel.DeviceFeatures == PcanDeviceFeatures.FlexibleDataRate,
                    HandleId = (ushort)channel.ChannelHandle
                };
                result.Add(data);
            }    
            return result.ToArray();
        }
        public IPeakChannel GetDriver(PeakChannelData data)
        {
            return new PeakChannel(data);
        }
        #endregion
    }
}
