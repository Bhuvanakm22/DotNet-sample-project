using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp
{
    public class SimpleCalculator
    {
       
        public SimpleCalculator() {
            
            //Multiply and divide without * and / (with only + and -)
            int div = Divide(5, 2);
            int mul = multiple(5, 2);
        }
        public int add(int a, int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
        public int multiple(int a, int b)
        {
            int temp = 0;
            for (int i = 0; i < a; i++)
            {
                temp += b;
            }
            return temp;
        }
        public int Divide(int a, int b)
        {
            //try
            //{


                if (b <= 0)
                    throw new DivideByZeroException();
                int temp = 0;
                while (a >= b)
                {
                    a -= b;
                    temp++;
                }

                return temp;
            //}
            //catch (DivideByZeroException) {
            //return 0;
            //}
        }
    }
}
