using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.PluginInterfaces.StateStore
{
    public interface IStateStore
    {
        void AddStateChangeListener(Action listener);
        void RemoveStateChangeListener(Action listener);
        void BroadCastStateChange();
    }
}
