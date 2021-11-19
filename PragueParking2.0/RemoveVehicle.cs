using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class RemoveVehicle
    {
        public static void CheckoutVehicle(string regNumber) // Checkar ut fordonet. Här visas hur länge fordonet har stått och all info om det
        {
            (Vehicle foundVehicle, ParkingSpot spot) = ParkingHouse.FindVehicleSpot(regNumber);
            if (spot != null)
            {
                if (foundVehicle.VehType is not "buss")
                {
                    int vehCost = foundVehicle.vehCost;
                    spot.ParkingSpotSize += foundVehicle.VehSize;
                    string ParkTime = foundVehicle.ParkTime.ToString();
                    ParkingSpot.RemoveVehicle(foundVehicle, spot);
                    Configdata.SaveToJasonFile();
                    string checkin = foundVehicle.ParkTime.ToString();
                    int CalculatePrice = ParkingSpot.CalculateTimeParked(checkin, foundVehicle);
                    recipt(foundVehicle, CalculatePrice, out string removed);
                }
                
            }
            else
            {
                ParkingHouse.ErrorMsg();
            }
        }
        public static void recipt(Vehicle vehicle, int totalPrice, out string recpit) // Printar ut regnummer, vilken parkeringsplats, tiden som fordonet parkerades, tiden nu och det totala priset som användaren måste betala
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            recpit = $"Removing vehicle {vehicle.RegNumber} from spot {vehicle.ParkedOnSpot} Parking was started at {vehicle.ParkTime} And was parked till {DateTime.Now}. Price To pay:{totalPrice}CZK";
            Console.WriteLine(recpit);
            Console.ReadKey();
            Console.ResetColor();

        }
    }
}
    
