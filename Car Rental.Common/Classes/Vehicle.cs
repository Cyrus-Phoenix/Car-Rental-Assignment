using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;


namespace Car_Rental.Common.Classes
{
    public class Vehicle : IVehicle
    {
        #region Properties
        public int Id { get; init; }

        public string RegNo { get; set; }

        public VehiclesMake VehicleMake { get; set; }

        public VehiclesTypes VehicleType { get; set; }

        public double Odometer { get; set; }

        public double CostKm { get; set; }

        public double CostDay { get; set; }

        public VehicleStatuses VStatus { get; set; }
        #endregion

        #region Constructors
        public Vehicle()
        {
            
        }

        public Vehicle(int id, string regNo, VehiclesMake vMake, VehiclesTypes vType, double odometer, double costKm, double costDay, VehicleStatuses vStatus)
         => (Id, RegNo, VehicleMake, VehicleType, Odometer, CostKm, CostDay, VStatus) = (id, regNo, vMake, vType, odometer, costKm, costDay, vStatus);

        #endregion

        #region Methods



        #endregion

    }
}
