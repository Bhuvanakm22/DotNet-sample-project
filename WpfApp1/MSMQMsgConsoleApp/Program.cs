// See https://aka.ms/new-console-template for more information
//public class MathUtils
//{
//    public static double Average(int a, int b)
//    {
//        return Convert.ToDouble((a + b) / 2);
//    }

//    public static void Main(string[] args)
//    {
//        Console.WriteLine(Average(2, 1));
//        Console.ReadKey();
//    }
//}
using System.Collections.Generic;
using System;
using MSMQ.Messaging;
using System.Reflection.PortableExecutable;
using System.Linq.Expressions;
public class MSMQMessageSender
{
   
    public static void Main(string[] args)
    {

        /*Private queues take the form machinename\Private$\queuename.
           * Local host machines are referenced with a dot or a period*/
        if (!MessageQueue.Exists(@".\private$\Custombillpay"))
        {
            // Create the Queue
            MessageQueue.Create(@".\private$\Custombillpay");
        }
        MessageQueue messageQueue = null;
        Message message = null;
        Payment myPayment;
        myPayment.Payor = "SuperMarket";
        myPayment.Payee = "User";
        myPayment.Amount = Convert.ToInt32(100);
        myPayment.DueDate = DateTime.Now.AddDays(20).ToString();
        messageQueue = new MessageQueue(@".\private$\Custombillpay");
        messageQueue.Label = "Custombillpay Queue";
        message = new Message(messageQueue);
        message.Label = "Payment details";
        //StreamWriter sw = new StreamWriter(myPayment);
        message.Body = myPayment.Payor +" "+ myPayment.Payee;
        messageQueue.Send(message);// "First ever Message is sent to MSMQ", "Title");
        Console.WriteLine("=============*******************=================");
        Console.WriteLine("Goto=>Computer Management->->Services and Applications->find MSMQ");
        Console.ReadKey();
    }
    public struct Payment
    {
        public string Payor, Payee;
        public int Amount;
        public string DueDate;
    }
}