using Car_Rental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IVehicle
    {

        public int Id { get; init; }

        public string RegNo { get; set; }

        public VehiclesMake VehicleMake { get; }

        public VehiclesTypes VehicleType { get; }

        public double Odometer { get; set; }

        public double CostKm { get; set; }

        public double CostDay { get; set; }

        public VehicleStatuses VStatus { get; }



    }
}
