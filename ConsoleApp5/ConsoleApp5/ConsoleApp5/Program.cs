using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Task2();
        }
        static void Task1()
        {
            string text;
            //using (StreamReader reader = File.OpenText("Textovochka.txt"))
            //{
            //    text = reader.ReadToEnd();
            //}
            //char[] space = new char[1];
            //space[0] = '\n';
            //string[] lines = text.Split(space);

            var lines = File.ReadAllLines("Textovochka.txt");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument doc = XDocument.Load("file.xml");
            XDocument doc2 = new XDocument();
            IEnumerable<XElement> elem = doc.Descendants().Select(x => x);
            doc2 = new XDocument(
                new XDeclaration("1.0", "WINDOWS-1251", null),
                new XElement("Root",  lines.Select((l,i)=> new XElement("Line"+(i+1), l)))
                    );
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    XElement newel = new XElement( + (i + 1), lines[i]);
            //    doc2.Root.Add(newel);
            //}
            //Console.WriteLine(doc2);
            doc2.Save("Sfile.xml");
            //doc.Root.Elements();
            //XmlDocument d = new XmlDocument();
            //d.AppendChild(d.CreateXmlDeclaration("1.0", "windows-1251", null));
            //XmlElement bookDescriptions = d.CreateElement("описания-книг");
            //d.AppendChild(bookDescriptions);
            //XmlElement titleInfo = d.CreateElement("title-info");
            //XmlElement genre = d.CreateElement("genre");
            //XmlAttribute attr = d.CreateAttribute("match");
            //attr.InnerText = "90";
            //genre.Attributes.Append(attr);
            //genre.InnerText = "sf_fantasy";
            //titleInfo.AppendChild(genre);
            //XmlElement child = d.CreateElement("author");
            //XmlElement name = d.CreateElement("first-name");
            //name.InnerText = "Джон";
            //child.AppendChild(name);
            //name = d.CreateElement("middle-name");
            //name.InnerText = "Рональд Руэл";
            //child.AppendChild(name);
            //name = d.CreateElement("last-name");
            //name.InnerText = "Толкин";
            //child.AppendChild(name);
            //titleInfo.AppendChild(child);
            //child = d.CreateElement("book-title");
            //child.InnerText = "Возвращение Короля";
            //titleInfo.AppendChild(child);
            //child = d.CreateElement("lang");
            //child.InnerText = "ru";
            //titleInfo.AppendChild(child);
            //child = d.CreateElement("sequence");
            //attr = d.CreateAttribute("name");
            //attr.InnerText = "Властелин Колец";
            //child.Attributes.Append(attr);
            //attr = d.CreateAttribute("number");
            //attr.InnerText = "3";
            //child.Attributes.Append(attr);
            //titleInfo.AppendChild(child);
            //bookDescriptions.AppendChild(titleInfo);
        }
        static void Task2()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument doc = XDocument.Load("file.xml");
            XDocument doc2 = new XDocument(doc);
            IEnumerable<XElement> elem = (IEnumerable<XElement>)doc.Root.Elements().Select(x => x);
            var req=elem.Select(x=>x.Name.LocalName).Distinct().Select(x => new XElement(x+(elem.Where(y=>y.Name==x).Count()).ToString())).OrderBy(x=>x);
            //foreach (var el in req)
            //    doc2.Root.Add(el);
            doc2.Save("Sfile.xml");
        }
        static void Task3(string s)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument doc = XDocument.Load("file.xml");
            XDocument doc2 = new XDocument(doc);
            List<XElement> list = new List<XElement>();
            doc2.Root.Descendants(s).Where(x => x.Name.LocalName == s).Remove();
            doc2.Save("Sfile.xml");
        }
        static void Task4(string S1, string s2)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument doc = XDocument.Load("file.xml");
            var req = doc.Root.Elements().Elements().Where(x => x.Name.LocalName == S1);
            foreach (var elem in req)
                elem.AddBeforeSelf(new XElement(s2, new XElement(elem.Elements().FirstOrDefault()), new XAttribute(elem.LastAttribute)));
            doc.Save("Sfile.xml");
        }
        static void Task5()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument doc = XDocument.Load("faylik.xml");
            XDocument doc2 = new XDocument(doc);
            var req = doc2.Root.Elements();
            foreach (var elem in req)
            {
                int sum = (int)elem.Descendants().Attributes().Sum(x => double.Parse(x.Value));
                if (elem.HasElements)
                    elem.AddFirst(new XElement("sum", sum));
            }
            doc2.Save("Sfile.xml");
        }
        static void Task6()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument doc = XDocument.Load("faylidates.xml");
            XDocument doc2 = new XDocument(doc);
            var req = doc2.Root.Elements();
                int year, month, day;
            foreach (var elem in req)
            {
                if (elem.Attributes("year").Count() == 1)
                {
                    year = int.Parse(elem.Attribute("year").Value);
                    elem.Attribute("year").Remove();
                }
                else
                    year = 2000;
                if (elem.Attributes("month").Count() == 1)
                {
                    month = int.Parse(elem.Attribute("month").Value);
                    elem.Attribute("month").Remove();
                }
                else
                    month = 1;
                if (elem.Attributes("day").Count() == 1)
                {
                    day = int.Parse(elem.Attribute("day").Value);
                    elem.Attribute("day").Remove();
                }
                else
                    day = 10;
                elem.AddFirst(new XElement("date", new XAttribute("year", year), new XAttribute("month", month), new XAttribute("day", day)));
            }
            doc2.Save("Sfile.xml");
        }
        static void Task7()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument doc = XDocument.Load("dates.xml");
            XDocument doc2 = new XDocument(doc);
            var req = doc2.Root.Elements();
            foreach (var elem in req)
            {
                elem.Name = "id" + elem.Attribute("id").Value;
                elem.SetAttributeValue("date", new DateTime(int.Parse(elem.Attribute("year").Value), int.Parse(elem.Attribute("month").Value), 1));
                elem.Attribute("year").Remove();
                elem.Attribute("id").Remove();
                elem.Attribute("month").Remove();
                string Value = "";
                for (int i = 0; i < elem.Value.Length; i++)
                {
                    int num;
                    if (int.TryParse(elem.Value.ToString()[i].ToString(), out num))
                        Value += elem.Value[i];
                }
                elem.Value = Value;
            }
            doc2.Root.ReplaceNodes(doc2.Root.Elements()
        .OrderBy(x => x.Name.ToString())
        .ThenBy(x => (DateTime)x.Attribute("date")));
            doc2.Save("Sfile.xml");
        }
        static void Task8()
        {
            List<company> Costs = new List<company>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XDocument doc = XDocument.Load("prices.xml");
            var req = doc.Root.Elements();
            foreach (var elem in req)
            {
                if (Costs.Select(x => x).Where(x => x.name == elem.Name.LocalName).Count() == 0)
                    Costs.Add(new company() { name = elem.Name.LocalName.ToString(), prices=new List<Price>()});
                    var req2 = elem.Elements();
                foreach (var elem2 in req2)
                    Costs.First(x => x.name == elem.Name.LocalName).prices.Add(new Price() { Value = elem2.Value,street=elem2.Attribute("street").Value,brand=elem2.Attribute("brand").Value});
            }
            List<PriceC>prices=new List<PriceC>();
            foreach (var elem in Costs)
            {
                for(int i=0;i< elem.prices.Count;i++)
                {
                    PriceC prise = new PriceC();
                    prise.brand = elem.prices[i].brand;
                    prise.name = elem.name;
                    prise.street = elem.prices[i].street;
                    prise.Value = elem.prices[i].Value;
                    prices.Add(prise);
                }
            }
            XDocument doc2 = new XDocument();
            doc2 = new XDocument(
    new XDeclaration("1.0", "WINDOWS-1251", null),
    new XElement("Root")
        );
            for (int i = 0; i < prices.Count; i++)
            {
                if (doc2.Root.Element(prices[i].street) != null)
                {
                    if (doc2.Root.Element(prices[i].street).Element("b" + prices[i].brand) != null)
                        doc2.Root.Element(prices[i].street).Element("b" + prices[i].brand).Add(new XElement("min-price", new XAttribute("company", prices[i].name)) { Value = prices[i].Value });
                    else
                    {
                        doc2.Root.Element(prices[i].street).Add(new XElement("b" + prices[i].brand));
                        doc2.Root.Element(prices[i].street).Element("b" + prices[i].brand).Add(new XElement("min-price", new XAttribute("company", prices[i].name)) { Value = prices[i].Value });
                    }
                }
                else
                {
                    doc2.Root.Add(new XElement(prices[i].street));
                    doc2.Root.Element(prices[i].street).Add(new XElement("b" + prices[i].brand));
                    doc2.Root.Element(prices[i].street).Element("b" + prices[i].brand).Add(new XElement("min-price", new XAttribute("company", prices[i].name)) { Value = prices[i].Value });
                }
            }
            doc2.Root.ReplaceNodes(doc2.Root.Elements()
.OrderBy(x => x.Name.LocalName));
            var reqest = doc2.Root.Elements();
            foreach (var elem in reqest)
            {
                elem.Elements()
.OrderBy(x => x.Name.LocalName);
            }
            foreach (var elem in reqest)
            {
                int min=elem.Elements().Min(x=>int.Parse(x.Value));
                foreach(var element in elem.Elements())
                {
                    if (int.Parse(element.Value) > min)
                        element.Remove();
                }
            }
            doc2.Save("Sfile.xml");
        }
    }
    public class PriceC
    {
        public string name { get; set; }
        public string street { get; set; }
        public string brand { get; set; }
        public string Value { get; set; }
    }
    public class company
    {
        public string name { get; set; }
        public List<Price> prices;
    }
    public class Price
    {
        public string street { get; set; }
        public string brand { get; set; }
        public string Value { get; set; }
    }
}

