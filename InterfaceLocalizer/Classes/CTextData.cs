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
        public string filename;
        public Stack<string> tags;
        public CTextData()
        {         
        }
        public CTextData(string _phrase, string _filename, Stack<string> _tags)
        {
            phrase = _phrase;
            filename = _filename;
            tags = new Stack<string>();
            tags = _tags;
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
            Stack<string> tags = new Stack<string>();
                        
            XmlTextReader reader = new XmlTextReader (filename);
            while (reader.Read())  
            {

                switch (reader.NodeType)  
                {
                    case XmlNodeType.Element: // Узел является элементом.
                        tags.Push(reader.Name);
                        //Console.Write("<" + reader.Name);
                        //Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: // Вывести текст в каждом элементе.
                        phrase = reader.Value.Trim();
                        //Console.WriteLine (reader.Value);
                        break;
                    case XmlNodeType.EndElement: // Вывести конец элемента.
                        if (phrase != "")
                        {
                            Stack<string> queue = new Stack<string>(tags.ToArray());
                            texts.Add(new CTextData(phrase, filename, queue));
                            phrase = "";
                        }
                        tags.Pop();
                        //Console.Write("</" + reader.Name);
                        //Console.WriteLine(">");
                        break;
                }
            }
            //Console.ReadLine();

        }
    }
}
