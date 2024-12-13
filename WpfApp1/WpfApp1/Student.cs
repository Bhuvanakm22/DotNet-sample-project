using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace WpfApp1
{
    public interface IStudent
    {
        public void CheckP();
    }
    public class Grade : IStudent
        {
        public int GradeId { get; set; }
        public required string GradeName { get; set; }
        public string? Section { get; set; }
        public void CheckP()
        {
            Console.WriteLine("WithoutVirtual");
        }
        // public virtual ICollection<Student> Students { get; private set; } =  new ObservableCollection<Student>();

    }
    public class Student  : IStudent
        {
        public Student()
        {
            this.Name = name;
            this.Address = address;
        }
        private string name = string.Empty;  //Field/variable name
        private string address = string.Empty;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int StudentId { get; set; }

        [ForeignKey("Grade")]
        public int GradeId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name  //Property
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [Required]
        [MaxLength(100)]
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public void CheckP()
        {
            Console.WriteLine("WithoutVirtual");
        }
    }
    public class SchoolContext: DbContext
    {
        [Required]
        public DbSet<Student>? Student { get; set; } //***Here object name should match with the class name
        public DbSet<Grade>? Grade { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = ConfigurationHelper.GetConnectionString("MSSQLDBConnection");
            optionsBuilder.UseSqlServer(conn);
  
        }

    }
}
