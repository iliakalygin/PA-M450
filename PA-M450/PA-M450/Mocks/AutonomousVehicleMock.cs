using PA_M450.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_M450.Mocks
{
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
            return Capacity - currentLoad >= numberOfContainers;
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
}
