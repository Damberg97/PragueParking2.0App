using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class MoveVehicle
    {
        
        public static bool Move(string regNumber) // Flyttar fordon
        {
            Console.WriteLine("Enter new spot number:");
            string userInput = Console.ReadLine();
            int newSpot;
            bool check = int.TryParse(userInput, out newSpot);

            (Vehicle foundVehicle, ParkingSpot oldSpot) = ParkingHouse.FindVehicleSpot(regNumber);
            if (check && oldSpot != null)
            {
                ParkingSpot newSpots = ParkingHouse.FreeSpot(foundVehicle.VehSize, newSpot);

                if (newSpots != null)
                {
                    ParkingSpot.RemoveVehicle(foundVehicle, oldSpot);
                    ParkingSpot.ParkVehicle(foundVehicle, newSpots);
                    foundVehicle.ParkedOnSpot = newSpot;
                    newSpots.ParkingSpotSize -= foundVehicle.VehSize;
                    oldSpot.ParkingSpotSize += foundVehicle.VehSize;
                    Recipt(foundVehicle, newSpots, out string recipt);
                    Configdata.SaveToJasonFile();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Selected spot {0} is currently full. Please try again!", newSpots);
                    Console.ReadKey();
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("We could not find a vehicle with licenseplate {0} or the {1} is not an number", regNumber, userInput);
                Console.ReadKey();
                Console.ResetColor();
            }
            return true;

        }
        public static void Recipt(Vehicle vehicle, ParkingSpot spot, out string recipt) // Printar ut ett kvitto efter fordonet har flyttats
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            recipt = $"Move vehicle {vehicle.RegNumber} to parkingspace {spot.SpotNumber} you been parked for:{(DateTime.Now - vehicle.ParkTime).ToString("G")}";
            Console.WriteLine(recipt);
            Console.ReadKey();
            Console.ResetColor();
        }
    }
}
