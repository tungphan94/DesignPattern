using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Factory
{
    /// <summary>Product クラス</summary>
    public abstract class Product
    {
    }

    /// <summary>ConcreteComponent クラス</summary>
    public class Product_Table : Product
    {
    }

    public class Product_Sofa : Product
    {
    }

    public abstract class Creator
    {
    }

    public class Creator_Table : Creator
    {
    }

    public class Creator_Sofa : Creator
    {
    }

    public static class Util
    {
        // Clientコード例
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
