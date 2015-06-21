using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.Text.RegularExpressions;
using System.ServiceModel;

namespace Extensions
{
    public class AccountNumberInspector : IParameterInspector
    {
        int index = 0;

        public AccountNumberInspector() : this(0) { }
        public AccountNumberInspector(int index) { this.index = index; }

        #region IParameterInspector Members

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            MyStateContainer sc =
                OperationContext.Current.Host.Extensions.Find<MyStateContainer>();
            Console.WriteLine("*** ParameterInspector: {0} ***", sc.MyState);
            sc.MyState = "baz";

            if (!Regex.IsMatch(inputs[index] as string, @"\d{5}-\d{7}"))
                throw new FaultException("Invalid account number format...please use ddddd-ddddddd");
            return null;
        }

        #endregion
    }
}
