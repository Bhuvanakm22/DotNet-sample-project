using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp
{
    /// <summary>
    /// Generic Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Box<T>
    {
        private T content;

        public void SetContent(T item)
        {
            content = item;
        }

        public T GetContent()
        {
            return content;
        }
}

    internal class GenericClassAndMethod
    {
        /// <summary>
        /// Like generic classes, generic methods allow you to create methods 
        /// that can work with different data types.
        /// 
        /// The FindMax method is a generic method that finds the maximum value 
        /// in an array of any type that implements the IComparable<T> interface.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public T FindMax<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length == 0)
                throw new ArgumentException("Array cannot be empty");

            T max = array[0];

            foreach (T item in array)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }

            return max;
        }
        public GenericClassAndMethod() {
       
        // 1. Generic class Usage
        Box<int> intBox = new Box<int>();
        intBox.SetContent(42);
Console.WriteLine($"Content of the integer box: {intBox.GetContent()}");

Box<string> stringBox = new Box<string>();
        stringBox.SetContent("Hello, Generics!");
Console.WriteLine($"Content of the string box: {stringBox.GetContent()}");


            // 2. Generic method Usage
            int[] numbers = { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
            Console.WriteLine($"Max number: {FindMax(numbers)}");

            string[] words = { "apple", "banana", "orange", "grape" };
            Console.WriteLine($"Max word: {FindMax(words)}");

            //3. Generic Dictionary
            dictionaries();






        }
        
        /// <summary>
        /// generic class provides a mapping from a set of keys to a set of values. 
        /// Each addition to the dictionary consists of a value and its associated key. 
        /// Retrieving a value by using its key is very fast, close to O(1), 
        /// because the Dictionary<TKey,TValue> class is implemented as a hash table.
        /// </summary>
        public void dictionaries()
        {
            //Generic Dictionary
            Dictionary<string, string> openWith = new Dictionary<string, string>();
            Dictionary<DateTime, Double> temperatureInfo = new Dictionary<DateTime, Double>();
            temperatureInfo.Add(new DateTime(2010, 6, 1, 14, 0, 0), 87.46);
            temperatureInfo.Add(new DateTime(2010, 12, 1, 10, 0, 0), 36.81);

            Console.WriteLine("Temperature Information:\n");
            string output;
            foreach (var item in temperatureInfo)
            {
                output = String.Format("Temperature at {0,8:t} on {0,9:d}: {1,5:N1}°F",
                                       item.Key, item.Value);
                Console.WriteLine(output);
            }
        }

 


    }

}
