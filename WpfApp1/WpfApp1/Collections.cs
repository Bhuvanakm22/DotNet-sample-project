using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp
{
    internal class Collections
    {

        public string Name;
       public string FileName;
        public int Count;
        public List<string> Items;

        //Used "ctor" command to generate constructor by using VS IDE
        public Collections()
        {
            
        }
        //1. Place your cursor in any empty line in a class;
        //2. Press Ctrl + . to trigger the Quick Actions and Refactorings menu;
        public Collections(string name, string fileName, int count, List<string> items)
        {
            Name = name;
            FileName = fileName;
            Count = count;
            Items = items;
        }

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
