using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Extensions;

namespace AccountNumberServiceLibrary
{
    [ServiceContract]
    public interface IAccountNumberService
    {
        [AccountNumberCaching]
        [AccountNumberParameterValidation]
        [OperationContract]
        string Lookup(string accountNumber);
    }
}
