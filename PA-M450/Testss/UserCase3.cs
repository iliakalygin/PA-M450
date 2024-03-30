using PA_M450;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testss
{
    internal class UserCase3
    {
        [Test]
        public void MoveTo_NewValidLocation_ShouldUpdateCurrentLocation()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            var newLocation = "WarehouseB";

            // Act
            vehicle.MoveTo(newLocation);

            // Assert
            Assert.AreEqual(newLocation, vehicle.CurrentLocation, "Das Fahrzeug sollte seine Position erfolgreich auf die neue Location aktualisiert haben.");
        }


        [Test]
        public void MoveTo_SameLocation_ShouldNotTriggerMovement()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            var originalLocation = vehicle.CurrentLocation; // StartLocation
            var sameLocation = "StartLocation";

            // Act
            vehicle.MoveTo(sameLocation);

            // Assert
            Assert.AreEqual(originalLocation, vehicle.CurrentLocation, "Das Fahrzeug sollte seine Position nicht ändern, wenn es zur gleichen Location bewegt wird.");
        }


        [Test]
        public void MoveTo_InvalidLocation_ShouldThrowException()
        {
            // Arrange
            var vehicle = VehicleFactory.GetVehicle("mock");
            var invalidLocation = ""; // Angenommen, eine leere Zeichenkette ist eine ungültige Location

            // Act & Assert
            Assert.Throws<ArgumentException>(() => vehicle.MoveTo(invalidLocation), "Das Fahrzeug sollte eine Ausnahme werfen, wenn eine ungültige Location angegeben wird.");
        }

    }
}
