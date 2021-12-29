using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace Lr14
{
    class Program
    {
        static void Main(string[] args)
        {
            Cookie cookie1 = new Cookie("Мария", 5, false);
            Candy candy1 = new Candy("Красная шапочка", 10, "карамель");                       //объект для сериализации

            BinaryFormatter binFormatter = new BinaryFormatter();                              //создаём объект BinaryFormatter

            using (var file = new FileStream("candy.bin", FileMode.OpenOrCreate))              // получаем поток, куда будем записывать сериализованный объект
            {
                binFormatter.Serialize(file, candy1);
                Console.WriteLine("Объект сериализован");
            }

            using (var file = new FileStream("candy.bin", FileMode.OpenOrCreate))              //десериализация из файла candy.dat
            {
                Candy newCandy1 = (Candy)binFormatter.Deserialize(file);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Название: {newCandy1.Name} \nЦена: {newCandy1.Price} \nНачинка: {newCandy1.Filling}");
            }

            Console.ReadLine();

            var soapFormatter = new SoapFormatter();

            using (var file = new FileStream("candy.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(file, candy1);
                Console.WriteLine("Объект сериализован");
            }

            using (var file = new FileStream("candy.soap", FileMode.OpenOrCreate))
            {
                Candy newCandy1 = (Candy)soapFormatter.Deserialize(file);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Название: {newCandy1.Name} \nЦена: {newCandy1.Price} \nНачинка: {newCandy1.Filling}");
            }

            Console.ReadLine();

            var xmlFormatter = new XmlSerializer(typeof(Candy));        //необходимо указать тип данных, в который мы будем сериализовывать

            using (var file = new FileStream("candy.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, candy1);
                Console.WriteLine("Объект сериализован");
            }

            using (var file = new FileStream("candy.xml", FileMode.OpenOrCreate))
            {
                Candy newCandy1 = (Candy)xmlFormatter.Deserialize(file);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Название: {newCandy1.Name} \nЦена: {newCandy1.Price} \nНачинка: {newCandy1.Filling}");
            }

            Console.ReadLine();

            var jsonFormatter = new DataContractJsonSerializer(typeof(Cookie));

            using (var file = new FileStream("cookie.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, cookie1);
                Console.WriteLine("Объект сериализован");
            }

            using (var file = new FileStream("cookie.json", FileMode.OpenOrCreate))
            {
                Cookie newCookie1 = (Cookie)jsonFormatter.ReadObject(file);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Название: {newCookie1.Name} \nЦена: {newCookie1.Price} \nНаличие орехов: {newCookie1.IsNuts}");
            }

            Console.ReadLine();

            Cookie myCookie1 = new Cookie("Мария", 10, false);
            Cookie myCookie2 = new Cookie("Эсмиральда", 9, true);
            Cookie myCookie3 = new Cookie("Постное", 3, false);

            List<Cookie> myCookieList = new List<Cookie>(3);
            myCookieList.Add(myCookie1);
            myCookieList.Add(myCookie2);
            myCookieList.Add(myCookie3);

            var jsonListFormatter = new DataContractJsonSerializer(typeof(List<Cookie>));

            using (var file = new FileStream("cookieList.json", FileMode.OpenOrCreate))
            {
                jsonListFormatter.WriteObject(file, myCookieList);
                Console.WriteLine("Коллекция сериализована");
            }

            using (var file = new FileStream("cookieList.json", FileMode.OpenOrCreate))
            {
                List<Cookie> newCookieList = jsonListFormatter.ReadObject(file) as List<Cookie>;
                if (newCookieList != null)
                {
                    foreach (var cookie in newCookieList)
                    {
                        Console.WriteLine($"Название: {cookie.Name} \nЦена: {cookie.Price} \nНаличие орехов: {cookie.IsNuts}");
                    }
                    Console.WriteLine("Коллекция десериализована");
                }
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\2K\ООП\Lr14\Lr14\bin\Debug\candy.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            
            XmlNode childnode = xRoot.SelectSingleNode("user[Name='Красная шапочка']");         //Выберем узел, у которого вложенный элемент "Name" имеет значение "Красная шапочка":
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);
            else
                Console.WriteLine($"\nНайден узел, у которого вложенный элемент 'Name' имеет значение 'Красная шапочка'!\n");

            XmlNodeList childnodes = xRoot.SelectNodes("//Candy/Filling");                      //Для этого надо Осуществляем выборку вниз по иерархии элементов для получения начинок
            foreach (XmlNode n in childnodes)
                Console.WriteLine($"Начинка:{n.InnerText}");

            Console.ReadLine();
            XDocument xdoc = new XDocument(new XElement("children",
                new XElement("child",
                new XAttribute("lastname", "Максимов"),
                new XElement("firstname", "Миша"),
                new XElement("old", "7")),
                new XElement("child",
                new XAttribute("lastname", "Максимова"),
                new XElement("firstname", "Алиса"),
                new XElement("old", "5")),
                new XElement("child",
                new XAttribute("lastname", "Миронова"),
                new XElement("firstname", "Маша"),
                new XElement("old", "5"))));
            xdoc.Save("children.xml");

            XDocument xdoc1 = XDocument.Load("children.xml");
            foreach (XElement childElement in xdoc1.Element("children").Elements("child"))
            {
                XAttribute lastnameAttribute = childElement.Attribute("lastname");
                XElement firstnameElement = childElement.Element("firstname");
                XElement oldElement = childElement.Element("old");

                if (lastnameAttribute != null && firstnameElement != null && oldElement != null)
                {
                    Console.WriteLine($"Фамилия: {lastnameAttribute.Value}");
                    Console.WriteLine($"Имя: {firstnameElement.Value}");
                    Console.WriteLine($"Возраст: {oldElement.Value}");
                }
            }
            Console.ReadLine();

            XDocument xdoc2 = XDocument.Load("children.xml");
            var items1 = from xel in xdoc2.Element("children").Elements("child")
                        where xel.Element("firstname").Value == "Алиса"
                        select new Child
                        {
                            Lastname = xel.Attribute("lastname").Value,
                            Firstname = xel.Element("firstname").Value,
                            Old = xel.Element("old").Value
                        };
            foreach (var item in items1)
                Console.WriteLine($"{item.Firstname} {item.Lastname} ({item.Old} лет)");

            Console.ReadLine();

            XDocument xdoc3 = XDocument.Load("children.xml");
            var items2 = from xel in xdoc2.Element("children").Elements("child")
                         where xel.Element("old").Value == "5"
                         select new Child
                         {
                             Lastname = xel.Attribute("lastname").Value,
                             Firstname = xel.Element("firstname").Value,
                             Old = xel.Element("old").Value
                        };
            foreach (var item in items2)
                Console.WriteLine($"{item.Firstname} {item.Lastname} ({item.Old} лет)");

            var items3 = from xel in xdoc2.Element("children").Elements("child")
                         orderby xel
                         select new Child
                         {
                             Lastname = xel.Attribute("lastname").Value,
                             Firstname = xel.Element("firstname").Value,
                             Old = xel.Element("old").Value
                         };
            //foreach (var item in items3)
            //    Console.WriteLine($"{item.Firstname} {item.Lastname} ({item.Old} лет)");

            Console.ReadLine();
        }
    }
}
