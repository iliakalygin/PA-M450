using PA_M450.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_M450.Mocks
{
    public class TransportOrderMock : ITransportOrder
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public IList<ITransportContainer> Containers { get; set; } = new List<ITransportContainer>();
    }
}
