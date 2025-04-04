using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class VariousClasses
    {
       public  VariousClasses() {
            DerivedA objderived = new DerivedA();
            objderived.login();
        }
    }
    internal class ClsInternalClasses : Abstractclass
    {
     //Cannot be shared outside
     public override void login()
        {
            Console.WriteLine("");
        }
    }
    public enum Level
    {
        Low,
        Medium,
        High,
        VeryHigh
    }
    sealed class CannotInheritclass
    {
        public void SealedMethodlogin()
        {

        }
        public void SealedMethod()
        {
            Console.WriteLine("");
        }
    }

    /*
     * ***********Will throw error since we cannot inherit sealed class
    //public class clsDerivedB: CannotInheritclass
    //{ 
    //}
    */

    //It contains only abstration and no implementation which is used to hide the method definition. Similar to interface
    abstract class Abstractclass
    {
        public abstract void login();
        public void AbstractMethod()
        {
            Console.WriteLine();
        }
    }
    static class StaticClass 
    {
        public static void StatMethod()
        {
            Console.WriteLine("");
        }
    }
    //Interface
    public interface IclassInterface
    {
        void Passvalid();
        void CheckP();
        public int Loginvalid(int a, int b);
    }
    public class BaseA: IclassInterface
    {
        public virtual void login()
        {
            Console.WriteLine("Base class");
        }
        public virtual void Passvalid()
        {
            throw new NotImplementedException();
        }
        public void CheckP()
        {
            Console.WriteLine("WithoutVirtual");
        }
        public int Loginvalid(int a, int b)
        {
            return a + b;
        }
    }
    public class DerivedA : BaseA, IclassInterface
    {

        public override void login()
        {
            Console.WriteLine("Derived class method redefination using override.");
        }
        //Override interface definition with key "new"
        public new void CheckP()
        {

            Console.WriteLine("");
        }
        public void Passcheck<T>(T a, T b)
        {
            Console.WriteLine(a);
            //return 0;
        }

        public int Passcheck(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }
        public override void Passvalid()
        {
            Console.WriteLine("Passvalid");
        }
        public string StatMethod(int a,int b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            else
            {
                return (a + b).ToString();
            }
            
        }
        private object objlock = new object();

    }//clsDerived

}
