using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class ArrayDeclaration
    {
        public ArrayDeclaration() {
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
            string[] str1 = ["ss", "sss"];
            string[] str2 = new string[2];
            str2 = ["as", "sdsd", "sdgfg", "fgfg", "gff"];
            str2.Append("bbb");
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
