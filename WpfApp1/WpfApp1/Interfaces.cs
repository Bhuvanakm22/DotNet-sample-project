using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WpfApp1
{
    public interface IClsWithInterfaces1
    {
        void paid();
        void Shade();
        //Below implementation is possible in C# 8
        int Circle()
        {
            return 0;
        }
        int Square();
        int Rectangle()
        {
            return 0;
        }
    }
    public interface IClsWithInterfaces2
    {
        int paid
        {  get; }

        void Shade();
        int Circle()
        {
            return 50;
        }
        int Square();
        int Rectangle()
        {
            return 50;
        }
    }
    public class Interfaces : IClsWithInterfaces1, IClsWithInterfaces2
    {
        /*  Below is an "explicit interface" */
        int IClsWithInterfaces2.paid { 
            get
            { return 0; } 
        }
        /*  Below is an "implicit interface" */
        public void paid() {
            Console.WriteLine("paid");

        }
        /*  Below is an "implicit interface" */
        public void Shade()
        {
            Console.WriteLine("Both interfaces called the same Shade");
        }
        //All the objects will call the same below method irrespective of interface method implementation
        public int Circle()
        {
            return 1;
        }

        
        int IClsWithInterfaces1.Square()
        /*  public int IClsWithInterfaces1.Square()
         *  public or modifier is not needed for explict interface implementation
         *  */
        {
            return 0;
        }
        int IClsWithInterfaces2.Square()
        /*  public int IClsWithInterfaces2.Square()
         *  public or modifier is not needed for explict interface implementation
         *  */
        {
            return 50;
        }

        /*
         * Implementation is not necessary bcoz it alread done in respective interfaces method
         * is inherited from IClsWithInterfaces1 and IClsWithInterfaces2.
        int Rectangle()
        {

        }
        */
    }
    public  class clsMainInterface
    {
        public clsMainInterface()
        {
            Interfaces objcls = new Interfaces();
            IClsWithInterfaces1 clsWithInterfaces1 = objcls;
            IClsWithInterfaces2 clsWithInterfaces2 = objcls;
            objcls.paid();

            //var fld= objcls.paid;//Will not work since it is a "explicit interface"
                                 //which cannot be accessed with this instance instead below will work
            var fld2 = clsWithInterfaces2.paid; // "explicit interface" instance will call the property
            var objcls1 = objcls as IClsWithInterfaces1;
            //All the objects will call the same below method irrespective of interface method implementation
            var rad = objcls.Circle();  //return 1
            var rad1 = clsWithInterfaces1.Circle(); //return 1
            var rad2 = clsWithInterfaces2.Circle(); //return 1
            var area1 = clsWithInterfaces1.Square(); //return 0
            var area2 = clsWithInterfaces2.Square(); //return 50
             //var area3 = objcls.Square(); // will throw compliler error
             /* below Implicitly called the interface implementation even though there is no imp in actual class */
            var areaRect = clsWithInterfaces1.Rectangle(); //return 0
            var areaRect2 = clsWithInterfaces2.Rectangle(); //return 50
            //var areaRect3 = objcls.Rectangle(); // will throw compliler error
        }

    }
}
