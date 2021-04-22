using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

namespace lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu(4, 1024, 720, "pink", "Text", "black");
           // Button button = new Button(100, 50, "black", "button", "gold");

            //BINARY
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using(FileStream fileStream = new FileStream("binary.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, menu);
            }

            using (FileStream fileStream = new FileStream("binary.dat", FileMode.OpenOrCreate))
            {
                Menu newMenu = (Menu)binaryFormatter.Deserialize(fileStream);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine(newMenu.ToString());
            }

            //SOAP
            Menu bmenu = new Menu();
            SoapFormatter soapFormatter = new SoapFormatter();
            using(FileStream fileStream = new FileStream("soap.dat", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fileStream, menu.Button);
            }
            using (FileStream fileStream = new FileStream("soap.dat", FileMode.OpenOrCreate))
            {
                bmenu.Button = (Button)soapFormatter.Deserialize(fileStream);
            }
            bmenu.Button.info();


            //XML
            Menu xmlMenu = new Menu(2, 480, 360, "green", "XML", "white");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Menu));
            using (FileStream fileStream = new FileStream("xml.dat", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, xmlMenu);
            }
            using (FileStream fileStream = new FileStream("xml.dat", FileMode.OpenOrCreate))
            {
                Menu newXmlMenu = xmlSerializer.Deserialize(fileStream) as Menu;
                Console.WriteLine(newXmlMenu.ToString());
            }

            //JSON
            Programmer programmer = new Programmer("Alex", 23, new Company("Bread"));
            Programmer programmer2 = new Programmer("Jon", 44, new Company("Lays"));
            Programmer[] programmers = new Programmer[] { programmer, programmer2 };
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Programmer[]));
            using (FileStream fileStream = new FileStream("JSON.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fileStream, programmers);
            }
            using (FileStream fileStream = new FileStream("JSON.json", FileMode.OpenOrCreate))
            {
                Programmer[] newProgrammers = (Programmer[])jsonSerializer.ReadObject(fileStream);
            }


            //xPath
            using(FileStream fileStream = new FileStream("xml.dat", FileMode.OpenOrCreate))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(fileStream);
                XmlElement xRoot = xDoc.DocumentElement;
                XmlNodeList childnodes = xRoot.SelectNodes("//Menu/button/BackColor");
                foreach (XmlNode n in childnodes)
                {
                    Console.WriteLine(n.InnerText);
                }
            }


            //linq
            using (FileStream fileStream = new FileStream("xml.dat", FileMode.OpenOrCreate))
            {
                XDocument xDoc = XDocument.Load(fileStream);
                var items = from xe in xDoc.Element("Menu").Elements("button").Elements()
                            select xe.Name;
                foreach (var i in items)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
