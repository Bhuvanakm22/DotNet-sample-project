using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp
{
    internal class CollectionsAndHash
    {
        public CollectionsAndHash() {
            HashTables();
            SortedLists();
            HashSets();
            Queues();
            EmptyCollection();
            SpreadCollection();
        }
        public void EmptyCollection()
        {
            //null assignment
            var list = new List<string>();
            //EmptyCollection assignment
            List<string> emptyList = [];
            emptyList = ["Beach"];
            list.Add("Beach");


        }
        /// <summary>
        /// .. Spread operator to combain to lists
        /// </summary>
        public void SpreadCollection()
        {
            List<string> list1 = ["Hi","Hello","Dear"];
            List<string> list2 = ["Albert","Amster","Agony"];
            List<string> spreadList = [..list1,..list2];
            Console.WriteLine(string.Join(",", spreadList));
            
        }
        public void HashTables()
        {
            Hashtable ht = new Hashtable();
            //Adding item into HashTable  
            ht.Add(1, "Abi");
            ht.Add(12, "Bhuvana");
            ht.Add(8, "Dinesh");
            //Checking
            if (ht.ContainsValue("Sikar"))
                Console.WriteLine("Sikar is already exist in the HashTable");
            else
                ht.Add(5, "Sikar");
            //Get a collection of values  
            Console.WriteLine("Values are :");
            ICollection values = ht.Values;
            foreach (string str in values)
                Console.WriteLine(str);
            //Get a collection of Keys  
            Console.WriteLine("Keys are :");
            ICollection keys = ht.Keys;
            foreach (int i in keys)
                Console.WriteLine(i);
            ht.Remove(1);
            ht.Clear();
        }
        public void SortedSet()
        {
            SortedSet<string> strings = new SortedSet<string>();
        }
        public void SortedLists()
        {
            SortedList sl = new SortedList();
            //Adding item into SortedList  
            sl.Add(12, "Canada");
            sl.Add(8, "India");
            sl.Add(4, "UK");
            sl.Add(1, "USA");
            Console.WriteLine("Count : {0}", sl.Count);
            if (sl.ContainsValue("Srilanka"))
                Console.WriteLine("Srilanka is already exist in the SortedList");
            else
                sl.Add(5, "Srilanka");
            Console.WriteLine("Value and key at position 2 is {0} , {1}", sl.GetByIndex(2), sl.GetKey(4));
            Console.Write("keys are : ");
            foreach (int i in sl.Keys)
                Console.Write(i + " ");
            sl.Remove(4);
            //Geting the keys and value from SortedList  
            IList keys = sl.GetKeyList();
            IList values = sl.GetValueList();
            Console.WriteLine("\nValues are :");
            foreach (object obj in values)
                Console.WriteLine(obj);
            Console.WriteLine("Index of India is : {0}", sl.IndexOfValue("India"));
            // Remove an element at specified index  
            sl.RemoveAt(2);
        }
        public void Queues()
        {
            // Declaring a Queue  
            Queue q = new Queue();
            // Adds an element at the end of Queue i.e. Enqueue operation  
            q.Enqueue("Pankaj");
            q.Enqueue(1);
            q.Enqueue(10.5);
            q.Enqueue(true);
            q.Enqueue('A');
            //Get the number of elements present in the Queue  
            Console.WriteLine("Count : {0}", q.Count);
            Console.WriteLine();
            //Printing all the element of Queue  
            Console.WriteLine("Element in Queue : ");
            foreach (object obj in q)
                Console.WriteLine(obj);
            Console.WriteLine();
            //Returns the end of the Queue without removing  
            Console.WriteLine("End element of Queue : {0}", q.Peek());
            Console.WriteLine();
            //Removes and Returns the end element of the Queue i.e. Dequeue operation  
            object TopElement = q.Dequeue();
            Console.WriteLine("Removing End element of Queue = {0}\nNow End element of Queue = {1}\n", TopElement, q.Peek());
            //Determines whether an element present or not in the Queue  
            if (q.Contains("Pankaj"))
                Console.WriteLine("Pankaj Found");
            else
                Console.WriteLine("Pankaj Not found");
            //Copies the qack to a new Array(object)  
            Object[] ob = q.ToArray();
            Console.WriteLine();
            foreach (object obj in ob)
                Console.WriteLine(obj);
            //Trim the Queue  
            q.TrimToSize();
            //Removes all the element from Queue  
            q.Clear();
            Console.WriteLine();
            Console.WriteLine("Count : {0}", q.Count);
        }
        public void HashSets()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);

                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }

            Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
            DisplaySet(evenNumbers);

            Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
            DisplaySet(oddNumbers);

            // Create a new HashSet populated with even numbers.
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(oddNumbers);

            Console.Write("numbers contains {0} elements: ", numbers.Count);
            DisplaySet(numbers);

            void DisplaySet(HashSet<int> collection)
            {
                Console.Write("{");
                foreach (int i in collection)
                {
                    Console.Write(" {0}", i);
                }
                Console.WriteLine(" }");
            }
        }

        public void ArrayLists()
        {
            ArrayList al = new ArrayList();
            ArrayList al1 = new ArrayList();
            // Adding object into the ArrayList  
            al1.Add('a');
            al1.Add('b');
            al.Add('k');
            al.Add('l');
            al.Add('j');
            // Adding Arraylist at specific position into the ArrayList  
            al.InsertRange(2, al1);
            //Get the Capacity and number of element present in the ArrayList  
            // Note that Capacity and Count are not equal  
            Console.WriteLine("Count: {0}", al.Count);
            Console.WriteLine("Capacity before TrimToSize: {0} ", al.Capacity);
            al.TrimToSize();
            Console.WriteLine("Capacity after TrimToSize: {0} ", al.Capacity);
            Console.WriteLine(al.Contains('b'));
            Console.Write("Element befor sort: ");
            foreach (object obj in al)
                Console.Write(obj + " ");
            Console.Write("\nElement after sort: ");
            al.Sort();
            foreach (object obj in al)
                Console.Write(obj + " ");
            al.Reverse();
            Console.Write("\nElement after reverse: ");
            foreach (object obj in al)
                Console.Write(obj + " ");
            Console.WriteLine("\nIndex of char 'k' is : {0}", al.IndexOf('k'));
            // clear the ArrayList  
            al.Clear();
            Console.WriteLine("\nCount: {0}", al.Count);
            Console.ReadKey();
        }
        public void Stacks()
        {
            // Declaring a stack  
            Stack st = new Stack();
            // Inserting an element at the top of stack i.e. Push operation  
            st.Push("Pankaj");
            st.Push(1);
            st.Push(10.5);
            st.Push(true);
            st.Push('A');
            //Get the number of elements contained in the stack  
            Console.WriteLine("Count : {0}", st.Count);
            Console.WriteLine();
            //Printing all the element of stack  
            Console.WriteLine("Element in stack : ");
            foreach (object obj in st)
                Console.WriteLine(obj);
            Console.WriteLine();
            //Returns the topmost element of the stack without removing  
            Console.WriteLine("Top most element of stack : {0}", st.Peek());
            Console.WriteLine();
            //Removes and Returns the topmost element of the stack i.e. Pop operation  
            object TopElement = st.Pop();
            Console.WriteLine("Removing Top element of Stack = {0}\nNow Top element of stack = {1}\n", TopElement, st.Peek());
            //Determines whether an element present or not in the stack  
            if (st.Contains("Pankaj"))
                Console.WriteLine("Pankaj Found");
            else
                Console.WriteLine("Pankaj Not found");
            //Copies the stack to a new Array(object)  
            Object[] ob = st.ToArray();
            Console.WriteLine();
            foreach (object obj in ob)
                Console.WriteLine(obj);
            //Removes all the element from stack  
            st.Clear();
            Console.WriteLine();
            Console.WriteLine("Count : {0}", st.Count);
            Console.ReadKey();
        }
    }
}
