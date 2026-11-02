using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp
{
    internal class ClsLists
    {
        List<string> strList = new List<string>();
        //This is not possible
        //List<string> strList1 = {"sd","sds"};
        public ClsLists()
        {
            strList.Add("1");
            strList.Append("2");
            strList.Reverse();
            strList.Remove("1");
            //strList[0]="4"; This is not possible 
        }




    }

    class Result
    {

        /*
         * Complete the 'lonelyinteger' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */

        public static int lonelyinteger(List<int> a)
        {
            var ns = a.GroupBy(x => x).Single(x => x.Count() == 1).Key;
            Dictionary<int, int> dic = new();
            for (int i = 0; i < a.Count; i++)
            {
                if (!dic.ContainsKey(a[i]))
                    dic.Add(a[i], 1);
                else
                    dic[a[i]] += 1;
            }
            var res = dic.FirstOrDefault(x => x.Value == 1).Key;
            return res;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            int result = Result.lonelyinteger(a);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
