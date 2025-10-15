using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConceptWithWpfApp.Interface
{
    internal interface ISQLRepository
    {
        public void SQLConnection();
        public void insertData();
        public void UpdateData();
        public void GetData();

    }
}
