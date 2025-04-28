using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp
{
    internal class Collections
    {
        /// <summary>
        /// the "yield" keyword allows you to create iterator methods, which are methods 
        /// that return an IEnumerable or IEnumerator interface. It enables you to generate a sequence of values one at a time, 
        /// rather than constructing the entire collection in memory upfront. 
        /// This is particularly useful for dealing with large datasets or when memory efficiency is a concern. 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IEnumerable<int> GetEvenNumbersEfficiently(int n)
        {
            for(int i = 0; i <= n; i++)
            {
                if((i%2)==0)
                 yield return i;
            }
            
        }
        public IEnumerable<int> GetEvenNumbersUnefficient(int n)
        {
            var result = new List<int>();
            for (int i = 0; i <= n; i++)
            {
                if ((i % 2) == 0)
                    result.Add( i);
            }
            return result;

        }
    }
}
