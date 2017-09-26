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

    public class GenericTest<T>
    {
        public static Stack<T> invertStack(Stack<T> stack)
        {
            Stack<T> result = new Stack<T>(stack);
            return result;
        }
    }

    //********************************************************************

    public class PathAtom : IFormattable
    {
        string name;
        string attribute;

        public PathAtom(string _name)
        {
            name = _name;
            attribute = "";
        }

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

        public XElement getAtom()
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
        Stack<PathAtom> path;

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
            path = GenericTest<PathAtom>.invertStack(path);
        }

        public int Count()
        {
            return path.Count();
        }

        public string getPathAsString()
        {
            Stack<PathAtom> copy = new Stack<PathAtom>(path);
            copy = GenericTest<PathAtom>.invertStack(path);
            StringBuilder temp = new StringBuilder("");
            while (copy.Count != 0)
                temp.Append(copy.Pop().ToString() + " -> ");
            return temp.ToString();
        }

        public XElement getPathAsElement()
        {
            Stack<PathAtom> copy = new Stack<PathAtom>(path);
            copy = GenericTest<PathAtom>.invertStack(path);            
            XElement result = new XElement(copy.Pop().getAtom());
            while (copy.Count > 0)
            {
                result.Add(copy.Pop().getAtom());
            }
            return result;
        }
    }
}
