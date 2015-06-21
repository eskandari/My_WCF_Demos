using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel;

namespace Extensions
{
    public class NoBasicEndpointBehavior : Attribute, IServiceBehavior
    {
        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (ServiceEndpoint se in serviceDescription.Endpoints)
                if (se.Binding.Name.Equals("BasicHttpBinding"))
                    throw new FaultException("Please don't use the BasicHttpBinding...choose a secure endpoint binding");

        }

        #endregion
    }
}
