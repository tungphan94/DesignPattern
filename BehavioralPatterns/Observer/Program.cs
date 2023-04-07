using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Observer
{
    class Program
    {
        /// <summary>Observer クラス</summary>
        public abstract class Observer
        {
            public abstract void update(Subject subject);
        }
        /// <summary>Subject クラス</summary>
        public abstract class Subject
        {
            ////オブザーバーのリストを含む
            private List<Observer> employees = new List<Observer>();
            ////オブザーバーを追加する
            public void register(Observer o)
            {
                employees.Add(o);
            }
            ////オブザーバーを削除する
            public void unregister(Observer o)
            {
                employees.Remove(o);
            }
            //オブザーバーへ通知する。
            public void notifyObservers(Subject subject)
            {
                foreach (var o in employees){
                    o.update(this);
                }
            }
            public abstract string getTitle();
            public abstract string getMesseage();
        }
        /// <summary>ConcreteObserver クラス</summary>
        public class Employee : Observer
        {
            public string name { get; }
            private string salaryURL { get; set; }
            public Employee(string name) { 
                this.name = name;
            }
            public override void update(Subject subject)
            {
                Console.WriteLine($"{subject.getTitle()}\n{name} 様\n {subject.getMesseage()}");
                Console.WriteLine($"Web給与明細URL：\n {salaryURL}\n");
            }
            public void setSalaryWebURL(string webURL) { this.salaryURL = webURL; }
        }
        /// ConcreteSubjectクラス</summary>
        public class Manage : Subject
        {
            private string title;
            private string messeage;
            public void sendSalaryMesseage(string title, string messeage)
            {
                this.title = title;
                this.messeage = messeage;
                notifyObservers(this);
            }
            public override string getTitle() => title;
            public override string getMesseage() => messeage;
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
