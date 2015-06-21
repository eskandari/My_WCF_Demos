using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Extensions
{
    public class ConsoleMessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        Message TraceMessage(Message input)
        {
            MessageBuffer buffer = input.CreateBufferedCopy(int.MaxValue);
            Message newMsg = buffer.CreateMessage();
            Console.WriteLine(newMsg);
            return buffer.CreateMessage();
        }

        #region IClientMessageInspector Members

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            reply = this.TraceMessage(reply);
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            request = this.TraceMessage(request);
            return null;
        }

        #endregion

        #region IDispatchMessageInspector Members

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            MyStateContainer sc = 
                OperationContext.Current.Host.Extensions.Find<MyStateContainer>();
            Console.WriteLine("*** MessageInspector: {0} ***", sc.MyState);
            sc.MyState = "bar";

            request = this.TraceMessage(request);
            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            reply = this.TraceMessage(reply);
        }

        #endregion
    }
}
