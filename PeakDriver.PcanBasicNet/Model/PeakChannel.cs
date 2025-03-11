using Peak.Can.Basic;
using PeakDriver.Core;

namespace PeakDriver.PcanBasicNet
{
    public sealed class PeakChannel : IPeakChannel
    {
        #region Fields
        private readonly Worker worker = new Worker();
        #endregion

        #region Events
        public event EventHandler<PeakMessage>? MessageReceived;
        #endregion

        #region Constructors
        public PeakChannel(PeakChannelData data)
        {
            Data = data;

            worker.MessageAvailable += Worker_MessageAvailable;
        }

        #endregion

        #region Properties
        public PeakChannelData Data { get; }
        public bool IsConnected { get; private set; }
        public bool IsDisposed { get; private set; } = false;
        #endregion

        #region Methods
        public bool Connect(bool flexibleDataRate, PeakBaudrate baudrate, out PeakStatus status)
        {
            if (IsConnected) throw new InvalidOperationException("The channel is already connected.");
            else if (IsDisposed) throw new ObjectDisposedException(nameof(PeakChannel));
            else if (Data == null) throw new ArgumentNullException(nameof(Data));

            var channel = (PcanChannel)Data.HandleId;
            var bitrate = baudrate.ToBitrate();
            var result = false;
            status = Api.Initialize(channel, bitrate).ToStatus();
            switch (status)
            {
                case PeakStatus.Ok: result = true; break;
                case PeakStatus.BusLight: result = true; break;
                case PeakStatus.BusHeavy: result = true; break;
                case PeakStatus.BusOff: result = true; break;
                default: result = false; break;
            }
            if (!result)
            {
                Api.Uninitialize(channel);
                return false;
            }
            IsConnected = true;
            worker.Start();
            return true;
        }
        public bool Disconnect(out PeakStatus status)
        {
            if (IsDisposed) throw new ObjectDisposedException(nameof(PeakChannel));
            else if (Data == null) throw new ArgumentNullException(nameof (Data));
            if (!IsConnected)
            {
                status = PeakStatus.Ok;
                return true;
            }
            var channel = (PcanChannel)Data.HandleId;
            status = Api.Uninitialize(channel).ToStatus();
            var result = false;
            switch (status)
            {
                case PeakStatus.Ok: result = true; break;
                default: result = false; break;
            }
            if (result)
            {
                IsConnected = false;
                worker.Stop();
            }
            return result;
        }
        public void Dispose()
        {
            if (IsDisposed) throw new ObjectDisposedException(nameof(PeakChannel));
            Disconnect(out _);
            worker.MessageAvailable -= Worker_MessageAvailable;
            IsDisposed = true;
        }
        public bool Reset()
        {
            if (IsDisposed) throw new ObjectDisposedException(nameof(PeakChannel));
            else if (!IsConnected) throw new InvalidOperationException("The channel must be connected.");
            var channel = (PcanChannel)Data.HandleId;
            var resetStatus = Api.Reset(channel);
            var postResetStatus = Api.GetStatus(channel);
            return resetStatus == PcanStatus.OK && postResetStatus == PcanStatus.OK;
        }
        #endregion

        #region Handlers
        private void Worker_MessageAvailable(object? sender, MessageAvailableEventArgs e)
        {
            while (IsConnected && worker.Dequeue(out var pcanMsg, out var timestampt))
            {
                var msg = new PeakMessage(timestampt, GetData(pcanMsg.Data, pcanMsg.Length));
                MessageReceived?.Invoke(this, msg);
            }
        }
        #endregion

        #region Helpers
        private byte[] GetData(DataBytes data, int length)
        {
            var array = new byte[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = data[i];
            }
            return array;
        }
        #endregion
    }
}
