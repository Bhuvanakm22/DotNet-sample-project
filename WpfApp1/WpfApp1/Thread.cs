﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    internal class Thread
    {

        public Thread() {
            Interfaces objClsWithInterfaces = new Interfaces();
 /*
 * Task.Run(()=>XXX) can be used to convert normal method to Task(thread method)
 */
            /**** 1. Different thread concepts**/
            // Task.Run(()=> FileRead());
            /**** 5. Different thread concepts**/
            CancellationToken cancellationToken = new CancellationToken();
            int number = 5;
            ThreadPool.QueueUserWorkItem(callBack: ThreadProc, number); //Thread pooled using callback method along with object(for holding data)
                                                                        //ThreadPool.QueueUserWorkItem(delegate { AllDelegate(); }); // Thread pooled using delegate method



            //Specific Thread to initiate and start the method with thread
            /**** 4. Different thread concepts**/
            System.Threading.Thread thread = new System.Threading.Thread(new ThreadStart(PasswordCheck));
            thread.Start();

            /**** 6. Different thread concepts**/
            //Supply series of methods to the thread pool to execute
            var tasks = new Task[] {
                Task.Run(()=> PasswordCheck()) ,
                Task.Run(() => PassValid())
            };
            //Creates a task that will complete when "all of the supplied tasks" have completed.
            var ResWhenAll = Task.WhenAll(tasks);
            //Creates a task that will complete when "any of the supplied tasks" have completed.
            var ResWhenAny = Task.WhenAny(tasks);

            //To lock the object from other resources.
            lock (objClsWithInterfaces)
            {
                objClsWithInterfaces.paid();
            }
        }
        void ThreadProc(Object stateInfo)
        {
            int i = (int)stateInfo; //Convert object/ref into int/value type using "Unboxing" method
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");
        }
        public void PasswordCheck()
        {
            int i=5;
            Console.WriteLine(i);
        }
        public void PassValid()
        {
            int integer = 5;
            Console.WriteLine(integer);            
        }
    }
}
