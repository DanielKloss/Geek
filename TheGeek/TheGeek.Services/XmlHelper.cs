using System.Xml.Linq;

namespace TheGeek.Services
{
    public static class XmlHelper
    {
        public static XElement TryGetElement(this XElement parentElement, string elementName, XElement defaultElement = null)
        {
            XElement foundElement = parentElement.Element(elementName);

            if (foundElement != null)
            {
                return foundElement;
            }

            return defaultElement;
        }

        public static XAttribute TryGetAttribute(this XElement parentElement, string attributeName, XAttribute defaultAttribute = null)
        {
            XAttribute foundAttribute = parentElement.Attribute(attributeName);

            if (foundAttribute != null)
            {
                return foundAttribute;
            }

            return defaultAttribute;
        }
    }
}
