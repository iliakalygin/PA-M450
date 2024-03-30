using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA_M450;

namespace Testss
{
    internal class UseCase1
    {
        [Test]
        public void AssignOrder_WithSufficientCapacity_ShouldReturnTrue()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            var order = new TransportOrderMock
            {
                Containers = new List<ITransportContainer> { new TransportContainerMock(), new TransportContainerMock() }
            };

            // Act
            bool result = vehicle.AssignOrder(order);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AssignOrder_WithInsufficientCapacity_ShouldReturnFalse()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            var order = new TransportOrderMock
            {
                Containers = new List<ITransportContainer>(new TransportContainerMock[11]) // 11 Containers, more than capacity
            };

            // Act
            bool result = vehicle.AssignOrder(order);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void AssignOrder_WhenCapacityExactlyMetAndAdditionalOrderComes_ShouldReturnFalse()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            // Add 10 containers to simulate full capacity
            for (int i = 0; i < 10; i++)
            {
                vehicle.AssignOrder(new TransportOrderMock { Containers = new List<ITransportContainer> { new TransportContainerMock() } });
            }
            var additionalOrder = new TransportOrderMock { Containers = new List<ITransportContainer> { new TransportContainerMock() } };

            // Act
            bool result = vehicle.AssignOrder(additionalOrder);

            // Assert
            Assert.IsFalse(result);
        }



    }
}
