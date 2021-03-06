﻿using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InterfaceLocalizer.Classes
{
    class CKeyValue : ITranslatable, IFormattable
    {
        private string key;
        private Dictionary<string, string> values;
        private string filename;

        public CKeyValue(string _key, string _language, string _text, string _filename)
        {
            key = _key;
            filename = _filename;
            values = new Dictionary<string, string>();
            values.Add(_language, _text);
        }

        public string GetOriginalText()
        {
            return "im original";
        }

        public string GetTranslation(string key)
        {
            if (values.ContainsKey(key))
                return values[key];
            else
                return "<NO DATA>";
        }

        public string GetFilename()
        {
            return filename;
        }

        public string GetPathString()
        {
            return key;
        }

        public void SetOriginalText(string originalText)
        {
            throw new NotImplementedException();
        }

        public void SetTranslation(string language, string translatedText)
        {
            values[language] = translatedText;
        }

        public bool Troublesome(out TroubleType trouble)
        {
            trouble = TroubleType.none;
            if (values.Count < CFileList.LanguageToFile.Count)
            {
                trouble = TroubleType.absence;
                return true;
            }

            var duplicateValues = values.GroupBy(x => x.Value).Where(x => x.Count() > 1);
            if (duplicateValues.Count() > 0)
            {
                trouble = TroubleType.duplicate;
                return true;
            }

            return false;            
        }

        public XElement GetPath()
        {
            throw new NotImplementedException();
        }

        public object[] GetAsRow()
        {
            object[] values = new object[7];
            values[0] = GetPathString();
            values[1] = Path.GetFileName(GetFilename());
            values[2] = GetPathString();
            for (int i = 0; i < CFileList.LanguageToFile.Count(); i++)
                values[i + 3] = GetTranslation(CFileList.LanguageToFile.Keys.ElementAt(i));
            return values;
        }

        public override string ToString()
        {
            string result = key + ": " + values.Count;
            return result;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            string result = key + ": " + values.Count;
            return result;
        }
    }

    //***************************************************************************************************

    class CKeyValueManager : IManager
    {
        private Dictionary<object, ITranslatable> dict;
        private Encoding encoding = Encoding.GetEncoding(1252);


        public CKeyValueManager()
        {
            dict = new Dictionary<object, ITranslatable>();
        }

        public Dictionary<object, ITranslatable> GetFullDictionary()
        {
            return dict;
        }

        public void ClearAllData()
        {
            dict.Clear();
        }

        public void AddFileToManager(string filename)
        {
            foreach (string language in CFileList.LanguageToFile.Keys)
            {
                string translationPath = CFileList.LanguageToFile[language];
                ReadKeyValueFile(language, translationPath);
            }
        }

        private void ReadKeyValueFile(string language, string filename)
        {
            StreamReader reader = new StreamReader(filename);   //, Encoding.GetEncoding(1252)
            bool withQuotes = Path.GetExtension(filename) == ".strings";
            while (!reader.EndOfStream)
            {
                string rawline = reader.ReadLine();
                if (String.IsNullOrEmpty(rawline))      // skip empty lines
                    continue;
                rawline = ConcatenateFurtherStrings(reader, rawline);
                rawline = ConvertCodepointsToChars(rawline);
                int indexOfEquality = rawline.IndexOf("=");
                if (indexOfEquality == -1)              // skip lines without = sign for now
                    continue;
                int length = rawline.Length;                
                string key = rawline.Substring(0, indexOfEquality).Trim();
                string value = rawline.Substring(indexOfEquality+1, length - indexOfEquality-1).Trim();
                if (withQuotes)
                {
                    key = RemoveQuotes(key);
                    value = RemoveQuotes(value);
                }
                if (!dict.ContainsKey(key))
                    dict.Add(key, new CKeyValue(key, language, value, filename));
                else
                    dict[key].SetTranslation(language, value);
            }
        }

        private string ConcatenateFurtherStrings(StreamReader reader, string source)
        {
            string result = source;
            while (source.EndsWith("\\"))
            {
                string temp = reader.ReadLine();
                if (temp.IndexOf("=") == -1)
                    result += temp;
                source = temp;
            }
            return result;
        }

        private string RemoveQuotes(string source)
        {
            string result = source;
            if( source.StartsWith("\""))
                result = source.Replace('"', ' ');
            if ( source.EndsWith(";"))
                result = result.Substring(0, result.Length-2);
            result = result.Trim();
            return result;
        }

        private string ConvertCodepointsToChars(string source)
        {
            string result = source;
            int indexofUnichar = result.IndexOf("\\u"); ;
            while (indexofUnichar > 0)
            {
                string charString = result.Substring(indexofUnichar + 2, 4);
                int charInt = Int32.Parse(charString, System.Globalization.NumberStyles.HexNumber);
                byte[] array = { (byte)charInt };
                string character = encoding.GetString(array);
                result = source.Substring(0, indexofUnichar);
                result += character;
                result += source.Substring(indexofUnichar + 6, source.Length - indexofUnichar - 6);
                indexofUnichar = result.IndexOf("\\u");
                source = result;
            }
            return result;
        }

        public void UpdateDataFromGridView(Telerik.WinControls.UI.RadGridView gridView)
        {
            throw new NotImplementedException();
        }

        public void SaveDataToFile(bool original)
        {
            throw new NotImplementedException();
        }
    }


}
