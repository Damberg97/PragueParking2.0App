using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace PragueParking2._0
{

    class Configdata
    {
        /// <summary>
        /// Egenskaper som läser av min textfil
        /// </summary>
        public static int CarSize { get; set; } 
        public static int McSize { get; set; }
        public static int ParkingspotSize { get; set; }
        public static int ParkingLotSize { get; set; }
        public static int CarPrice { get; set; }
        public static int McPrice { get; set; }
        public static int FreeMin { get; set; }


        /// <summary>
        /// We read from our configfile and set the value from the list to our properies above
        /// </summary>
        public static void ReadSizeFile()
        {
            string path = @"../../../Documents/ParkingHouse.txt";
            List<string> ConfigSize = File.ReadAllLines(path).ToList(); // Lista som läser in textfilen ParkingHouse

            foreach (var data in ConfigSize) // Går genom listan och splittar med : och tar det värde som finns där
            {
                if (data.Contains("carsize"))
                {
                    string[] carSize = data.Split(":");
                    CarSize = int.Parse(carSize[1]);
                }
                else if (data.Contains("mcsize"))
                {
                    string[] mcSize = data.Split(":");
                    McSize = int.Parse(mcSize[1]);
                }
                else if (data.Contains("parkingspot"))
                {
                    string[] spotSize = data.Split(":");
                    ParkingspotSize = int.Parse(spotSize[1]);
                }
                else if (data.Contains("parkinglot"))
                {
                    string[] parkingLot = data.Split(":");
                    ParkingLotSize = int.Parse(parkingLot[1]);
                }
                else if (data.Contains("carprice"))
                {
                    string[] carprice = data.Split(":");
                    CarPrice = int.Parse(carprice[1]);

                }
                else if (data.Contains("mcprice"))
                {
                    string[] mcprice = data.Split(":");
                    McPrice = int.Parse(mcprice[1]);

                }
                else if (data.Contains("freemin"))
                {
                    string[] freemin = data.Split(":");
                    FreeMin = int.Parse(freemin[1]);
                }
            }
        }
        public static void ReadParkingFile() // Läser parkingslistan och omvandlar till Json
        {
            string path = @"../../../Documents/ParkingList.txt";
            string jsonText = File.ReadAllText(path);
            List<Vehicle> data = JsonConvert.DeserializeObject<List<Vehicle>>(jsonText).ToList();
            foreach (Vehicle vehicle in data)
            {
                ParkJsonList(vehicle); // Sparar datan i vehicle listan
            }
        }
        public static void ParkJsonList(Vehicle vehicle) // Sparar all data till listan - fordonstyp, parkeringsplats, tid etc
        {
            if (vehicle.VehType == "CAR")
            {
                Car newcar = new Car(vehicle.RegNumber, vehicle.ParkedOnSpot, vehicle.ParkTime);
                ParkingSpot spot = ParkingHouse.FindParkedAtSpot(newcar);
                ParkingSpot.ParkVehicle(newcar, spot);
                spot.ParkingSpotSize -= newcar.VehSize;
            }
            else
            {
                MC newmc = new MC(vehicle.RegNumber, vehicle.ParkedOnSpot, vehicle.ParkTime);
                ParkingSpot spot = ParkingHouse.FindParkedAtSpot(newmc);
                spot.ParkingSpotSize -= newmc.VehSize;
                ParkingSpot.ParkVehicle(newmc, spot);
            }
        }
        public static void SaveToJasonFile() // Sparar all data till filen efter programmet stängs ner
        {
            string path = @"../../../Documents/ParkingList.json";
            string vehicle = JsonConvert.SerializeObject(ParkingHouse.Vehicles);
            File.WriteAllText(path, vehicle);
        }

    }
}
