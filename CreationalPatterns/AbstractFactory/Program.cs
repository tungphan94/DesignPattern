using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Factory
{
    /// <summary>ProductTable クラス</summary>
    public abstract class ComputerProduct
    {
        public abstract string operatingSystem();
    }

    public class SamsungComputer : ComputerProduct
    {
        public override string operatingSystem() => "Computer: Windows";
    }

    public class MacbookComputer : ComputerProduct
    {
        public override string operatingSystem() => "Computer: Mac OS";
    }

    public abstract class PhoneProduct
    {
        protected string beta;
        public PhoneProduct(string beta) { this.beta = beta; }
        public abstract string operatingSystem();
    }

    public class Galaxy : PhoneProduct
    {
        public Galaxy(string beta) : base(beta) { }
        public override string operatingSystem() => $"Phone: Android {beta}";

    }

    public class Iphone : PhoneProduct
    {
        public Iphone(string beta) : base(beta) { }
        public override string operatingSystem() =>$"Phone: IOS {beta}";
    }


    public abstract class AbstractFactory
    {
        public abstract ComputerProduct createComputer();
        public abstract PhoneProduct createPhone(string beta);
    }

    public class SamsungFactory : AbstractFactory
    {
        public override ComputerProduct createComputer()
        {
            return new SamsungComputer();
        }

        public override PhoneProduct createPhone(string beta)
        {
            return new Galaxy(beta);    
        }
    }

    public class AppleFactory : AbstractFactory
    {
        public override ComputerProduct createComputer()
        {
            return new MacbookComputer();
        }

        public override PhoneProduct createPhone(string beta)
        {
            return new Iphone(beta);
        }
    }

    public static class Util
    {
        //Clientコード例
        public static void Print(ComputerProduct comp, PhoneProduct phone)
        {
            Console.WriteLine(comp.operatingSystem());
            Console.WriteLine(phone.operatingSystem());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var samsungFactory  = new SamsungFactory();
            var comp = samsungFactory.createComputer();
            var phone = samsungFactory.createPhone("15");
            Util.Print(comp, phone);
            var AppleFactory = new AppleFactory();
            comp = AppleFactory.createComputer();
            phone = AppleFactory.createPhone("17");
            Util.Print(comp, phone);
        }
    }
}
