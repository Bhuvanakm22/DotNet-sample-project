using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Documents;
using static System.Math;
namespace WpfApp1
{
    /// <summary>
    /// Single-cast delegates: Point to a single method at a time.
    ///Multicast delegates: Can point to multiple methods on a single invocation list.
    ///Anonymous methods/Lambda expressions: Allow inline methods or lambda expressions to be used wherever a delegate is expected.
    /// </summary>
    /// 
    ///extensible programming designs such as 
    ///1. event handling and 2 callback methods. 
    ///Delegates are particularly useful in implementing the 
    ///3. observer pattern and 4. designing frameworks or components 
    ///that need to notify other objects about events or changes 
    ///without knowing the specifics of those objects.
    delegate void DelegateCallback(); //Delegate initialization for void methods
    delegate int DelegateForIntback(); //Delegate initialization for int methods
    delegate int DelegateForIntCallBack(out int R, out int A);//Delegate initialization for method with some args 
    internal class Delegate
    {
        public Delegate() {
            Interfaces mainWindow = new Interfaces();
            BaseA oblBaseA = new DerivedA() ;
            DerivedA oblderived = new DerivedA() ;
            Student newoblderived = new Student() { Name = "FirstValue", Address = "Westmoreland road" };


            //Delegate to invoke multiple methods at one time
            DelegateCallback d1 = oblderived.Passvalid;
            DelegateCallback d2 = mainWindow.paid;
            DelegateCallback dd = mainWindow.paid;

            //Add two delegates
            DelegateCallback AllDelegate = d1 + d2 + dd;
            //Remove one delegate but results in the unchanged multicast delegate.
            AllDelegate -= dd;
            // copy AllMethodsDelegate while removing d2 but results in the unchanged multicast delegate.
            var oneMethodDelegate = AllDelegate - d2;
            //To count number of delegates
            int invocationCount = d1.GetInvocationList().GetLength(0);
            /*
             * Below delegate declaration is not possible it throws an error since we have used ONLY methods 
              //DelegateCallback CombinedAllMethodsDelegate = newoblderived.Passvalid + FileRead;
              //DelegateCallback CombinedAllMethodsDelegate = LoginCheck + FileRead;
              //DelegateCallback CombinedAllMethodsDelegate = LoginCheck + FileRead + d1;
              //DelegateCallback CombinedAllMethodsDelegate = LoginCheck + d1;
            */

            d1();
            d2();
            AllDelegate(); //Calling multiple methods from multiple classes at one time

            DelegateForIntCallBack d3 = LoginCheck;
            d3(out int Rad, out int Ar);
            int CopyOfD3Rad = Rad;
            int CopyOfD3Ar = Ar;
            /*
              To access a return value from delegate
             */
            //DelegateForIntback d = PasswordCheck;
            //int PassReturn = d;
            DelegateForIntback d = mainWindow.Circle;
            int PassReturn = d();
            DelegateForIntback delegatewithReturnVal = new DelegateForIntback(mainWindow.Circle);
            int ValPassReturn = delegatewithReturnVal();

            //1. Statement lambdas delegate or Anonymouos function with in the method
            Action<string> LambdaActionExpression = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            // (i).Action Method calling
            LambdaActionExpression("World");

            Action<string,string> LambdaActionExpressionWithParams = (name,exp) =>
            {
                string greeting = $"Action {name} {exp}!";
                Console.WriteLine(greeting);
            };
            //Action Method calling
            LambdaActionExpressionWithParams("Method","CodeData");
            // (ii).Compiler error bcoz Action does not return value
            //var res= LambdaActionExpressionWithParams("World", "CodeData");  //Compiler error


            //2. Expression lambda delegate
            Func<string, string> LambdaFuncExpression = name => name + " " + name;
            //Func Method calling
            var resFuncLambda = LambdaFuncExpression("John");

            Func<int, int, int, int> LambdaFuncExpressionWithParams = (a,b,c) => a + b + c;
            //Func Method calling
            var resLambdaFuncExpressionWithParams = LambdaFuncExpressionWithParams(1,2,3);
        }
        public int LoginCheck(out int Radius, out int Area)
        {
            Radius = 10;

            //To explore different casting and conversion methods
            Area = (int)PI * (int)Math.Pow(Radius, 2);
            //int circumference = Convert.ToInt32(2 * Math.PI * Radius);

            //Instead of using multiple Math. we can use using static System.Math namespace
            int circumference = Convert.ToInt32(2 * PI * Radius);
            return circumference;

        }

    }
}
