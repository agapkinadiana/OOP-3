using System;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(5, 9);
            Point point_2 = new Point(7, 23);
            Point[] points = { point, point_2 };

            WriteLine("_________Бинарная сериализация_________");

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("point.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, point);
                WriteLine("Объект сериализован");

                formatter.Serialize(fs, points);
                WriteLine("Объект(массив) сериализован");
            }

            using (FileStream fs = new FileStream("point.dat", FileMode.OpenOrCreate))
            {
                Point newPoint = (Point)formatter.Deserialize(fs);
                WriteLine("Объект десериализован");
                WriteLine($"X: {newPoint.X}, Y: {newPoint.Y}");

                Point[] newPoint2 = (Point[])formatter.Deserialize(fs);
                WriteLine("Объект(массив) десериализован");
                foreach (Point p in newPoint2)
                {
                    WriteLine($"X: {p.X}, Y: {p.Y}");
                }
            }


            WriteLine("_________Сериализация в XML_________");

            XmlSerializer serializer = new XmlSerializer(typeof(Point));
            XmlSerializer serializer1 = new XmlSerializer(typeof(Point[]));

            using (FileStream fs = new FileStream("point2.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, point);
                WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("point2.xml", FileMode.OpenOrCreate))
            {
                Point newPoint = (Point)serializer.Deserialize(fs);

                WriteLine("Объект десериализован");
                WriteLine($"X: {newPoint.X}, Y: {newPoint.Y}");
            }

            using (FileStream fs = new FileStream("point3.xml", FileMode.OpenOrCreate))
            {
                serializer1.Serialize(fs, points);
                WriteLine("Объект(массив) сериализован");
            }

            using (FileStream fs = new FileStream("point3.xml", FileMode.OpenOrCreate))
            {
                Point[] newPoint2 = (Point[])serializer1.Deserialize(fs);

                WriteLine("Объект(массив) десериализован");
                foreach (Point p in newPoint2)
                {
                    WriteLine($"X: {p.X}, Y: {p.Y}");
                }
            }

            WriteLine("_________Сериализация в JSON_________");

            Person person1 = new Person("Tom", 29);
            Person person2 = new Person("Will", 25);
            Person[] people = { person1, person2 };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, people);
            }

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])jsonFormatter.ReadObject(fs);

                foreach (Person p in newpeople)
                {
                    WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
                }
            }

            WriteLine("_________Linq to XML_________");
            //создание документа
            XDocument xdoc = new XDocument(new XElement("users",
                                                        new XElement("user",
                                                                     new XAttribute("name", "Bill Gates"),
                                                                     new XElement("company", "Microsoft"),
                                                                     new XElement("age", "48")),
                                                        new XElement("user",
                                                                     new XAttribute("name", "Larry Page"),
                                                                     new XElement("company", "Google"),
                                                                     new XElement("price", "42"))));
            xdoc.Save("users.xml");

            IEnumerable<XElement> elements = xdoc.Descendants("user"); //получаем отдельный эл-т

            foreach (XElement e in elements)
                WriteLine("Элемент {0} : значение = {1}", e.Name, e.Value);

            IEnumerable<XElement> elements2 = xdoc
                .Descendants("user")
                .Where(e => ((string)e.Element("company")) == "Microsoft");

            foreach (XElement e in elements2)
                WriteLine("Элемент {0} : значение = {1}", e.Name, e.Value);

            WriteLine("_________XPath_________");
            XmlDocument xml = new XmlDocument();
            xml.Load("users.xml");

            //только компании, все узлы корневого элемента
            XmlElement xRoot = xml.DocumentElement;
            XmlNodeList list = xRoot.SelectNodes("//user/company");
            foreach (XmlNode nodes in list)
            {
                WriteLine(nodes.InnerText);
            }

            //узел, у которого вложенный элемент "company" имеет значение "Microsoft"
            XmlNode childnode = xRoot.SelectSingleNode("user[company='Microsoft']");
            if (childnode != null)
                WriteLine(childnode.OuterXml);
        }
    }
}