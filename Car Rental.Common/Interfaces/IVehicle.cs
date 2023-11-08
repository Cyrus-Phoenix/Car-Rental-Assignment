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

         int Id { get; init; }

         string RegNo { get; set; }

         VehiclesMake VehicleMake { get; }

         VehiclesTypes VehicleType { get; }

         double Odometer { get; set; }

         double CostKm { get; set; }

         double CostDay { get; set; }

        VehicleStatuses VStatus { get; }

        void StatusSwitch(VehicleStatuses status);

    }
}
