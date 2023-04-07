using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Observer
{
    class Program
    {
        public abstract class Observer
        {
            public abstract void update(string title, string messeage);
        }
        public abstract class Subject
        {
            public abstract void register(Observer o);
            public abstract void unregister(Observer o);
            public abstract void notifyObservers(string title, string messeage);
        }

        public class Employee : Observer
        {
            public string name { get; }
            private string salaryURL { get; set; }
            public Employee(string name) { 
                this.name = name;
            }
            public override void update(string title, string messeage)
            {
                Console.WriteLine($"{title}\n{name} 様\n {messeage}");
                Console.WriteLine($"Web給与明細URL：\n {salaryURL}\n");
            }
            public void setSalaryWebURL(string webURL) { this.salaryURL = webURL; }
        }

        public class Manage : Subject
        {
            private List<Observer> employees = new List<Observer>();
            public override void register(Observer o)
            {
                employees.Add(o);
            }
            public override void unregister(Observer o)
            {
                employees.Remove(o);
            }
            public override void notifyObservers(string title, string messeage)
            {
                foreach(var o in employees){
                    o.update(title, messeage);
                }
            }
            public void sendSalaryMesseage(string title, string messeage)
            {
                notifyObservers(title, messeage);
            }
        }

        static void Main(string[] args)
        {
            var manage = new Manage();
            var employee1 = new Employee("ABC");
            var employee2 = new Employee("DEF");
            employee1.setSalaryWebURL("https://service.officestation.jp//ABC//user-mypage/auth");
            employee2.setSalaryWebURL("https://service.officestation.jp//DEF//user-mypage/auth");
            manage.register(employee1);
            manage.register(employee2);
            manage.sendSalaryMesseage(
                "2月給与明細のお知らせ", 
                "2月の給与明細を配信しましたので、ご連絡いたします。");

            manage.unregister(employee2);
            manage.sendSalaryMesseage(
                "3月給与明細のお知らせ",
                "3月の給与明細を配信しましたので、ご連絡いたします。");

        }
    }
}
