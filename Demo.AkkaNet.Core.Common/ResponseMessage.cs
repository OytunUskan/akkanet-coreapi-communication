namespace Demo.AkkaNet.Core.Common
{
    public class RequestMessage
    {
        public RequestMessage(string requestSendMessage) {
            RequestSendMessage = requestSendMessage;
        }
        public string RequestSendMessage;
    
    }
}