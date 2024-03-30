using PA_M450;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testss
{
    internal class UseCase2
    {
        [Test]
        public void CanAcceptOrder_WithSufficientFreeCapacity_ShouldReturnTrue()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            // Nehmen wir an, das Fahrzeug hat bereits 5 Behälter geladen
            for (int i = 0; i < 5; i++)
            {
                vehicle.AssignOrder(new TransportOrderMock { Containers = new List<ITransportContainer> { new TransportContainerMock() } });
            }
            // Überprüfen, ob das Fahrzeug weitere 5 Behälter aufnehmen kann
            int additionalContainers = 5;

            // Act
            bool result = vehicle.CanAcceptOrder(additionalContainers);

            // Assert
            Assert.IsTrue(result, "Das Fahrzeug sollte in der Lage sein, den Auftrag anzunehmen, da es ausreichend freie Kapazität hat.");
        }


        [Test]
        public void CanAcceptOrder_WhenCapacityIsFull_ShouldReturnFalse()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            // Füllen Sie die Kapazität vollständig
            for (int i = 0; i < 10; i++)
            {
                vehicle.AssignOrder(new TransportOrderMock { Containers = new List<ITransportContainer> { new TransportContainerMock() } });
            }
            int additionalContainers = 1; // Versuch, einen weiteren Behälter hinzuzufügen

            // Act
            bool result = vehicle.CanAcceptOrder(additionalContainers);

            // Assert
            Assert.IsFalse(result, "Das Fahrzeug sollte den Auftrag ablehnen, da seine Kapazität vollständig ausgeschöpft ist.");
        }

        [Test]
        public void CanAcceptOrder_WhenAddingOrderExceedsCapacity_ShouldReturnFalse()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            // Nehmen wir an, das Fahrzeug hat bereits 8 Behälter geladen
            for (int i = 0; i < 8; i++)
            {
                vehicle.AssignOrder(new TransportOrderMock { Containers = new List<ITransportContainer> { new TransportContainerMock() } });
            }
            int additionalContainers = 3; // Versuch, drei weitere Behälter hinzuzufügen, was die Kapazität überschreiten würde

            // Act
            bool result = vehicle.CanAcceptOrder(additionalContainers);

            // Assert
            Assert.IsFalse(result, "Das Fahrzeug sollte den Auftrag ablehnen, da das Hinzufügen des Auftrags seine Kapazität überschreiten würde.");
        }



    }
}
