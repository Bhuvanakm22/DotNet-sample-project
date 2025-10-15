using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace NetConceptWithWpfApp
{
    internal class DesignPatterns
    {
        public DesignPatterns()
        {
            SingletonMethod();
            RepositoryMethod();
        }
        public void SingletonMethod()
        {
            // The client code.
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
        }
        public void RepositoryMethod()
        {
            //Repository patterns can help insulate your application from changes in the data store
            //and can facilitate automated unit testing or test-driven development (TDD).
            SQLRepository sQLRepository = new SQLRepository();
        }
    }

    public sealed class Singleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton() { }

        // The Singleton's instance is stored in a static field. There are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static Singleton _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

}
