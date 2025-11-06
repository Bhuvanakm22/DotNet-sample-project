using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace NetConceptWithWpfApp
{
    //?? and ??= operators - the null-coalescing operators
    internal class NullCheck
    {
        int? height = null;
        public NullCheck(int _height)
        {

            if (height is null)
            {
                height = 0;
            }
            //?? and ??= operators - the null-coalescing operators
            height ??= 0;
            height = 9;
            _height = height ?? 0;
        }
    }
}
