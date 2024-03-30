using PA_M450.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_M450.Mocks
{
    public class TransportContainerMock : ITransportContainer
    {
        public Guid Id { get; } = Guid.NewGuid();
        public double Weight { get; set; }
    }
}
