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
        public ClsLists()
        {
            strList.Add("1");
            strList.Append("2");
            strList.Reverse();
            strList.Remove("1");
            //strList[0]="4"; This is not possible 
        }




    }
}
