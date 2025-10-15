using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace NetConceptWithWpfApp
{
    internal class LINQ
    {
        public LINQ() {

            using (var context = new SchoolContext())
            {
                //Using SQL query
                var students = context.Student
                    .FromSql($"Select * from Student")
                    .ToList();
                //The examples above will execute the following SQL query to the SQL Server database:
                //exec sp_executesql N'Select * from Student where Name = ''@p0''',N'@p0 nvarchar(4000)',@p0 = N'name'
                //go
                var studts = context.Student
                    .FromSql($"Select * from Student")
                    .OrderBy(s => s.StudentId);
            }

            }

    }
}
