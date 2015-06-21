using System;
using System.Collections.Generic;
using System.Text;
using Extensions;

namespace AccountNumberServiceLibrary
{
    [NoBasicEndpointBehavior]
    //[ConsoleTracing]
	[MyErrorHandler]
    public class AccountNumberService : IAccountNumberService
    {
        #region IAccountNumberService Members

        public string Lookup(string accountNumber)
        {
            Console.WriteLine("Lookup method invoked with value '{0}'",accountNumber);

            switch (accountNumber)
            {
                case "12341-1234561": return "Toronto, ON";
                case "12342-1234562": return "Oshava, ON";
				case "12343-1234563": return "Newmarket, ON";
                case "12344-1234564": return "London, ON";
				case "12345-1234565": return "Kitchener, ON";
				case "12346-1234566": throw new Exception();
				default: return "unknown account number";
            }
        }

        #endregion
    }
}
