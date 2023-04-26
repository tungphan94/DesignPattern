using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{

    public class SettingFile
    {
        public abstract class Element
        {
            private string indent;

            public void setIndent(string indent)
            {
                this.indent += indent;
            }
            public string getIndent() => indent;
            public abstract void accecpt(Visitor visitor);
        }

        public class KeyValueElement : Element
        {
            public string key { get; }
            public string value { get; }

            public KeyValueElement(string key, string value)
            {
                this.key = key;
                this.value = value;
            }

            public override void accecpt(Visitor visitor)
            {
                visitor.visit(this);
            }
        }

        public class ObjectSettingElement : Element
        {
            public string name { get; }
            public ObjectSettingElement(){}
            public ObjectSettingElement(string name)
            {
                this.name = name;
            }
            public List<Element> elements = new List<Element>();

            public void append(Element component)
            {
                elements.Add(component);
            }

            public override void accecpt(Visitor visitor)
            {
                visitor.visit(this);
            }
        }

        public abstract class Visitor
        {
            public abstract void visit(KeyValueElement keyValue);
            public abstract void visit(ObjectSettingElement objectSetting);
        }

        public class SettingJsonVisitor : Visitor
        {
            public override void visit(KeyValueElement keyValue)
            {
                var txt = keyValue.getIndent() + $"\"{keyValue.key}\":\"{keyValue.value}\"";
                Console.WriteLine(txt);
            }
            public override void visit(ObjectSettingElement objectSetting)
            {
                var indent = objectSetting.getIndent();
                var startTag = string.IsNullOrEmpty(objectSetting.name) ? "{" : $"{objectSetting.name}:" + "{";
                startTag = objectSetting.getIndent() + startTag;
                Console.WriteLine(startTag);
                foreach (var e in objectSetting.elements){
                    e.setIndent(indent + "  ");
                    e.accecpt(this);
                }
                var endTag = indent + "}";
                Console.WriteLine(endTag);
            }

        }

        public class SettingIniVisitor : Visitor
        {
            public override void visit(KeyValueElement keyValue)
            {
                var txt = $"{keyValue.key}={keyValue.value}";
                Console.WriteLine(txt);
            }
            public override void visit(ObjectSettingElement objectSetting)
            {
                if (!string.IsNullOrEmpty(objectSetting.name)){
                    var section = $"[{objectSetting.name}]";
                    Console.WriteLine(section);
                }
                foreach (var e in objectSetting.elements){
                    e.accecpt(this);
                }
            }
        }

        public static void cmd()
        {
            Console.WriteLine("---------------Setting file json: -------------- ");
            var keyVal1 = new KeyValueElement("Url", "http://examplefile1");
            var keyVal2 = new KeyValueElement("Url", "http://examplefile2");

            var obj1 = new ObjectSettingElement("example-file1");
            obj1.append(keyVal1);
            var obj2 = new ObjectSettingElement("example-file2");
            obj2.append(keyVal2);

            var obj3 = new ObjectSettingElement("deployment");
            obj3.append(obj1);
            obj3.append(obj2);
            var keyVal3 = new KeyValueElement("id", "V1");
            var parentJson = new ObjectSettingElement("");
            parentJson.append(obj3);
            parentJson.append(keyVal3);
            parentJson.accecpt(new SettingJsonVisitor());

            Console.WriteLine("\n---------------Setting file ini: -------------- ");
            obj3 = new ObjectSettingElement("deployment");
            obj3.append(keyVal3);

            parentJson = new ObjectSettingElement();
            parentJson.append(obj1);
            parentJson.append(obj2);
            parentJson.append(obj3);
            parentJson.accecpt(new SettingIniVisitor());
        }
    }
}


