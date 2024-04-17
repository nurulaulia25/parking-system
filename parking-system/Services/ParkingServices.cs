using System;
using System.Collections.Generic;
using System.Linq;
using parking_system.Models;

namespace parking_system.Services
{
    public class ParkingServices
    {
        private readonly List<ParkingSlot> _parkingSlots = new List<ParkingSlot>();

        public ParkingServices(int numberOfSlots)
        {
            CreateParkingLot(numberOfSlots);
        }

        public void CreateParkingLot(int numberOfSlots)
        {
            if (numberOfSlots <= 0)
            {
                throw new ArgumentException("Number of slots must be greater than zero.");
            }

            for (int i = 0; i < numberOfSlots; i++)
            {
                _parkingSlots.Add(new ParkingSlot { Number = i + 1 });
            }

            Console.WriteLine($"Created a parking lot with {numberOfSlots} slots");
        }

        public void Park(string registrationNumber, string vehicleType, string color)
        {
            var availableSlot = _parkingSlots.FirstOrDefault(slot => slot.Vehicle == null);

            if (availableSlot != null)
            {
                availableSlot.Vehicle = new Vehicle { RegistrationNumber = registrationNumber, Type = vehicleType, Color = color };
                Console.WriteLine($"Allocated slot number: {availableSlot.Number}");
            }
            else
            {
                Console.WriteLine("Sorry, parking lot is full");
            }
        }

        public void Leave(int slotNumber)
        {
            var slot = _parkingSlots.FirstOrDefault(s => s.Number == slotNumber);

            if (slot != null && slot.Vehicle != null)
            {
                slot.Vehicle = null;
                Console.WriteLine($"Slot number {slotNumber} is free");
            }
            else
            {
                Console.WriteLine("Slot number is not available or already free");
            }
        }

        public void Status()
        {
            Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");

            foreach (var slot in _parkingSlots)
            {
                Console.WriteLine($"{slot.Number}\t{slot.Vehicle?.Type}\t{slot.Vehicle?.RegistrationNumber}\t{slot.Vehicle?.Color}");
            }
        }

        public int TypeOfVehicles(string vehicleType)
        {
            return _parkingSlots.Count(slot => slot.Vehicle != null && slot.Vehicle.Type == vehicleType);
        }

        public IEnumerable<string> RegistrationNumbersForVehiclesWithOddPlate()
        {
            return _parkingSlots.Where(slot => slot.Vehicle != null && int.Parse(slot.Vehicle.RegistrationNumber.Substring(1, 4)) % 2 != 0)
                .Select(slot => slot.Vehicle.RegistrationNumber);
        }

        public IEnumerable<string> RegistrationNumbersForVehiclesWithEventPlate()
        {
            return _parkingSlots.Where(slot => slot.Vehicle != null && slot.Vehicle.RegistrationNumber.StartsWith("B"))
                .Select(slot => slot.Vehicle.RegistrationNumber);
        }

        public IEnumerable<string> RegistrationNumbersForVehiclesWithColour(string color)
        {
            return _parkingSlots.Where(slot => slot.Vehicle != null && slot.Vehicle.Color == color)
                .Select(slot => slot.Vehicle.RegistrationNumber);
        }

        public IEnumerable<int> SlotNumbersForVehiclesWithColour(string color)
        {
            return _parkingSlots.Where(slot => slot.Vehicle != null && slot.Vehicle.Color == color)
                .Select(slot => slot.Number);
        }

        public string SlotNumberForRegistrationNumber(string registrationNumber)
        {
            var slot = _parkingSlots.FirstOrDefault(slot => slot.Vehicle != null && slot.Vehicle.RegistrationNumber == registrationNumber);

            if (slot != null)
            {
                return slot.Number.ToString();
            }
            else
            {
                return "Not found";
            }
        }
    }
}
