using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace PragueParking2._0
{
    public class Mainmenu
    {

        public static void MainMenu() // Primära menyn som visar användaren alternativen
        {
            string menuChoice;

            do
            {
                Console.Clear();
                var table = new Table();
                table.AddColumn("PRAGUE PARKING V2").Centered();

                AnsiConsole.Write(table);
                ParkingHouse.PrintParkingLot();
                menuChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                  .AddChoices(new[] { "Park vehicle", "Remove Vehicle", "Move Vehicle", "Show Parked Vehicles", "Search Vehicle", "Clear parkinglot", "Exit Program" }));

                if (menuChoice == "Exit Program") // Stänger ner programmet
                {
                    Environment.Exit(1);
                }
                if (menuChoice == "Show Parked Vehicles") // Printar ut parkeringshuset + alla fordon som är parkerade
                {
                    ParkingHouse.PrintParkingLot();
                    ParkingSpot.ShowVehicles();
                }
                if (menuChoice == "Clear parkinglot") // Tar bort alla fordon i parkeringshuset
                {
                    ParkingHouse.ClearParkinglot();

                }
                else if (ParkVehicle.ValidRegnum(out string licensplate))
                {
                    switch (menuChoice)
                    {
                        case "Park vehicle":

                            menuChoice = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(new[] { "CAR", "MC" })); // Lägger till Bil eller MC
                            if (menuChoice == "CAR")
                            {
                                ParkVehicle.AddVehicle(menuChoice, licensplate);
                            }
                            else
                            {
                                ParkVehicle.AddVehicle(menuChoice, licensplate);
                            }
                            break;
                        case "Remove Vehicle":
                            RemoveVehicle.CheckoutVehicle(licensplate);
                            break;
                        case "Move Vehicle":
                            MoveVehicle.Move(licensplate);
                            break;
                        case "Search Vehicle":
                            SearchVehicle.SearchForVehicle(licensplate);
                            break;
                    }
                }
                else
                {
                    ParkingHouse.ErrorMsg(); // Visar felmeddelande
                }

            } while (menuChoice != "Exit Program");
        }
    }
}






