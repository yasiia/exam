namespace Малик
{
        
    public abstract class Courier
    {
        private string name;
        private double deliveryCost;

        protected Courier(string name, double cost)
        {
            this.name = name;
            this.deliveryCost = cost;
        }

        public string GetName() => name;
        public double GetDeliveryCost() => deliveryCost;

        public abstract void DeliverOrder();
    }

    public class BikeCourier : Courier
    {
        public BikeCourier(string name) : base(name, 15) { }

        public override void DeliverOrder()
        {
            Console.WriteLine($"{GetName()} delivers orders by bicycle. The cost of delivery is {GetDeliveryCost()}$.");
        }
    }

    public class CarCourier : Courier
    {
        public CarCourier(string name) : base(name, 30) { }

        public override void DeliverOrder()
        {
            Console.WriteLine($"{GetName()} delivers orders by car. The cost of delivery is {GetDeliveryCost()}$.");
        }
    }

    public abstract class CourierFactory
    {
        public abstract Courier CreateCourier(string name);
    }


    public class BikeCourierFactory : CourierFactory
    {
        public override Courier CreateCourier(string name)
        {
            return new BikeCourier(name);
        }
    }

    public class CarCourierFactory : CourierFactory
    {
        public override Courier CreateCourier(string name)
        {
            return new CarCourier(name);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            CourierFactory factory;
            Console.WriteLine("Select courier type: 1 - Bicycle, 2 - Car");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                factory = new BikeCourierFactory();
            }
            else
            {
                factory = new CarCourierFactory();
            }

            Courier courier = factory.CreateCourier("Donkey");
            courier.DeliverOrder();

            Console.ReadLine();

        }
    }
}

