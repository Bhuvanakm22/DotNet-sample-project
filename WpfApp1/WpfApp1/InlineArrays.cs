using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp
{
    public class clsInlineArrays
    {
        CustomFeaturedArray<string> featuredArray = new CustomFeaturedArray<string>();
        public clsInlineArrays()
        {            
            featuredArray[0] = ".NET 8";
            featuredArray[1] = "C# 12";
            featuredArray[2] = "ASP.NET Core 8";
            featuredArray[3] = "EF Core 8";
            featuredArray[4] = "Blazor";
        }
        public void stringBuid()
        {
            StringBuilder sb = new();
            foreach (var str in featuredArray)
            sb.Append($"{str}, ");
            string finalResult= sb.ToString()
                .Trim()
                .Remove(sb.Length-2,2) ;
            Console.WriteLine( finalResult );
        }

        //public void PDFByteGenerator()
        //{
        //   var doc= Document.Create(container=>

        //   )
        //}
        
    }
    [InlineArray(5)]
    public struct CustomFeaturedArray<T>
    {
        private T _title;
    }
}
