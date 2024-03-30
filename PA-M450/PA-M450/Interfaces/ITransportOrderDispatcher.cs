using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_M450.Interfaces
{
    public interface ITransportOrderDispatcher
    {
        bool DispatchOrder(ITransportOrder order);
        void RegisterVehicle(IAutonomousVehicle vehicle);
        void UpdateVehiclePosition(IAutonomousVehicle vehicle, string newPosition);
    }
}
