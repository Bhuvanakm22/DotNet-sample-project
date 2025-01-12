using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSMQ.Messaging;
namespace NetConceptWithWpfApp
{
    /// <summary>
    /// Message will be sent to the system queue using another app "MSMQMessageSender".
    /// This "MSMQMessageReceiver" will check the queue and read the message.
    /// 
    /// Microsoft Message Queuing (MSMQ) is a Windows operating system component 
    /// that allows applications to communicate by sending and receiving messages. 
    /// MSMQ is useful when applications need to communicate across networks 
    /// that are unreliable or occasionally connected.
    /// </summary>
    internal class MSMQMessageReceiver
    {
        public MSMQMessageReceiver() {
            XmlMessageFormatter xmlFormatter = new XmlMessageFormatter(new Type[] { typeof(String) });
            MessageQueue messageQueue = new MessageQueue(@".\private$\Custombillpay");
            Message[] messages = messageQueue.GetAllMessages();
            var quelbl=messageQueue.Label;
            foreach (Message message in messages)
            {
                
                message.Formatter = xmlFormatter;
                var lbl= message.Label;
                var msg = message.Body;
                //StreamReader sr = new StreamReader(message.BodyStream);
                //var msgStreamReader = sr.ReadLine();

            }
            // after all processing, delete all the messages
            messageQueue.Purge();
        }
    }
}
