using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Linq;

namespace WpfApp1
{
    class XML
    {
        public XML()
        {
            string str = "Good Learning";
            string[] arr = new string[]{ "set", "Big set"};
            string[] arr1 = [ "set", "Big set" ];
            var words = str.Split(' ');
            int[] num = new int[] {5,4,6,8};
            var lists = from word in words
                       where word.Length > 0
                       select word;
            var lenlist = from word in words
                          group word.ToLower() by word.Length into obj
                          select new { Length = obj.Key, words = obj };
            foreach ( var lst in lenlist)
            {
                Console.WriteLine("Letter count: "+lst.Length);
                foreach (var word in lst.words) {
                    Console.WriteLine(word);
                }
            }
            foreach (var lst in lists)
            {
            }
            var xml = new XElement("Root",
    from lst in lenlist
    let tot = string.Join(",", num)
    /*Below is a LINQ to construct XML */
    select new XElement("WordsParsing",
           new XElement("Lettercount", lst.Length),
           new XElement("Total", tot),
           new XElement("Words", from ls in lst.words                                 
                                 group ls.ToLower() by ls.Length into word
                                 select new XElement("No."+ word.Key.ToString(), word))
           ));
            var xml1 = new XElement("Root",
                     lenlist.Select((lst, index) => new XElement("WordsParsing",
                    new XElement("Lettercount", lst.Length),
                    new XElement("Words", lst.words.Select((lst, index) => new XElement("No." + (index+1).ToString(), lst))))));
            //FileHandle filewrite = new FileHandle();
            //filewrite.FileWrite(Encoding.Default.GetBytes(xml.outer),"StringDataXML.txt");
            //XmlDocument doc = new XmlDocument();
            XDocument newXmlDoc = new XDocument(xml);
            // Save the XML document to a file
            newXmlDoc.Save("newxmlfile.xml");
            XDocument newXmlDoc1 = new XDocument(xml1);
            newXmlDoc1.Save("newtxtfilewithxml.txt");
        }
    }
}
