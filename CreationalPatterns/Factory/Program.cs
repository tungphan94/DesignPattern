using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Factory
{
    /// <summary>Product クラス</summary>
    public abstract class Product
    {
        protected string material { get; set; }
        public Product(string material) 
        { 
            this.material = material; 
        }
        public abstract string getText();
    }

    /// <summary>ConcreteComponent クラス</summary>
    public class Product_Table : Product
    {
        public Product_Table(string material) : base(material) { }
        public override string getText()
        {
            return $"material of table: {material}";
        }
    }

    public class Product_Sofa : Product
    {
        public Product_Sofa(string material) : base(material) { }
        public override string getText()
        {
            return $"material of sofa: {material}";
        }
    }

    public abstract class Creator
    {
        public abstract Product createProduct(string material);
    }

    public class Creator_Table : Creator
    {
        public override Product createProduct(string material)
        {
            return new Product_Table(material);
        }
    }

    public class Creator_Sofa : Creator
    {
        public override Product createProduct(string material)
        {
            return new Product_Sofa(material);
        }
    }

    public static class Util
    {
        //Clientコード例
        public static void Print(Product product) =>
            Console.WriteLine(product.getText());
    }

    class Program
    {
        static void Main(string[] args)
        {
            var create_table = new Creator_Table();
            var tbl1 = create_table.createProduct("plastic");
            var tbl2 = create_table.createProduct("wood");
            var create_sofa = new Creator_Sofa();
            var sofa1 = create_sofa.createProduct("Cotton");
            var sofa2 = create_sofa.createProduct("Suede");
            Util.Print(tbl1);
            Util.Print(tbl2);
            Util.Print(sofa1);
            Util.Print(sofa2);
        }
    }
}
