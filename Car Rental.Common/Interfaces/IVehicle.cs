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

        public string RegNo { get; init; }

        public VehiclesMake VehicleMake { get; }

        public VehiclesTypes VehicleType { get; }

        public int Odometer { get; init; }

        public int CostKm { get; init; }

        public int CostDay { get; init; }

        public VehicleStatuses VStatus { get; set; }

    }
}
