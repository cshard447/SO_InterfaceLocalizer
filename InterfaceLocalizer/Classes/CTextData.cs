using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InterfaceLocalizer.Classes
{
    public class CTextData
    {
        public string phrase;
        public string engPhrase;
        public string filename;
        public Stack<string> tags;

        public CTextData()
        {         
        }
        public CTextData(string _phrase, string _eng, string _filename, Stack<string> _tags)
        {
            phrase = _phrase;
            filename = _filename;
            tags = new Stack<string>();
            tags = _tags;
            engPhrase = _eng;
        }
    }

    public class CDataManager
    {
        private List<CTextData> texts = new List<CTextData>();
        

        public CDataManager()
        { 
        }

        public List<CTextData> getTexts()
        {
            return texts;
        }

        public void clearAllData()
        {
            texts.Clear();
        }

        public void addFileToManager(string filename)
        {   
            string phrase = "";
            string eng = "";
            Stack<string> tags = new Stack<string>();

            string rusPath = Properties.Settings.Default.PathToFiles + "\\Russian\\" + filename;
            string engPath = Properties.Settings.Default.PathToFiles + "\\English\\" + filename;
            XmlTextReader reader = new XmlTextReader (rusPath);
            XDocument engDoc = new XDocument();
            engDoc = XDocument.Load(engPath);
            
            while (reader.Read())  
            {
                switch (reader.NodeType)  
                {
                    case XmlNodeType.Element: // Узел является элементом.
                        tags.Push(reader.Name);
                        break;
                    case XmlNodeType.Text: // Вывести текст в каждом элементе.
                        phrase = reader.Value.Trim();
                        break;
                    case XmlNodeType.EndElement: // Вывести конец элемента.
                        if (phrase != "")
                        {
                            eng = getValueFromXml(engDoc, tags);
                            Stack<string> copy = new Stack<string>(tags.ToArray());                            
                            texts.Add(new CTextData(phrase, eng, filename, copy));
                            phrase = "";
                            eng = "";
                        }
                        tags.Pop();
                        break;
                }
            }
        }

        public string getValueFromXml(XDocument doc, Stack<string> tags)
        {
            string result = "";
            //Stack<string> ntags = invertStack(copy);            
            Stack<string> ntags = new Stack<string>(tags);

            try
            {
                if (ntags.Count == 1)
                    result = doc.Element(ntags.Pop()).Value.ToString();
                else if (ntags.Count == 2)
                    result = doc.Element(ntags.Pop()).Element(ntags.Pop()).Value.ToString();
                else if (ntags.Count == 3)
                    result = doc.Element(ntags.Pop()).Element(ntags.Pop()).Element(ntags.Pop()).Value.ToString();
            }
            catch 
            {
                result = "<NO DATA>";
            }
            result = result.Trim();
            return result;        
        }

        public void saveDataToFile()
        {
            string engPath = Properties.Settings.Default.PathToFiles + "\\EnglishTest\\";
            foreach (string file in CFileList.checkedFiles)
            {
                XDocument doc = new XDocument();                
                doc = XDocument.Load(engPath + file);

                
                IEnumerable<XElement> del = doc.Root.Descendants().ToList();
                del.Remove();
                doc.Save(file);
                

                foreach (CTextData text in texts)
                {
                    if (text.filename != file)
                        continue;
                    /*
                    IEnumerable<XElement> find = doc.Element(section).Descendants("person").Where(
                                t => t.Element("personId").Value == person.getID().ToString());
                    foreach (XElement elem in find)
                        elem.Remove();
                    */
                    Stack<string> copy = new Stack<string>(text.tags);
                    copy = CFileList.invertStack(copy);

                    XElement element = new XElement("test");                                        
                    /*
                    if (copy.Count == 1)
                        element = new XElement(copy.Pop(), text.engPhrase);

                    else if (copy.Count == 2)
                        element = new XElement(copy.Pop(),
                                        new XElement(copy.Pop(), text.engPhrase));
                    else if (copy.Count == 3)
                        element = new XElement(copy.Pop(),
                                        new XElement(copy.Pop(), 
                                            new XElement(copy.Pop(), text.engPhrase)));
                    */

                    //if (copy.Count == 1)
                        //element = new XElement(copy.Pop(), text.engPhrase);
                    //if (item.Element("Reward").Descendants().Any(itm2 => itm2.Name == "Probability"))
                    string root = copy.Pop();
                    string chapter = copy.Pop();
                    string item = copy.Pop();
                    string value = text.engPhrase;

                    if (doc.Root.Descendants().Any(tag1 => tag1.Name == chapter))
                    {
                        if (doc.Root.Element(chapter).Descendants().Any(tag2 => tag2.Name == item))
                            doc.Root.Element(chapter).Element(item).Value = value;
                        else
                        {
                            XElement el = new XElement(item, value);
                            //doc.Root.Add(el);
                            doc.Root.Element(chapter).Add(el);
                        }
                    }
                    else
                    {
                        XElement el = new XElement(chapter, new XElement(item, value));
                        doc.Root.Add(el);
                        
                        /*
                        if (copy.Count == 1)
                        {
                            element = new XElement(copy.Pop(), text.engPhrase);
                            //element.Name = copy.Pop();
                            //element.Value = text.engPhrase;
                        }
                        else if (copy.Count == 2)
                        {
                            element = new XElement(new XElement(copy.Pop(),
                                                new XElement(copy.Pop(), text.engPhrase)));
                        }
                        doc.Root.Add(element);
                         */ 
                    }
                    
                    
                    //int c = doc.Root.Element("").Elements().Count;
                    /*
                    try
                    {
                        if (copy.Count == 1)
                            doc.Element(copy.Pop()).Value = text.engPhrase;
                        else if (copy.Count == 2)
                            doc.Element(copy.Pop()).Element(copy.Pop()).Value = text.engPhrase;
                        else if (copy.Count == 3)
                            doc.Element(copy.Pop()).Element(copy.Pop()).Element(copy.Pop()).Value = text.engPhrase;
                    }
                    catch {
                        doc.AddAfterSelf(element);
                        //doc.
                    } 
                     */ 
                }

                doc.Save(engPath + file);            
            }
        }
    
    }
}
