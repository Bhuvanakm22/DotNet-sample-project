using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ClassesVariousMethods
    {
        //Normal class property declaration
        public string Name { get; set; }= string.Empty;
       public  ClassesVariousMethods(string name) {
            Name = name;
            Console.WriteLine(Name);
            DerivedA objderived = new DerivedA();
            objderived.login();
        }
    }
    public class PropertiesInitClasses
    {
        //Normal class property declaration
        public string Name { get; set; } = string.Empty;
    }

        /// <summary>
        /// Record class reduces the constructor overhead.
        /// It allows only the record class as a base class, below "Abstractclass2" implementation is not possible
        /// </summary>
        /// <param name="Name"></param>
        //public record class RecordClass(string Name) : Abstractclass2
    public record class RecordClass(string Name) 
    {
        public void login2()
        {
            Console.WriteLine(Name);
        }
    }

    abstract class Abstractclass2
    {
        public abstract void login2();
    }
    //It contains only abstration and no implementation which is used to hide the method definition. Similar to interface
    /// <summary>
    /// Abstract classes can define "common functionality" and state that subclasses can inherit and use. 
    /// Use them when you have a common base with shared functionality and behavior for a hierarchy of related classes, 
    /// or when you need to control the inheritance model. 
    /// </summary>
    abstract class Abstractclass
    {
        //Below will throw an err if we declare with "virtual" WITHOUT body of the fn.
        //if there is NO body of the fn in abstract class must declare with "abstract" keyword
        //public virtual void Validate();
        public abstract void Validate();
        public abstract void login();

        // Derived class can be overridden with their own definition if we use "virtual"
        //Whereas when we use "abstract" Derived class MUST be overridden
        public virtual void Validate2()
        {
            Console.WriteLine();
        }

        public void AbstractMethod()
        {
            Console.WriteLine();
        }
    }
    /*Below line will give Error when More than one abstractclass implemented
     * but we can implement more than one interface at a time
     * Abstract class => base class 
     * Interface => allowing it to adopt different behaviors. 
      internal class ClsInternalClasses : Abstractclass, Abstractclass2
    {
    }
    */
    //internal class  Cannot be shared outside
    internal class ClsInternalClasses : Abstractclass
    {
     
     public override void login()
        {
            Console.WriteLine("");
        }
        public override void Validate()
        {
            Console.WriteLine();
        }
        public override void Validate2()
        {
            Console.WriteLine();
        }
        //public new void AbstractMethod()
        //{
        //    Console.WriteLine();
        //}
    }
    public enum Level
    {
        Low,
        Medium,
        High,
        VeryHigh
    }
    /*
 * ***********Will throw error since we cannot inherit sealed class
//public class clsDerivedB: CannotInheritclass
//{ 
//}
*/
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

    
    static class StaticClass 
    {
        public static void StatMethod()
        {
            Console.WriteLine("");
        }
    }
    //Interface
    /// <summary>
    /// Interfaces promote "loose coupling" by specifying what a class does, not how it does it. 
    /// Use them when you want to define a contract that classes must adhere to, without specifying any implementation details, 
    /// or when you need to implement multiple behaviors across different class hierarchies
    /// </summary>
    public interface IclassInterface
    {
        void Passvalid();
        void CheckP();
        public int Loginvalid(int a, int b);
    }
    public class BaseA: IclassInterface
    {

        // Derived class can be overridden with their own defination if we use "virtual"
        //Whereas when we use "abstract" Derived class MUST be overridden
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
        ////Property initialization while creating an object
        PropertiesInitClasses propertiesInitClasses = new PropertiesInitClasses { Name = "John" };
        PropertiesInitClasses propertiesInitClasses2 = new PropertiesInitClasses() { Name = "John" };
        PropertiesInitClasses propertiesInitClasses3 = new() { Name = "John" };
        ////Below instantiation is not possible as there is NO constructor available for PropertiesInitClasses
        //PropertiesInitClasses propertiesInitClasses4 = new PropertiesInitClasses("John") { Name = "John" };

        public override void login()
        {
            Console.WriteLine("Derived class method redefination using override.");
        }
        
        /* Hide base/abstract class implementation 
         * and Override interface definition by specifying "new" keyword */
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

    public class ConstClass
    {
        public const string NameChange = "John";

    }
}
