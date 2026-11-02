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
                var studt = context.Student
               .Where(c=>c.GradeId == 0)
                  .OrderBy(s => s.StudentId);
            }

            }

    }
    public class DtoObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
    }
    public class FindDuplicateString
    {
        public FindDuplicateString()
        {
            var res = FindStrings();
        }
        public List<string> FindStrings()
        {
            List<DtoObject> dtoObjects = new List<DtoObject>();
            dtoObjects.AddRange(
                [
                new DtoObject { Name = "JohnPeter", Description = "test1", City = "Bromley" },
                new DtoObject { Name = "JohnDrowe", Description = "test2", City = "Bromley" },
                new DtoObject { Name = "JohnAdam", Description = "test3", City = "Bromley" },
                new DtoObject { Name = "JohnAdam", Description = "test6", City = "Norwich" },
                new DtoObject { Name = "JohnSlag", Description = "test4", City = "Norwich" },
                new DtoObject { Name = "JohnLora", Description = "test5", City = "Oxford" }
                ]
            );
            var res = dtoObjects
                //GroupBby => catogorize into (Key,value ) pair based on the given column(City prop/string) condition
                //eg., Bromley,(obj1,obj2,obj3)
                //Norwich,(obj1,obj2)
                //Oxford,(obj1)
                .GroupBy(x => x.City)
                //Where => further add Filters to the grouped clause. Here checks Same cities with values count > 1
                //eg., Oxford city will be eliminated since it has only one row count
                .Where(x => x.Count() > 1)
                //Select entire object values or We can filter only particular column
                .Select(c => c)
                .OrderBy(x=>x.GroupBy(c=>c.Name))
                .ToList();

            List<string> strings = new List<string> { "test", "test", "testing", "test", "demo", "testing" };
            return
                strings
                .GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();

        }
    }
}
