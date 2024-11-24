using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WpfApp1
{
    class FileHandle
    {
        public FileHandle() {
            string txt = "Hello";
            //4. Write text to the file
            File.WriteAllText("testFile.txt", txt);
            var readTxt = File.ReadAllText("testFile.txt");
            File.WriteAllText("SecondTestFile.txt", readTxt);
            txt += " text";
            File.AppendAllText("testFile.txt"," "+ txt);
            byte[] buffer = new byte[1024];
            buffer[0]= 70;
            File.WriteAllBytes("SecondTestFile.txt", buffer);
           

        }
        public void FileWrite(byte filedata = 70, string filename = "testFile.txt")
        {
            try
            {
                //2. Write byte to the file.
                /***This is a recommended approach***/
                FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate);
                fileStream.WriteByte(filedata);
                char ReadFile = (char)fileStream.ReadByte();
                //txtbox1.AppendText("\n");
                //txtbox1.AppendText(ReadFile.ToString());
                //txtbox1.AppendText("\n");
                fileStream.Close();

                //3. Write text to the file
                using (TextWriter writer = File.CreateText("testFile.txt"))
                {

                    writer.WriteLine("The first line with text writer");
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
    public partial class MainWindow
    {
        public void FileRead()
        {


            // var cmdArg = App.CommandLineArgs;
            try
            {
                //1. Write text to the file
                StreamWriter wrt = new StreamWriter("testFile.txt");
                 wrt.WriteLine("Write text to the file");
                wrt.Close();
                // Open the text file using a stream reader. 
                using (StreamReader sr = new StreamReader(cmdArg[0]))
                {
                    // Read the stream to a string, and write  
                    // the string to the text box                    
                    String line = sr.ReadToEnd();
                    txtbox1.AppendText("\n");
                    txtbox1.AppendText(line.ToString());
                    txtbox1.AppendText("\n");
                }

                /**** 2. Different thread concepts**/
                //Method going forward Without await
                Task.Run(() => delay());
                //3. Method will await to complete this
                Task.Run(async () =>
                await delay());

                // await Task.Run(()=>
                //{ 
                byte[]? bytesBuffer = null;
                    using (FileStream fs = new FileStream("testFile.txt", FileMode.Open, FileAccess.ReadWrite))
                    {
                        bytesBuffer = new byte[fs.Length];
                        fs.Read(bytesBuffer, 0, (int)fs.Length);
                    }
               // });
                //MessageBox.Show("Thread completed!!!");
               
                // Open the text file 
                using (TextReader txtR = File.OpenText("testFile.txt"))
                {

                    String data =  txtR.ReadToEnd();
                }
                

            }
            catch (Exception e)
            {
                txtbox1.AppendText("The file could not be read:");
                txtbox1.AppendText("\n");
                txtbox1.AppendText(e.Message);
            }
        }
      
        public async Task<int> delay()
        {
            await Task.Delay(100);
            //MessageBox.Show("Thread Delay!!!");
            Math.Sqrt(2);
            return 5;
        }
    }
}
