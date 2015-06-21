using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Extensions
{
	public class MyErrorHandlerAttribute : Attribute, IServiceBehavior
	{
		#region IServiceBehavior Members

		public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			foreach (ChannelDispatcher cd in serviceHostBase.ChannelDispatchers)
				cd.ErrorHandlers.Add(new MyErrorHandler());
		}

		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
		}

		#endregion
	}
}
