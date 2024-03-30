using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_M450.Interfaces
{
    public interface ITransportContainer
    {
        Guid Id { get; }
        double Weight { get; set; }
    }
}
