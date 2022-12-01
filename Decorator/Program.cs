using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Decorator
{
    public abstract class IPizza
    {
        public abstract string doPizza();
        public void show()
        {
            Console.WriteLine(doPizza());
        }
    }

    public class TomatoPizza : IPizza
    {
        public override string doPizza()
        {
            return "Tomato Pizza";
        }
    }

    public class ChickenPizza : IPizza
    {
        public override string doPizza()
        {
            return "Chicken Pizza";
        }
    }

    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza pizza;
        public PizzaDecorator(IPizza pizza)
        {
            this.pizza = pizza;
        }
    }

    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza)
            : base(pizza) { }

        public override string doPizza()
        {
            return pizza.doPizza() + addCheese();
        }

        private string addCheese()
        {
            return " + Cheese";
        }
    }

    public class PepperDecorator : PizzaDecorator
    {
        public PepperDecorator(IPizza pizza)
            : base(pizza) { }

        public override string doPizza()
        {
            return pizza.doPizza() + addPepper();
        }

        private string addPepper()
        {
            return " + Pepper";
        }
    }

    class Program
    {
        static void showPizza()
        {
            var tomatoPizza = new TomatoPizza();
            var chickenPizza = new ChickenPizza();
            tomatoPizza.show();
            chickenPizza.show();
            var cheeseTomatoPizza = new CheeseDecorator(tomatoPizza);
            var peppertomatoPizza = new PepperDecorator(tomatoPizza);
            cheeseTomatoPizza.show();
            peppertomatoPizza.show();
            var cheeseTwo = new CheeseDecorator(new PepperDecorator(new CheeseDecorator(tomatoPizza)));
            cheeseTwo.show();
        }

        static void Main(string[] args)
        {
            showPizza();
        }
    }
}
