using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
