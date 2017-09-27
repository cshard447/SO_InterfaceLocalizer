using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace InterfaceLocalizer.Classes
{

    public class GenericStack<T>
    {
        public static Stack<T> InvertStack(Stack<T> stack)
        {
            Stack<T> result = new Stack<T>(stack);
            return result;
        }
    }

    //********************************************************************

    public class PathAtom : IFormattable
    {
        private string name;
        private string attribute;

        public PathAtom(string _name, string _attribute)
        {
            name = _name;
            attribute = _attribute;
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(attribute))
                return name;
            else
                return (name + " #" + attribute + "#");
        }

        public string ToString(string value, IFormatProvider format)
        {
            return "_";
        }

        public XElement GetAtom()
        { 
            XElement elem = new XElement(name);
            if (!String.IsNullOrEmpty(attribute))
                elem.SetAttributeValue("name", attribute);
            return elem;
        }
    }

    //**********************************************************************

    public class XmlPath
    {
        private Stack<PathAtom> path;

        public XmlPath()
        {
            path = new Stack<PathAtom>();
        }

        public XmlPath(XmlPath copy)
        {
            path = new Stack<PathAtom>(copy.path);
        }

        public void Push(PathAtom atom)
        {
            path.Push(atom);
        }

        public PathAtom Pop()
        {
            return path.Pop();
        }

        public void InvertIt()
        {
            path = GenericStack<PathAtom>.InvertStack(path);
        }

        public int Count()
        {
            return path.Count();
        }

        public string GetPathAsString()
        {
            Stack<PathAtom> copy = new Stack<PathAtom>(path);
            copy = GenericStack<PathAtom>.InvertStack(path);
            StringBuilder result = new StringBuilder("");
            while (copy.Count != 0)
                result.Append(copy.Pop().ToString() + " -> ");
            return result.ToString();
        }

        public XElement GetPathAsElement()
        {
            Stack<PathAtom> copy = new Stack<PathAtom>(path);
            copy = GenericStack<PathAtom>.InvertStack(path);
            XElement result = new XElement(copy.Pop().GetAtom());
            XElement child = result;
            while (copy.Count > 0)
            {
                child.Add(copy.Pop().GetAtom());
                child = child.Descendants().First();
            }

            return result;
        }
    }
}
