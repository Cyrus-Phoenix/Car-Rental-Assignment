using Car_Rental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IVehicles
    {

        public int Id { get; set; }

        public int RegNo { get; set; }

        public int Make { get; set; }

        public VehiclesTypes VehicleType { get; set; }

        public int Odometer { get; set; }

        public int CostKm { get; set; }

        public int CostDay { get; set; }

        public VehicleStatuses Status { get; set; }

    }
}
