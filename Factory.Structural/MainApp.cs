using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Structural
{
    class MainApp
    {
        static void Main(string[] args)
        {
            var creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0} {1}", product.GetType().Name,product.Name);
            }

            Console.ReadKey();
        }
    }

    abstract class Product
    {
        public abstract string Name { get; }
    }

    class ConcreteProductA : Product
    {

        public override string Name
        {
            get
            {
                return "ProductA";
            }

        }
    }
    class ConcreteProductB : Product
    {
        public override string Name
        {
            get
            {
                return "ProductB";
            }

        }
    }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
