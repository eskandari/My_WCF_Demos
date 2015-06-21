using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Extensions
{
	public class MyErrorHandler : IErrorHandler
	{
		#region IErrorHandler Members

		public bool HandleError(Exception error)
		{
			Console.WriteLine("*** IErrorHandler.HandleError was called. ***");
			Console.WriteLine(error.Message);
			return true;
		}

		public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
		{
			fault = Message.CreateMessage(version,
				FaultCode.CreateSenderFaultCode(
					"BadAccountNumberSubmission", "http://localhost/accountNumber"),
				"Bad account number submitted (IErrorHandler)",
				new BadAccountNumberSubmission(),
				"http://tempuri.org/IAccountNumber/SubmitAccountNumberBadSubmissionFault");
		}

		#endregion
	}
}
