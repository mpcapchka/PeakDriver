using Peak.Can.Basic;
using PeakDriver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakDriver.PcanBasicNet
{
    public static class ChannelConditionExtension
    {
        #region Methods
        public static PeakChannelCondition ToCondition(this ChannelCondition condition)
        {
            switch (condition)
            {
                case ChannelCondition.ChannelUnavailable: return PeakChannelCondition.ChannelUnavailable;
                case ChannelCondition.ChannelAvailable: return PeakChannelCondition.ChannelAvailable;
                case ChannelCondition.ChannelOccupied: return PeakChannelCondition.ChannelOccupied;
                case ChannelCondition.ChannelPCanView: return PeakChannelCondition.ChannelPCanView;
                default: throw new NotImplementedException();
            }
        }
        #endregion
    }
}
