using NetConceptWithWpfApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            //MainWindow obj = new MainWindow();
            //obj.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            //obj.Topmost = true;
            if (!obj.IsVisible) obj.Show();
            //else obj.Activate();
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SQLRepository sqlIntraction = new SQLRepository();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //Implicit and explicit interfaces
            clsMainInterface clsMain = new clsMainInterface();
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //Threads
            Thread clsMain = new Thread();
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            //Classes
            ClassesVariousMethods clsMain = new ClassesVariousMethods("John");
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            //Array
            Arrays clsMain = new Arrays();
        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            //XML
            XML clsMain = new XML();
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            //Delegates
            Delegate clsMain = new Delegate();
        }
        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            //File Handle
            FileHandle clsMain = new FileHandle();
        }
        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            MSMQMessageReceiver msms = new MSMQMessageReceiver();
        }
        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            LINQ linq = new LINQ();
        }
        
    }

    /// <summary>
    /// With help of partial class we can split and define a class with the same name
    /// here MainWindow implemented in another file as well with the help of "partial" keyword
    /// </summary>
    public partial class MainWindow : Window
    {
        public void LoginsCheck()
        {
            Console.WriteLine("test");
        }
    }
    }
