using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Spectre.Console;

namespace PragueParking2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Configdata.ReadSizeFile(); // Läser in alla parkeringsplateser
            ParkingHouse parkingHouse = new ParkingHouse(); // Läser in parkeringshuset
            Configdata.ReadParkingFile(); // Läser in alla parkerade fordon
            Mainmenu.MainMenu(); // Kör menyn konstant tills användaren väljer att lämna
        }
        
    }
}
