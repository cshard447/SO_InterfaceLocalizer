using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;


namespace InterfaceLocalizer.Classes
{
    public class CXmlData : ITranslatable
    {
        private string phrase;
        private string engPhrase;
        private string filename;
        private Stack<string> tags;

        public CXmlData(string _phrase, string _eng, string _filename, Stack<string> _tags)
        {
            phrase = _phrase;
            filename = _filename;
            tags = new Stack<string>();
            tags = _tags;
            engPhrase = _eng;
        }

        public string getRusData()
        {
            return phrase;
        }

        public string getEngData()
        {
            return engPhrase;
        }

        public string getFilename()
        {
            return filename;
        }

        public string getTagsString()
        {
            Stack<string> copy = new Stack<string>(tags);
            copy = CFileList.invertStack(copy);
            StringBuilder temp = new StringBuilder("");
            while (copy.Count != 0)
                temp.Append( copy.Pop() + " -> " );
            return temp.ToString();
        }

        public void setRusData(string rusData)
        {
            phrase = rusData;
        }

        public void setEngData(string engData)
        {
            engPhrase = engData;
        }

        public Stack<string> getTags()
        {
            return tags;
        }
    }

    class CDataManager : IManager
    {
        private Dictionary<int, ITranslatable> xmlDict = new Dictionary<int, ITranslatable>();
        int id = 0;
        
        public CDataManager()
        {
            id = 0;
        }

        public Dictionary<int, ITranslatable> getFullDictionary()
        {
            return xmlDict;
        }

        public void clearAllData()
        {
            xmlDict.Clear();
            id = 0;
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
            bool gotten = false;
            
            while (reader.Read())  
            {
                switch (reader.NodeType)  
                {
                    case XmlNodeType.Element: // Узел является элементом.
                        tags.Push(reader.Name);
                        if (reader.IsEmptyElement)
                        {
                            eng = "";
                            Stack<string> copy = new Stack<string>(tags.ToArray());
                            //texts.Add(new CXmlData(phrase, eng, filename, copy));
                            xmlDict.Add(id++, new CXmlData(phrase, eng, filename, copy));
                            phrase = "";
                            eng = "";
                            tags.Pop();                            
                        }
                        break;
                    case XmlNodeType.Text: // Вывести текст в каждом элементе.
                        phrase = reader.Value.Trim();
                        gotten = true;
                        break;
                    case XmlNodeType.EndElement: // Вывести конец элемента.
                        //if (phrase != "")
                        if (gotten)
                        {
                            eng = getValueFromXml(engDoc, tags);
                            Stack<string> copy = new Stack<string>(tags.ToArray());                            
                            //texts.Add(new CXmlData(phrase, eng, filename, copy));
                            xmlDict.Add(id++, new CXmlData(phrase, eng, filename, copy));
                            gotten = false;
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

        public void updateDataFromGridView(RadGridView gridView)
        {
            for (int row = 0; row < gridView.RowCount; row++)
            {
                int id = int.Parse(gridView.Rows[row].Cells["columnID"].Value.ToString());
                string filename = gridView.Rows[row].Cells["columnFileName"].Value.ToString();
                string tags = gridView.Rows[row].Cells["columnTags"].Value.ToString();
                string rus = gridView.Rows[row].Cells["columnRussianPhrase"].Value.ToString();
                string eng = gridView.Rows[row].Cells["columnEnglishPhrase"].Value.ToString();

                if (!xmlDict.ContainsKey(id))
                    throw new System.ArgumentException("Фразы с таким ID не существует!");

                if (xmlDict[id].getFilename() != filename)
                    throw new System.ArgumentException("Имена файлов не совпадают!");

                xmlDict[id].setRusData(rus);
                xmlDict[id].setEngData(eng);
            }            
        }

        public void saveDataToFile(bool english)
        {
            string path = Properties.Settings.Default.PathToFiles;
            path += (english) ? ("\\English\\") : ("\\Russian\\");

            foreach (string file in CFileList.checkedFiles)
            {
                XDocument doc = new XDocument();                
                doc = XDocument.Load(path + file);                
                IEnumerable<XElement> del = doc.Root.Descendants().ToList();
                del.Remove();
                doc.Save(path + file);
                
                foreach (CXmlData text in xmlDict.Values)
                {
                    if (text.getFilename() != file)
                        continue;

                    Stack<string> copy = new Stack<string>(text.getTags());
                    copy = CFileList.invertStack(copy);
                    string value = (english) ? (text.getEngData()) : (text.getRusData());
                    
                    if (copy.Count == 3)
                    {
                        string root = copy.Pop();
                        string chapter = copy.Pop();
                        string item = copy.Pop();

                        if (doc.Root.Descendants().Any(tag1 => tag1.Name == chapter && tag1.Descendants().Any()))
                            doc.Root.Element(chapter).Add(getXElement(item, value));
                        else
                            doc.Root.Add(new XElement(chapter, getXElement(item, value)));
                    }
                    else if (copy.Count == 2)
                    {
                        string root = copy.Pop();
                        string item = copy.Pop();
                        doc.Root.Add( getXElement(item,value) );
                    }
                }
                
                System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                settings.Encoding = new UTF8Encoding(false);
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                settings.NewLineOnAttributes = true;
                using (System.Xml.XmlWriter w = System.Xml.XmlWriter.Create(path + file, settings))
                {
                    doc.Save(w);
                } 
                //doc.Save(path + file);
            }
        }

        private XElement getXElement(string item, string value)
        {
            XElement el;
            if (value != "")
                el = new XElement(item, value);
            else 
                el = new XElement(item);
            return el;
        }

    }
}
