using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.SERVICE.EINVOICE.Helpers
{
    public static class CookieHelper
    {
        public static CookieBehavior COOKIEBEHAVIOR { get; set; }
       
    }
    public class CookieBehavior : IEndpointBehavior
    {
        private CookieContainer cookieCont;

        public CookieBehavior(CookieContainer cookieCont)
        {
            this.cookieCont = cookieCont;
        }

        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
        {
            behavior.ClientMessageInspectors.Add(new CookieMessageInspector(cookieCont));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
        {

        }

        public void Validate(ServiceEndpoint serviceEndpoint)
        {

        }
    }
    public class CookieMessageInspector : IClientMessageInspector
    {
        private CookieContainer cookieCont;

        public CookieMessageInspector(CookieContainer cookieCont)
        {
            this.cookieCont = cookieCont;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            object obj;
            if (reply.Properties.TryGetValue(HttpResponseMessageProperty.Name, out obj))
            {
                HttpResponseMessageProperty httpResponseMsg = obj as HttpResponseMessageProperty;
                if (!string.IsNullOrEmpty(httpResponseMsg.Headers["Set-Cookie"]))
                {
                    cookieCont.SetCookies((Uri)correlationState, httpResponseMsg.Headers["Set-Cookie"]);
                }
            }
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            object obj;
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out obj))
            {
                HttpRequestMessageProperty httpRequestMsg = obj as HttpRequestMessageProperty;
                SetRequestCookies(channel, httpRequestMsg);
            }
            else
            {
                var httpRequestMsg = new HttpRequestMessageProperty();
                SetRequestCookies(channel, httpRequestMsg);
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMsg);
            }

            return channel.RemoteAddress.Uri;
        }

        private void SetRequestCookies(IClientChannel channel, HttpRequestMessageProperty httpRequestMessage)
        {
            httpRequestMessage.Headers["Cookie"] = cookieCont.GetCookieHeader(channel.RemoteAddress.Uri);
        }
    }


}
