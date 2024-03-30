using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_M450.Interfaces
{
    public interface IAutonomousVehicle
    {
        Guid Id { get; }
        string CurrentLocation { get; set; }
        int Capacity { get; }
        bool AssignOrder(ITransportOrder order);
        bool CanAcceptOrder(int numberOfContainers);
        void MoveTo(string location);
    }
}
