using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;

namespace Extensions
{
    public class AccountNumberCacher : IOperationInvoker
    {
        int index = 0;
        IOperationInvoker innerInvoker = null;
        Dictionary<string, string> cachedValues = new Dictionary<string,string>();

        public AccountNumberCacher(int index, IOperationInvoker innerInvoker)
        {
            this.index = index;
            this.innerInvoker = innerInvoker;
        }

        #region IOperationInvoker Members

        public object[] AllocateInputs()
        {
            return innerInvoker.AllocateInputs();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            MyStateContainer sc =
                OperationContext.Current.Host.Extensions.Find<MyStateContainer>();
            Console.WriteLine("*** OperationInvoker: {0} ***", sc.MyState);

            string accountNumber = inputs[index] as string;
            string value;

            if (cachedValues.TryGetValue(accountNumber, out value))
            {
                outputs = new object[0];
                return value;
            }
            else
            {
                value = innerInvoker.Invoke(instance, inputs, out outputs) as string;
                cachedValues[accountNumber] = value;
                return value;
            }
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return innerInvoker.InvokeBegin(instance, inputs, callback, state);
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            return innerInvoker.InvokeEnd(instance, out outputs, result);
        }

        public bool IsSynchronous
        {
            get { return innerInvoker.IsSynchronous; }
        }

        #endregion
    }
}
