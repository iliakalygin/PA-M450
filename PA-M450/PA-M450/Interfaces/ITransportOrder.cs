using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_M450.Interfaces
{
    public interface ITransportOrder
    {
        Guid Id { get; }
        string FromLocation { get; }
        string ToLocation { get; }
        IList<ITransportContainer> Containers { get; }
    }
}
