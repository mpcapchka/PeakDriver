using Peak.Can.Basic;
using PeakDriver.Core;

namespace PeakDriver.PcanBasicNet
{
    public static class BaudrateExtension
    {
        #region Methods
        public static Bitrate ToBitrate(this PeakBaudrate baudrate)
        {
            switch (baudrate)
            {
                case PeakBaudrate.Pcan125: return Bitrate.Pcan125;
                case PeakBaudrate.Pcan250: return Bitrate.Pcan250;
                case PeakBaudrate.Pcan500: return Bitrate.Pcan500;
                case PeakBaudrate.Pcan1000: return Bitrate.Pcan1000;
                default: throw new NotImplementedException();
            }
        }
        #endregion
    }
}
