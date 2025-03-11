using Peak.Can.Basic;
using PeakDriver.Core;

namespace PeakDriver.PcanBasicNet
{
    public static class PcanStatusExtension
    {
        #region Methods
        public static PeakStatus ToStatus(this PcanStatus status)
        {
            switch (status)
            {
                case PcanStatus.BusWarning: return PeakStatus.BusWarning;
                case PcanStatus.IllegalHandle: return PeakStatus.IllegalHandle;
            }
            switch (status)
            {
                case PcanStatus.OK: return PeakStatus.Ok;
                case PcanStatus.TransmitBufferFull: return PeakStatus.TransmitBufferFull;
                case PcanStatus.Overrun: return PeakStatus.Overrun;
                case PcanStatus.BusLight: return PeakStatus.BusLight;
                case PcanStatus.BusHeavy: return PeakStatus.BusHeavy;
                case PcanStatus.BusPassive: return PeakStatus.BusPassive;
                case PcanStatus.BusOff: return PeakStatus.BusOff;
                case PcanStatus.AnyBusError: return PeakStatus.AnyBusError;
                case PcanStatus.ReceiveQueueEmpty: return PeakStatus.ReceiveQueueEmpty;
                case PcanStatus.ReceiveQueueOverrun: return PeakStatus.ReceiveQueueOverrun;
                case PcanStatus.TransmitQueueFull: return PeakStatus.TransmitQueueFull;
                case PcanStatus.NoDriver: return PeakStatus.NoDriver;
                case PcanStatus.HardwareInUse: return PeakStatus.HardwareInUse;
                case PcanStatus.NetInUse: return PeakStatus.NetInUse;
                case PcanStatus.IllegalHardwareHandle: return PeakStatus.IllegalHardwareHandle;
                case PcanStatus.IllegalNetHandle: return PeakStatus.IllegalNetHandle;
                case PcanStatus.IllegalClientHandle: return PeakStatus.IllegalClientHandle;
                case PcanStatus.Resource: return PeakStatus.Resource;
                case PcanStatus.InvalidParameter: return PeakStatus.InvalidParameter;
                case PcanStatus.InvalidValue: return PeakStatus.InvalidValue;
                case PcanStatus.Unknown: return PeakStatus.Unknown;
                case PcanStatus.IllegalData: return PeakStatus.IllegalData;
                case PcanStatus.IllegalMode: return PeakStatus.IllegalMode;
                case PcanStatus.Caution: return PeakStatus.Caution;
                case PcanStatus.Initialize: return PeakStatus.Initialize;
                case PcanStatus.InvalidOperation: return PeakStatus.InvalidOperation;
                default: throw new NotImplementedException();
            }
        }
        #endregion
    }
}
