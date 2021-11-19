using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PragueParking2._0
{
    class Car : Vehicle
    {

        // Ger alla egenskaper till fordonet
        public Car(string aRegNumber) : base(aRegNumber)
        {
            VehSize = Configdata.CarSize;
            VehType = "CAR";
            ParkTime = DateTime.Now;
            vehCost = Configdata.CarPrice;
        }
        public Car(string aRegNumber, int spotNumber, DateTime parkTime) : base(aRegNumber)
        {
            ParkedOnSpot = spotNumber;
            ParkTime = parkTime;
            VehSize = Configdata.CarSize;
            VehType = "CAR";
            ParkTime = parkTime;
            vehCost = Configdata.CarPrice;
        }
    }
}
