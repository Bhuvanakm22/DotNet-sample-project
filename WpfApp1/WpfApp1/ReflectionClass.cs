using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NetConceptWithWpfApp
{
    /// <summary>
    /// Reflection is a mechanism in C# that allows inspecting and interacting 
    /// with metadata about types, fields, properties, and methods. 
    /// While it provides a way to access private methods, 
    /// it should be used cautiously due to its potential impact 
    /// on maintainability and performance.
    /// </summary>
    public class ReflectionClass
    {

        //private method only accessible within the class
        private void PrivateMethod()
        {
            Console.WriteLine("PrivateMethod");
        }
    }
    public class MyClass
    {
        ReflectionClass objReflectionClass=new ReflectionClass();
        public MyClass() {

            // Using Reflection to access the private method
            MethodInfo privateMethod = typeof(ReflectionClass).GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);

            if (privateMethod != null)
            {
                privateMethod.Invoke(objReflectionClass, null);
            }
        }


    }
}
