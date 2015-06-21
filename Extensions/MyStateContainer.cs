using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Extensions
{
    public class MyStateContainer : IExtension<ServiceHostBase>
    {
        public MyStateContainer(string state) { this.MyState = state; }

        public string MyState;

        #region IExtension<ServiceHostBase> Members

        public void Attach(ServiceHostBase owner)
        {
        }

        public void Detach(ServiceHostBase owner)
        {
        }

        #endregion
    }
}
