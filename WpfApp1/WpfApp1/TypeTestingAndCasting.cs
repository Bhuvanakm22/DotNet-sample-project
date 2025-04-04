using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp
{
    public interface IComparable
    {
        public bool CheckType(object comparable);
        public bool CheckCasting(object comparable);
    }
    public class TypeTestingAndCasting: IComparable
    {
        public bool CheckType(object comparable)
        {
            return comparable is IComparable;
        }
        public bool CheckCasting(object comparable)
        {
            return comparable as IComparable != null;
            //as converts and returns result if is not compartable returns null
            //whereas type cast returns an error
            //ref: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#cast-expression
        }

    }
}
