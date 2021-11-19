using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace PragueParking2._0
{
    class ParkingHouse
    {
        public static ParkingSpot[] ParkingSpots { get; set; } = new ParkingSpot[Configdata.ParkingLotSize]; // Hämtar Listan med alla platser 

        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>(Configdata.ParkingLotSize); // Skapar en till lista som innehåller fordon
        public ParkingHouse()
        {
            GenerateParkinglot(); // Genererar parkeringsplatser
        }
        public static void GenerateParkinglot() // Skapar metoden för att skapa parkeringsplatser 
        {
            for (int i = 0; i < Configdata.ParkingLotSize; i++)
            {
                ParkingSpots[i] = (new ParkingSpot());
            }

        }

        public static (Vehicle, ParkingSpot) FindVehicleSpot(string searchReg) // Metod som kontrollerar parkeringsplatsen om det finns ett fordon där eller inte
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                foreach (Vehicle vehicle in Vehicles)
                {
                    if (vehicle.RegNumber == searchReg && spot.SpotNumber == vehicle.ParkedOnSpot)
                    {
                        return (vehicle, spot);
                    }
                    continue;
                }
            }
            return (null, null);

        }
        public static ParkingSpot FreeSpot(int vehicleSize, int newSpot) // Skapar en ny plats för fordon - parkerar fordonet på den platsen
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.SpotNumber == newSpot)
                {
                    if (spot.ParkingSpotSize >= vehicleSize)
                    {
                        return spot;
                    }
                    return null;
                }
            }
            return null;
        }

        public static ParkingSpot CheckparkingLotSpace() // Kollar parkeringsplatsen
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.ParkingSpotSize != 4)
                {
                    continue;
                }
                else
                {
                    return spot;
                }
            }
            return null;

        }
        public static ParkingSpot FindParkedAtSpot(Vehicle vehcile) // Används till MoveVehicle. Om det finns ett fordon där, då visas ett felmeddelande
        {

            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.SpotNumber == vehcile.ParkedOnSpot)
                {
                    return spot;
                }
            }
            return null;
        }

        public static void PrintParkingLot() // Printar ut parkingsplatsen. Grön = tom plats, gul = platsen innehåller ett fordon och röd 
        {
            Table t1 = new Table();
            t1.AddColumns("[grey]EMPTY SPOT =[/] [green]GREEN[/]", "[grey]FULL SPOT =[/] [red]RED[/]", "[grey]HAlF FULL =[/] [yellow]YELLOW[/]").Centered().Alignment(Justify.Center);
            AnsiConsole.Write(t1);

            Table newTable = new Table().Centered();
            var parkingSpotColorMarking = String.Empty;
            var printResult = String.Empty;
            int emptySpots;

            for (int i = 0; i < Configdata.ParkingLotSize; i++)
            {
                if (ParkingHouse.ParkingSpots[i].ParkingSpotSize == 4)
                {
                    emptySpots = ParkingSpots[i].ParkingSpotSize;
                    
                    parkingSpotColorMarking = "green";
                }
                else if (ParkingHouse.ParkingSpots[i].ParkingSpotSize == 2)
                {
                    emptySpots = ParkingSpots[i].ParkingSpotSize;
                    parkingSpotColorMarking = "yellow";
                }

                else
                {
                    emptySpots = ParkingSpots[i].ParkingSpotSize;
                    parkingSpotColorMarking = "red";
                }

                printResult += ($"[{parkingSpotColorMarking}] {i + 1}[/] ");
            }
            newTable.AddColumn(new TableColumn(printResult));
            AnsiConsole.Write(newTable);
            var menu = new Table();
            menu.AddColumn(new TableColumn("Choose option below").Centered()).Alignment(Justify.Left);
            AnsiConsole.Write(menu);
        }

        public static void ErrorMsg() // Skriver ut ett felmeddelande ifall använder har skrivit in fel
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error - Please make sure your input is correctly entered and try again!");
            Console.ReadKey();
            Console.ResetColor();
        }

        public static void ClearParkinglot() // Rensar hela Listan
        {
            Vehicles.Clear();
            foreach (ParkingSpot spot in ParkingSpots)
            {
                spot.ParkingSpotSize = Configdata.ParkingspotSize;
            }
        }
    }
}



