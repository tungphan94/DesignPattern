using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class Pizza
    {
        public abstract string doPizza();

        public void show()
        {
            Console.WriteLine(doPizza());
        }
    }

    public class TomatoPizza : Pizza
    {
        public override string doPizza()
        {
            return "Tomato Pizza";
        }
    }

    public class ChickenPizza : Pizza
    {
        public override string doPizza()
        {
            return "Chicken Pizza";
        }
    }

    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }
    }

    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(Pizza pizza) 
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
        public PepperDecorator(Pizza pizza)
            :base(pizza) { }

        public override string doPizza()
        {
            return pizza.doPizza() + addPepper();
        }

        private string addPepper()
        {
            return " + Pepper";
        }
    }
}
