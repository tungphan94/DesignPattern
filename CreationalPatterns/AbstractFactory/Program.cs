using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Factory
{
    public abstract class PhoneNumber
    {
        private string phoneNumber;
        public abstract string getCountryCode();
        public string getPhoneNumber() => phoneNumber;
        public void setPhoneNumber(string phoneNumber) { this.phoneNumber = phoneNumber; } 
    }

    public class VietNamesePhoneNumber : PhoneNumber
    {
        public override string getCountryCode() => "+84";
    }

    public class NihonPhoneNumber : PhoneNumber
    {
        public override string getCountryCode() => "+81";
    }

    public abstract class Address
    {
        protected string city;
        protected string street;
        protected string postalCode;

        public void setCity(string city) { this.city = city; }
        public void setStreet(string street) { this.street = street; }
        public void setPostalCode(string postalCode) { this.postalCode = postalCode; }
        public abstract string getFullAddress();
        public abstract string getCountry();
    }

    public class VietNameAdress : Address
    {
        public override string getCountry() => "Viet Nam";

        public override string getFullAddress() => $"{postalCode}\n{street} ,{city} city";
    }

    public class NihonAdress : Address
    {
        public override string getCountry() => "日本";
        public override string getFullAddress() => $"{postalCode}\n{city} city ,{street}";
    }

    public abstract class Factory
    {
        public abstract Address CreateAddress();
        public abstract PhoneNumber CreatePhoneNumber();
    }

    public class VietNameseFactory : Factory
    {
        public override Address CreateAddress()
        {
            return new VietNameAdress();
        }
        public override PhoneNumber CreatePhoneNumber()
        {
            return new VietNamesePhoneNumber();
        }
    }

    public class NihonFactory : Factory
    {
        public override Address CreateAddress()
        {
            return new NihonAdress();
        }
        public override PhoneNumber CreatePhoneNumber()
        {
            return new NihonPhoneNumber();
        }
    }


    public static class Util
    {
        //Clientコード例
        public static void Print(Address address, PhoneNumber phone)
        {
            var title = $"Create {address.getCountry()} Address and Phone Number";
            Console.WriteLine(title);
            Console.WriteLine($"{address.getCountry()}. Address:");
            Console.WriteLine(address.getFullAddress());
            Console.WriteLine($"{address.getCountry()}. Phone Number:");
            Console.WriteLine($"{phone.getCountryCode()} {phone.getPhoneNumber()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vnfactory = new VietNameseFactory();
            var address = vnfactory.CreateAddress();
            var phoneNumber = vnfactory.CreatePhoneNumber();
            phoneNumber.setPhoneNumber("0918-252-0906");
            address.setCity("Ho Chi Minh");
            address.setStreet("273/Phan Anh street");
            address.setPostalCode("008428");
            Util.Print(address, phoneNumber);

            var nihonfactory = new NihonFactory();
            address = nihonfactory.CreateAddress();
            phoneNumber = nihonfactory.CreatePhoneNumber();
            phoneNumber.setPhoneNumber("070-2632-0255");
            address.setCity("osaka");
            address.setStreet("nishiyodogawaku, utajima, 2-12-1");
            address.setPostalCode("555-0021");
            Util.Print(address, phoneNumber);

        }
    }
}
