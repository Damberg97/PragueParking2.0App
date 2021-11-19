using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace PragueParking2._0
{
    class ParkingSpot // Egenskaper till parkingspot
    {
        public static int seed = 1;

        public int ParkingSpotSize { get; set; } = Configdata.ParkingspotSize; // Hämtar storlken på parkeringsplatsen (100)

        public int SpotNumber { get; }
        public string status { get; set; }


        public ParkingSpot()
        {

            this.ParkingSpotSize = Configdata.ParkingspotSize; 
            this.SpotNumber = seed;
            seed++;

        }
        public static bool ParkVehicle(Vehicle vehicle, ParkingSpot spot) // Lägger till fordon
        {
            ParkingHouse.Vehicles.Add(vehicle);

            vehicle.ParkedOnSpot = spot.SpotNumber;

            return true;
        }

        public static ParkingSpot SpotFinder(int vehicleSize) // Letar efter en ledig plats
        {
            foreach (ParkingSpot spot in ParkingHouse.ParkingSpots)
            {
                if (spot.ParkingSpotSize >= vehicleSize)
                {
                    return spot;
                }
            }
            return null;
        }

        public static void RemoveVehicle(Vehicle vehicle, ParkingSpot spot) // Tar bort ett fordon
        {
            ParkingHouse.Vehicles.Remove(vehicle);

        }
        public static void ShowVehicles() // Visar alla fordon
        {
            foreach (Vehicle vehicle in ParkingHouse.Vehicles)
            {
                Console.WriteLine("{0}:{1}: {2}: {3}, ", vehicle.ParkedOnSpot, vehicle.VehType, vehicle.RegNumber, vehicle.ParkTime);
            }
            Console.ReadKey();
        }
        public static int CalculateTimeParked(string checkIn, Vehicle vehicle) // Räknar ut hur länge ett fordon har stått parkerat
        {
            TimeSpan span = DateTime.Now - vehicle.ParkTime;
            int totalPrice;
            if (span.TotalMinutes < 10)
            {
                totalPrice = 0;
            }
            else if (span.TotalMinutes < 125)
            {
                if (vehicle.VehType == "CAR")
                {
                    totalPrice = 20;
                }
                else
                {
                    totalPrice = 10;
                }
            }
            else
            {
                int hours;
                if (span.TotalMinutes - 10 % 60 == 0)
                {
                    hours = (int)(span.TotalMinutes - 10) / 60;
                }
                else
                {
                    hours = (int)(span.TotalMinutes - 10) / 60;
                    hours++;
                }
                if (vehicle.VehType == "CAR")
                {
                    totalPrice = hours * 20;
                }
                else
                {
                    totalPrice = hours * 10;
                }
            }
            return totalPrice;


        }
        }
    }
    

