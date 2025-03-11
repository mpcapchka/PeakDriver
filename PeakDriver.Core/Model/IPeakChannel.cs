namespace PeakDriver.Core
{
    public interface IPeakChannel : IDisposable
    {
        #region Events
        event EventHandler<PeakMessage> MessageReceived;
        #endregion

        #region Properties
        PeakChannelData Data { get; }
        bool IsConnected { get; }
        #endregion

        #region Methods
        bool Connect(bool flexibleDataRate, PeakBaudrate baudrate, out PeakStatus status);
        bool Disconnect(out PeakStatus status);
        bool Reset();
        #endregion
    }
}
