using eShop.UseCases.PluginInterfaces.StateStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action listeners;
        public void AddStateChangeListener(Action listener) => this.listeners += listener;
        public void RemoveStateChangeListener(Action listener) => this.listeners -= listener;
   

        public void BroadCastStateChange()
        {
            if (this.listeners != null) this.listeners.Invoke();
        }


    }
}
