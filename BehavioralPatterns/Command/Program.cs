using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Commmand
{
    /// <summary>コマンド インターフェース　</summary>
    public abstract class Command
    {
        protected ComputerReceiver receiver;
        public Command(ComputerReceiver receiver)
        {
            this.receiver = receiver;
        }
        public abstract void execute();
    }

    /// <summary>具象コマンド(Concrete Command) </summary>
    public class ShutDownCmd : Command
    {
        public ShutDownCmd(ComputerReceiver receiver) : base(receiver) { }
        public override void execute()
        {
            receiver.shutDown();
        }
    }

    /// <summary>具象コマンド(Concrete Command) </summary>
    public class OpenCmd : Command
    {
        public OpenCmd(ComputerReceiver receiver) : base(receiver) { }

        public override void execute()
        {
            receiver.open();
        }
    }

    /// <summary>具象コマンド(Concrete Command) </summary>
    public class SleepCmd : Command
    {
        public SleepCmd(ComputerReceiver receiver) : base(receiver) { }
        public override void execute()
        {
            receiver.sleep();
        }
    }

    /// <summary>受け手 （Receiver） クラス</summary>
    public class ComputerReceiver
    {
        public void shutDown() { Console.WriteLine("computer is shutdown"); }
        public void open() { Console.WriteLine("computer is Open"); }
        public void sleep() { Console.WriteLine("computer is sleep"); }
    }

    /// <summary>インボーカー （Invoker）</summary>
    public class Invoker
    {
        private Command command;
        public void setCommand(Command command)
        {
            this.command = command;
        }

        public void execute()
        {
            command.execute();
        }
    }
    /// <summary>クライアント （Client） </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = new ComputerReceiver();
            var cmdA = new ShutDownCmd(receiver);
            var cmdB = new OpenCmd(receiver);
            var cmdC = new SleepCmd(receiver);
            var invoker = new Invoker();
            invoker.setCommand(cmdA);
            invoker.execute();

            invoker.setCommand(cmdB);
            invoker.execute();

            invoker.setCommand(cmdC);
            invoker.execute();

        }
    }
}
