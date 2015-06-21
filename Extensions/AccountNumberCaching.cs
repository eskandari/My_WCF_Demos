using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Description;

namespace Extensions
{
    public class AccountNumberCaching : Attribute, IOperationBehavior
    {
        int index = 0;

        public AccountNumberCaching() : this(0) { }
        public AccountNumberCaching(int index) { this.index = index; }

        #region IOperationBehavior Members

        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker =
                new AccountNumberCacher(index, dispatchOperation.Invoker);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        #endregion
    }
}
