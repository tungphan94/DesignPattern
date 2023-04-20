using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Commmand
{
    /// <summary>コマンド インターフェース　</summary>
    public abstract class Command
    {
        public abstract void undo();
        public abstract void redo();

    }

    /// <summary>具象コマンド(Concrete Command) </summary>
    public class EditCommand : Command
    {
        private string text;
        private Document document;
        public EditCommand(Document document, string text)
        {
            this.document = document;
            this.text = text;
        }
        public override void redo()
        {
            document.add(text);
        }
        public override void undo()
        {
            document.remove();
        }
    }

    /// <summary>受け手 （Receiver） クラス</summary>
    public class Document
    {
        List<string> listStrs = new List<string>();
        public void add(string str)
        {
            listStrs.Add(str);
        }

        public void remove()
        {
            if (listStrs.Any()){
                listStrs.RemoveAt(listStrs.Count - 1);
            }
        }

        public string getText()
        {
            if (listStrs.Any()){
                return listStrs.Aggregate((acc, next) => acc + " - " + next);
            } else{
                return "";
            }
        }
    }

    /// <summary>インボーカー （Invoker）</summary>
    public class DocumentInvoker
    {
        private List<Command> undoCommands = new List<Command>();
        private List<Command> redoCommands = new List<Command>();
        private Document document = new Document();

        public void write(string txt){
            document.add(txt);
            var cmd = new EditCommand(document, txt);
            undoCommands.Add(cmd);
            redoCommands.Clear();
        }

        public void undo()
        {
            if (undoCommands.Any()){
                var cmd = undoCommands.Last();
                undoCommands.RemoveAt(undoCommands.Count - 1);
                cmd.undo();
                redoCommands.Add(cmd);
            }
            else {
                Console.WriteLine("nothing");
            }
        }

        public void redo()
        {
            if (redoCommands.Any()){
                var cmd = redoCommands.Last();
                redoCommands.RemoveAt(redoCommands.Count - 1);
                cmd.redo();
                undoCommands.Add(cmd);
            }
            else {
                Console.WriteLine("nothing");
            }
        }
        public string getText()
        {
            return document.getText();
        }
    }
    /// <summary>クライアント （Client） </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new DocumentInvoker();
            instance.write("text1");
            Console.WriteLine(instance.getText());
            instance.undo();
            Console.WriteLine("undo:" +  instance.getText());
            instance.redo();
            Console.WriteLine("redo:" +  instance.getText());
            instance.write("text2");
            instance.write("text3");
            Console.WriteLine(instance.getText());
            instance.undo();
            Console.WriteLine("undo 1:" + instance.getText());
            instance.undo();
            Console.WriteLine("undo 2:" + instance.getText());
            instance.undo();
            Console.WriteLine("undo 3:" + instance.getText());
            instance.undo();
        }
    }
}
