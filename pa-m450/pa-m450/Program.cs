using pa_m450.Interfaces;

namespace pa_m450
{
    class Program
    {
        static void Main(string[] args)
        {
            // Beispieldaten erstellen
            var vehicles = new List<IVehicle>
        {
            new Vehicle { CurrentLocation = new Location { X = 10, Y = 10 } },
            new Vehicle { CurrentLocation = new Location { X = 20, Y = 5 } },
            new Vehicle { CurrentLocation = new Location { X = 30, Y = 30 } }
        };

            var orders = new List<ITransportOrder>
        {
            new TransportOrder
            {
                PickupLocation = new Location { X = 15, Y = 15 },
                DestinationLocation = new Location { X = 50, Y = 50 },
                NumContainers = 5
            },
            new TransportOrder
            {
                PickupLocation = new Location { X = 25, Y = 10 },
                DestinationLocation = new Location { X = 60, Y = 15 },
                NumContainers = 8
            }
        };

            // Fahrzeuge und Aufträge simulieren
            foreach (var order in orders)
            {
                var availableVehicle = FindAvailableVehicle(vehicles, order);
                if (availableVehicle != null)
                {
                    bool accepted = availableVehicle.AcceptTransportOrder(order);
                    Console.WriteLine($"Order {order.NumContainers} containers: {(accepted ? "Accepted" : "Rejected")}");
                }
                else
                {
                    Console.WriteLine($"No available vehicle for order with {order.NumContainers} containers.");
                }
            }
        }

        static IVehicle FindAvailableVehicle(List<IVehicle> vehicles, ITransportOrder order)
        {
            return vehicles
                .Where(v => v.LoadCapacity >= order.NumContainers)
                .OrderBy(v => v.CurrentLocation.DistanceTo(order.PickupLocation))
                .FirstOrDefault();
        }
    }
}
