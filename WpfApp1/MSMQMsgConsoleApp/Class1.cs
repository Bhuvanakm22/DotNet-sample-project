//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    // See https://aka.ms/new-console-template for more information
//    //public class MathUtils
//    //{
//    //    public static double Average(int a, int b)
//    //    {
//    //        return Convert.ToDouble((a + b) / 2);
//    //    }

//    //    public static void Main(string[] args)
//    //    {
//    //        Console.WriteLine(Average(2, 1));
//    //        Console.ReadKey();
//    //    }
//    //}
//    using System.Collections.Generic;
//    using System;
//    public interface IAlertDAO1
//    {
//        public void AlertDAO()
//        {

//        }
//        public Guid AddAlert(DateTime time);
//        public DateTime GetAlert(Guid id);
//    }

//    public class AlertService
//    {
//        private readonly AlertDAO storage = new AlertDAO();
//        public AlertService(IAlertDAO alert)
//        {

//        }

//        public Guid RaiseAlert()
//        {
//            return this.storage.AddAlert(DateTime.Now);
//        }

//        public DateTime GetAlertTime(Guid id)
//        {
//            return this.storage.GetAlert(id);
//        }
//    }

//    public class AlertDAO : IAlertDAO
//    {
//        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

//        public Guid AddAlert(DateTime time)
//        {
//            Guid id = Guid.NewGuid();
//            this.alerts.Add(id, time);
//            return id;
//        }

//        public DateTime GetAlert(Guid id)
//        {
//            return this.alerts[id];
//        }
//        //public static void Main(string[] args)
//        //{
//        //    //Console.WriteLine(Average(2, 1));
//        //    Console.ReadKey();
//        //}
//    }
//}
