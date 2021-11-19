using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class MC : Vehicle
    {

        // Ger alla egenskaper till fordonet 

        public MC(string aRegNumber) : base(aRegNumber)
        {

            VehSize = Configdata.McSize; 
            VehType = "MC";
            ParkTime = DateTime.Now;
            vehCost = Configdata.McPrice;
        }
        public MC(string aRegNumber, int spotNumber, DateTime parkTime) : base(aRegNumber)
        {
            ParkedOnSpot = spotNumber;
            VehSize = Configdata.CarSize;
            VehType = "MC";
            vehCost = Configdata.McPrice;
        }

    }
  }

