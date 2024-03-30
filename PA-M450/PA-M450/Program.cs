namespace PA_M450
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface ITransportContainer
    {
        Guid Id { get; }
        double Weight { get; set; }
    }

    public interface ITransportOrder
    {
        Guid Id { get; }
        string FromLocation { get; }
        string ToLocation { get; }
        IList<ITransportContainer> Containers { get; }
    }


    public interface IAutonomousVehicle
    {
        Guid Id { get; }
        string CurrentLocation { get; set; }
        int Capacity { get; }
        bool AssignOrder(ITransportOrder order);
        bool CanAcceptOrder(int numberOfContainers);
        void MoveTo(string location);
    }


    public interface ITransportOrderDispatcher
    {
        bool DispatchOrder(ITransportOrder order);
        void RegisterVehicle(IAutonomousVehicle vehicle);
        void UpdateVehiclePosition(IAutonomousVehicle vehicle, string newPosition);
    }

    public class AutonomousVehicleMock : IAutonomousVehicle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string CurrentLocation { get; set; } = "StartLocation";
        public int Capacity { get; } = 10;
        public List<ITransportOrder> AssignedOrders = new List<ITransportOrder>();

        public bool AssignOrder(ITransportOrder order)
        {
            if (CanAcceptOrder(order.Containers.Count))
            {
                AssignedOrders.Add(order);
                return true;
            }
            return false;
        }

        public bool CanAcceptOrder(int numberOfContainers)
        {
            int currentLoad = AssignedOrders.Sum(o => o.Containers.Count);
            return (Capacity - currentLoad) >= numberOfContainers;
        }

        public void MoveTo(string location)
        {
            // Überprüfen, ob die Location ungültig ist (z.B. leer oder null)
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Location darf nicht leer oder null sein.", nameof(location));
            }
            CurrentLocation = location;
        }
    }



    public class VehicleFactory
    {
        public static IAutonomousVehicle GetVehicle(string mode)
        {
            if (mode == "mock")
            {
                return new AutonomousVehicleMock();
            }
            else
            {
                // Implementierung würde hier folgen
                throw new NotImplementedException();
            }
        }
    }

    public class TransportContainerMock : ITransportContainer
    {
        public Guid Id { get; } = Guid.NewGuid();
        public double Weight { get; set; }
    }

    public class TransportOrderMock : ITransportOrder
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public IList<ITransportContainer> Containers { get; set; } = new List<ITransportContainer>();
    }




}
