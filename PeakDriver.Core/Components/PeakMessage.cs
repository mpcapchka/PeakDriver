namespace PeakDriver.Core
{
    public struct PeakMessage
    {
        #region Constructors
        public PeakMessage(ulong timestampt, byte[] data)
        {
            Timestampt = timestampt;
            Data = data;
        }
        #endregion

        #region Properties
        public ulong Timestampt { get; }
        public byte[] Data { get; }
        #endregion
    }
}
