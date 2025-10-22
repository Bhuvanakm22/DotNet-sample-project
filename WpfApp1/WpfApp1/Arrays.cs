using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ClassLibraryCommon;
namespace WpfApp1
{
    public class Product
    {
        private int x;
        public int xx
        {
            get { return x; }
            set { x = value; }
        }
        public Product(int x)
        {
            this.xx = x;
        }
    }
    internal class Arrays
    {
        // Initialize private field:
        private static readonly ImmutableArray<string> _months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

        //Spread element
        string[] vowels = ["a", "e", "i", "o", "u"];
        string[] consonants = ["b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
                       "n", "p", "q", "r", "s", "t", "v", "w", "x", "z"];
        //string[] alphabet = [.. vowels, .. consonants, "y"];

        public Arrays() {
            //An array can be
            //single - dimensional,
            //multidimensional, or
            //jagged.
            //A jagged array is an array of arrays, and each member array has the default value of null.


            // Declare a single-dimensional array of 5 integers.
            int[] array1 = new int[5];

            // Declare and set array element values.
            int[] array2 = [1, 2, 3, 4, 5, 6];

            // Declare a two dimensional array.
            int[,] multiDimensionalArray1 = new int[2, 3];

            // Declare and set array element values.
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Declare a jagged array.
            int[][] jaggedArray = new int[6][];

            // Set the values of the first array in the jagged array structure.
            jaggedArray[0] = [1, 2, 3, 4];

            int[] numbers = new int[10]; // All values are 0
            string[] messages = new string[10]; // All values are null.

            //Collection expressions
            Span<string> weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

            // Collection expressions:
            int[] array = [1, 2, 3, 4, 5, 6];
            // Alternative syntax:
            int[] array245 = { 1, 2, 3, 4, 5, 6 };

            //Class array
            Product[] array25 = new Product[1] ;            
            array25.Append(new Product(2));
            array25.Append(new Product(1));
            var f=  array25.Where(p => p.xx == 1).Select(p => p);

            int[] numb = new int[] { 1, 27, 5, 4 };
            //int[] numbs = new int[3][4, 55, 66]; //this is NOT possible
            int[] numbs = new int[9] {5,86,45,7,8,6,5,4,6};
            int[] numbss = new int[9];
                numbs=[4,55,66];
            string[] strArrayValues = ["ss", "sss", ""];

            //Calling class library method. It's a reusable method all over the project.
            GenericMethod classLibraryCommon = new();
            var resultIntMax=classLibraryCommon.FindMaxValue(numbs);
            var resultStringMax = classLibraryCommon.FindMaxValue(strArrayValues);

            Console.WriteLine(resultIntMax);
            Console.WriteLine(resultStringMax);

            getMaxAdditionalDinersCount(15, 2, 3, new long[] { 11, 6, 14 });
            getMaxAdditionalDinersCount(10, 1, 2, new long[] { 2, 6 });
            Console.WriteLine("Hello, C#!");
            var a = "5555";
            var b = "6455";
            var c = "Mr. Albert";
            var age = 5;
            Console.Write(a.PadRight(10, '-'));
            Console.Write(b.PadRight(6, '-'));
            Console.Write(c.PadRight(12, '-'));
            Console.WriteLine(c.PadLeft(14, '.'));
            //Console.Clear();
            //One dimentional array
            string[] str1 = ["ss", "sss",""];
            string[] str2 = new string[2];
            str2 = ["as", "sdsd", "sdgfg", "fgfg", "gff"];
            str2.Append("bbb");

            DisplayArray(str1);
            ChangeArray(str2);
            ChangeArrayElements(str1);
            Print2DArray(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } });
            jaggedArrays();

            foreach (string s in str2)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Limited array starts------");
            string[] str22 = new string[3];
            str22 = ["cc", "", ""];
            str22.SetValue("bbb", 0);
            str22[1] = "sss";
            foreach (string s in str22)
            {
                Console.WriteLine(s);
            }

            string[] str3;
            str3 = ["mm", "jj", "kjkj", "jhj"];
            string[] str4 = new string[] { "as", "gedf" };

            str3.Count();
            //Two dimentional array
            string[,] vas = new string[2, 3] { { "dfd", "dfd", "ghg" }, { "df", "dfd", "ghg" } };
            string[,] names = { { "all", "Li" }, { "Peter", "Son" } };
            string[,] asa;
            asa = new string[2, 2]{
    {"dfd","dfdf"},{"dfd","dfd"}
    };
            //Multidimensional arrays
            int[,] array2DDeclaration = new int[4, 2];

            int[,,] array3DDeclaration = new int[4, 2, 3];

            // Two-dimensional array.
            int[,] array2DInitialization = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            // Three-dimensional array.
            int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4,   5,  6 } },
                                { { 7, 8, 9 }, { 10, 11, 12 } } };


            try
            {
                if (a.GetType() == typeof(string))
                    Console.WriteLine("I am checked corrrectly");
                //Comparison of two variables with "IS"(type testing)
                if (a is string)
                    Console.WriteLine("I am checked corrrectly");
                if (a is not null)
                    if (asa.Length != 0)
                    {

                    }
                    else
                    {
                        /*Throw the exception to the calling method with new or custom exception. 
                        Stack trace will hold the origin of the method as well*/

                        //throw new NotImplementedException("Custom error");
                        throw new FormatException("Cust error!!!!");
                    }
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException || ex is NotImplementedException)
            {

                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("");
            }
        }
        static void DisplayArray(string[] arr) => Console.WriteLine(string.Join(" ", arr));

        // Change the array by reversing its elements.
        static void ChangeArray(string[] arr) => Array.Reverse(arr);

        static void ChangeArrayElements(string[] arr)
        {
            // Change the value of the first three array elements.
            arr[0] = "Mon";
            arr[1] = "Wed";
            arr[2] = "Fri";
        }

        //Pass multidimensional arrays as arguments
        static void Print2DArray(int[,] arr)
        {
            // Display the array elements.
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    System.Console.WriteLine("Element({0},{1})={2}", i, j, arr[i, j]);
                }
            }
        }
        //jaggedArray, is declared in one statement. Each contained array is created in subsequent statements.
        //The second example, jaggedArray2 is declared and initialized in one statement. It's possible to mix jagged and multidimensional arrays.
        //The final example,
        //jaggedArray3, is a declaration and initialization of a single-dimensional jagged array that contains three two-dimensional array elements of different sizes.
        public void jaggedArrays()
        {
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = [1, 3, 5, 7, 9];
            jaggedArray[1] = [0, 2, 4, 6];
            jaggedArray[2] = [11, 22];

            int[][] jaggedArray2 =
            [
                [1, 3, 5, 7, 9],
                [0, 2, 4, 6],
                [11, 22]
            ];

            // Assign 77 to the second element ([1]) of the first array ([0]):
            jaggedArray2[0][1] = 77;

            // Assign 88 to the second element ([1]) of the third array ([2]):
            jaggedArray2[2][1] = 88;

            int[][,] jaggedArray3 =
            [
                new int[,] { {1,3}, {5,7} },
    new int[,] { {0,2}, {4,6}, {8,10} },
    new int[,] { {11,22}, {99,88}, {0,9} }
            ];
        }
        public long getMaxAdditionalDinersCount(long N, long K, int M, long[] S)
        {

        long[] tempSeat = new long[N];
            long[] FinalSeats = new long[N];
            int count = 0;

            for (int i = 0; i < N; i++)
            {
                tempSeat[i] = i + 1;
            }
            for (int j = 0; j < S.Length; j++)
                for (int i = 0; i < N; i++)
                    if ((S[j] == tempSeat[i]) && count <= M)
                    {
                        count++;
                        for (int x = 1; x <= K; x++)
                        {
                            try
                            {
                                tempSeat[i - x] = 0;
                                tempSeat[i + x] = 0;
                            }
                            catch (IndexOutOfRangeException) { }

                        }

                        tempSeat[i] = 0;

                    }
            for (int i = 0; i < N; i++)
            {
                int Lflagcount = 0;
                int Rflagcount = 0;
                if (tempSeat[i] != 0)
                {
                    for (int j = 1; j <= K; j++)
                    {
                        try
                        {
                            if ((tempSeat[i - j] != 0) || tempSeat[i - j] == 0)

                                Lflagcount++;
                        }
                        catch (IndexOutOfRangeException) { Lflagcount++; }
                        try
                        {
                            if ((tempSeat[i + j] != 0) || (tempSeat[i + j] == 0))
                                Rflagcount++;
                        }
                        catch (IndexOutOfRangeException) { Rflagcount++; }
                        //tempSeat[i] = 0;

                    }
                    if(Rflagcount==K && Lflagcount==K)
                    {
                        for (int j = 1; j <= K; j++)
                        {
                            try
                            {
                                tempSeat[i - j] = 0;

                                    
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                tempSeat[i + j] = 0;
                                    
                            }
                            catch (IndexOutOfRangeException) { }
                            //tempSeat[i] = 0;

                        }
                    }
                 }
            }
                long totcnt = tempSeat.Where(x => x != 0).Count();

            return totcnt;
        }
    }
}
