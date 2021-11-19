using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{

    // Skapar alla properties till fordonet
    class Vehicle
    {
        public string RegNumber { get; set; }
        public int VehSize { get; set; }
        public string VehType { get; set; }
        public DateTime ParkTime { get; set; }
        public int ParkedOnSpot { get; set; }
        public int vehCost { get; set; }

        public Vehicle(string aRegNumber)
        {
            this.RegNumber = aRegNumber;

        }
    }
}
