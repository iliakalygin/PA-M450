using PA_M450.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA_M450.Mocks;
using PA_M450.Interfaces;

namespace PA_M450
{
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
}
