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

        public int Id { get; set; }

        public string RegNo { get; set; }

        public VehiclesMake VehicleMake { get; set; }

        public VehiclesTypes VehicleType { get; set; }

        public int Odometer { get; set; }

        public int CostKm { get; set; }

        public int CostDay { get; set; }

        public VehicleStatuses VStatus { get; set; }

    }
}
