using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Motorcycle : IVehicle
{

    public int Id { get; set; }

    public string RegNo { get; set; }

    public VehiclesMake VehicleMake { get; set; }

    public VehiclesTypes VehicleType { get; set; }

    public int Odometer { get; set; }

    public int CostKm { get; set; }

    public int CostDay { get; set; }

    public VehicleStatuses VStatus { get; set; }

    #region With VehicleStatuses

    public Motorcycle(int id, string regNo, VehiclesMake vMake, VehiclesTypes vType, int odometer, int costKm, int costDay, VehicleStatuses vStatus)
     => (Id, RegNo, VehicleMake, VehicleType, Odometer, CostKm, CostDay, VStatus) = (id, regNo, vMake, vType, odometer, costKm, costDay, vStatus);
    #endregion

    #region Without VehicleStatuses    
    //public Motorcycle(int id, string regNo, VehiclesMake vMake, VehiclesTypes vType, int odometer, int costKm, int costDay)
    //=> (Id, RegNo, VehicleMake, VehicleType, Odometer, CostKm, CostDay) = (id, regNo, vMake, vType, odometer, costKm, costDay);
    #endregion





}
