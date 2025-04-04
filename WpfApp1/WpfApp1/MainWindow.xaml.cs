using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlConnector;
namespace WpfApp1
{
      /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * use the command-line tool "gacutil" to install your assembly into the GAC- (Global Assembly Cache) 
         * To add an assembly to the GAC, you can use the gacutil tool provided with the .NET Framework SDK or cmd:

            gacutil -i MyAssembly.dll
         */
        string[] cmdArg;
        private readonly SchoolContext _context =   new SchoolContext();
        private CollectionViewSource categoryViewSource;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // to get up and running
           _context.Database.EnsureCreated();
        }
        public  MainWindow()
        {
            InitializeComponent();
            cmdArg = App.CommandLineArgs;

            //Boxing and unboxing 
            int i = 15;
            object obj = i;

            //Tuples
            //Combination of two data types
            (int, double) amount = (5, 2.5);
            Console.WriteLine(amount.ToString());

            //(Custom variable) .NET keyword can be used as a local variable with @ symbol 
            string @for = "test";

            //below is not possible in C#
            //string #for="";

            //string interpolation
            string Text1 = $"Hello {amount}!";
            // Normal string with escaping
            string path1 = "C:\\Users\\John\\Documents\\file.txt";
            // Verbatim string
            string path2 = @"C:\Users\John\Documents\file.txt";

            //SQL intraction along with test MariaDB connection
            SQLIntraction objSQLIntraction = new SQLIntraction();

            //To explore EntityFrame Work
            /* Start_of EF */
            // load the entities into EF Core
            categoryViewSource =
              (CollectionViewSource)FindResource(nameof(categoryViewSource));

            SchoolContext schoolContext = new SchoolContext();
            Student newStudent = new Student() { Name = "Albert" };
            IStudent sStudent = new Student() { Name = "Albert" };
            Student newoblderived = new Student() { Name="FirstValue",Address="Westmoreland road"};
            /*  Below "DataContext" line of code is used to assign class binding to the "textbox2" */
            this.DataContext = new Student() { Name = "Name", Address = "Westmoreland road" };
            List<object> listobj = new List<object>();
            listobj.Add("String added to list");
            listobj.Add(i); //Here CLR automatically converts/"boxes" the int value type to object/ref type

            foreach (var item in listobj)
            {
                listBox1.Items.Add(item); //Here CLR automatically "unboxes" the object type to int value type

            }
            listBox1.Items.Clear();
            foreach (var sitem in _context.Grade)
            {
                Console.WriteLine($"First Name: {sitem.GradeId}");
                listBox1.Items.Add(sitem.GradeId);
            }
            listBox1.SelectedItem = listBox1.Items[0];
            /*End_of EF */

            BaseA baseobj = new BaseA();
            BaseA baseobjderived = new DerivedA();
            DerivedA objderived = new DerivedA();
            baseobj.login();
            objderived.login();


            // "Generics method"
            // a class/function with 'T' to use type safe and for efficient coding */
            objderived.Passcheck("", "");
            objderived.Passcheck(2, 3);
            //Below throws compile time error since we have declared T as string. It won't accept int
            //newoblderived.Passcheck<string>("", 2);
            objderived.Passcheck<string>("", "");

            //Action and Func methods
            Action a = () => Console.Write("a");
            Action b = () => Console.Write("b");
            Action c = () => Console.Write("b");
            var ab = a + b;
            ab();  // output: ab

            //To explore Thread concepts
            Thread objClsWithThread = new Thread();


            //To explore xml creation with LINQ
            XML xmlcreation = new XML();

            //Various array declarations
            Arrays arrayDeclarations = new Arrays();

            //To explore various delegate methods
            Delegate clsWithDelegate = new Delegate();


            /* The below will not work bcoz we created this obj from the BaseA class 
             * in which does not have the property "Name"*/
            //oblderived.Name = "test";
            newoblderived.Name = @for;


            txtbox1.Text = newoblderived.Name;



            //To explore different classes and their access methods 
            /* the below line of code is not possible we cannot create instance 
             * for the static class instead we can access directly*/
            //StaticClass objStat = new StaticClass();
            StaticClass.StatMethod();
            CannotInheritclass objCannotInheritclass = new CannotInheritclass();
            objCannotInheritclass.SealedMethodlogin();
            var lvl = ((int)Level.VeryHigh);
            Console.WriteLine(lvl.ToString());
            listBox1.Items.Add(lvl);
            FileHandle objFileHandle = new FileHandle();
            FileRead();



            /*Using "out" keyword in the method calling
            Without declaring the variable outside it is declared with in the method using "out" keyword
             */
            LoginCheck(out int Radius, out int Area);

        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox1.Background = new SolidColorBrush(Colors.LightPink);
            listBox1.Foreground = new SolidColorBrush(Colors.Blue);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        public int PasswordCheck()
        {
            return 0;
        }
        private void btn_onClick(object sender, RoutedEventArgs e)
        {
            var backgroundBrush = txtbox1.Background;
            if (backgroundBrush is SolidColorBrush solidColorBrush)
            {
                // Get the Color object from the SolidColorBrush
                Color backgroundColor = solidColorBrush.Color;

                // Show the color in a message box
                //.Show($"Background Color: {backgroundColor}");
                if (backgroundColor == Colors.LightPink)
                    txtbox1.Background = new SolidColorBrush(Colors.GreenYellow);
                else
                    txtbox1.Background = new SolidColorBrush(Colors.LightPink);
            }
            InsertData();
            UpdateData();
            DeleteData();
        }
        public int LoginCheck(out int Radius,out int Area)
        {
            Radius = 10;

            //To explore different casting and conversion methods
            Area=(int)Math.PI *  (int)Math.Pow(Radius, 2);
            int circumference = Convert.ToInt32(2 * Math.PI * Radius);

            return circumference;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Insert data on EF
        /// </summary>
        public void InsertData()
        {
            using (var context = new SchoolContext())
            {
                //create entity objects
                var std1 = new Student() { GradeId = (Int32)listBox1.SelectedItem , Name = txtbox1.Text, Address = txtbox2.Text };

                //add entitiy to the context
                context.Student.Add(std1);

                //save data to the database tables
                context.SaveChanges();

                //retrieve all the students from the database
                foreach (var s in context.Student)
                {
                    Console.WriteLine($"First Name: {s.Name}");
                }
                System.Windows.Forms.MessageBox.Show($" {std1.Name} information saved!!");
            }
        }
        /// <summary>
        /// Uodate data on EF
        /// </summary>
        public void UpdateData()
        {
            using (var context = new SchoolContext())
            {
                //Using SQL query
                var students = context.Student
                    .FromSql($"Select * from Student where Name = '{txtbox1.Text}'")
                    .ToList();
                //The examples above will execute the following SQL query to the SQL Server database:
                //exec sp_executesql N'Select * from Student where Name = ''@p0''',N'@p0 nvarchar(4000)',@p0 = N'name'
                //go
                var studts = context.Student
                    .FromSql($"Select * from Student where Name = '{txtbox1.Text}'")
                    .OrderBy(s => s.StudentId);
                // entity objects
                var student = context.Student.Where(x => x.Name == txtbox1.Text).First();  //.OrderBy(x=>x).LastOrDefault();
                string oldname=student.Name;
                // Modify the entitiy to the context
                student.Name = txtbox1.Text;

                //save data to the database tables
                context.SaveChanges();

          
                System.Windows.Forms.MessageBox.Show($"Information modified from {oldname} to {student.Name}!!");
            }
        }
        /// <summary>
        /// Delete data from EF
        /// </summary>
        public void DeleteData()
        {
            using (var context = new SchoolContext())
            {
                // entity objects
                var student = context.Student.OrderBy(x=>x).Last();
                string oldname=student.Name;
                // Modify the entitiy to the context
                context.Student.Remove( student);

                //save data to the database tables
                context.SaveChanges();
                System.Windows.Forms.MessageBox.Show($"{oldname} information deleted!!");
            }
        }
        

    }
}