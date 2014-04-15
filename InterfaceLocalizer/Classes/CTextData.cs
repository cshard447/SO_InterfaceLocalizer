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
                            Stack<string> queue = new Stack<string>(tags.ToArray());
                            texts.Add(new CTextData(phrase, eng, filename, queue));
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

        /*
        private Stack<string> invertStack(Stack<string> stack)
        {
            Stack<string> result = new Stack<string>();
            while (stack.Count > 0)
                result.Push(stack.Pop());
            return result;
        }
         */ 
    }
}
