namespace PeakDriver.Core
{
    public struct PeakMessage
    {
        #region Constructors
        public PeakMessage(uint timestampt, byte[] data)
        {
            Timestampt = timestampt;
            Data = data;
        }
        #endregion

        #region Properties
        public uint Timestampt { get; }
        public byte[] Data { get; }
        #endregion
    }
}
