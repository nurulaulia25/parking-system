using parking_system.Services;
using System;

namespace parking_system
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingServices parkingServices = new ParkingServices(6);

            parkingServices.Park("B-1234-XYZ", "Mobil", "Putih");
            parkingServices.Park("B-9999-XYZ", "Motor", "Putih");
            parkingServices.Park("D-0001-HIJ", "Mobil", "Hitam");
            parkingServices.Park("B-7777-DEF", "Mobil", "Merah");
            parkingServices.Park("B-2701-XXX", "Mobil", "Biru");
            parkingServices.Park("B-3141-ZZZ", "Motor", "Hitam");
            parkingServices.Leave(4);
            parkingServices.Status();
            Console.WriteLine(parkingServices.TypeOfVehicles("Mobil"));
            Console.WriteLine(string.Join(", ", parkingServices.RegistrationNumbersForVehiclesWithOddPlate()));
            Console.WriteLine(string.Join(", ", parkingServices.RegistrationNumbersForVehiclesWithEventPlate()));
            Console.WriteLine(string.Join(", ", parkingServices.RegistrationNumbersForVehiclesWithColour("Hitam")));
            Console.WriteLine(string.Join(", ", parkingServices.SlotNumbersForVehiclesWithColour("Putih")));
            Console.WriteLine(parkingServices.SlotNumberForRegistrationNumber("B-3141-ZZZ"));
            Console.WriteLine(parkingServices.SlotNumberForRegistrationNumber("Z-1111-AAA"));
        }
    }
}
