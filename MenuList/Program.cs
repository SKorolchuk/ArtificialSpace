using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MenuList
{
    class Program
    {
        private static Action<string> Behavior;  
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("Menu.xml");
            foreach (var s in from s in doc.Element("Menu").Elements() select s)
            {
                switch (s.Attribute("behavior").Value)
                {
                    case "LUNCH":
                        Behavior = str =>
                                            {
                                                 Console.WriteLine("Now launched {0}", str);
                                            }; 
                        break;
                    case "EXIT":
                        Behavior = str =>
                        {
                            Console.WriteLine("Now exit {0}", str);
                        };
                        break;
                    default:
                        break;
                }
                Behavior(s.Attribute("name").Value);
            }
            Console.ReadLine();
        }
    }
}
