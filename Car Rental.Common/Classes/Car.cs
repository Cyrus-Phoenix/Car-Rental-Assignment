namespace Car_Rental.Common.Classes;

using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

/*
 Should contain all the Classes, Constructs, Enums etc
 that can be access from all the projekts.
 */

public class Car : IVehicle
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

    public Car(int id, string regNo, VehiclesMake vmake, VehiclesTypes vType, int odometer, int costKm, int costDay, VehicleStatuses vStatus)
    => (Id, RegNo, VehicleMake, VehicleType, Odometer, CostKm, CostDay, VStatus) = (id, regNo, vmake, vType, odometer, costKm, costDay, vStatus);


    #endregion

    #region Without VehicleStatuses

    //public Car(int id, string regNo, VehiclesMake vmake, VehiclesTypes vType, int odometer, int costKm, int costDay)
    //=> (Id, RegNo, VehicleMake, VehicleType, Odometer, CostKm, CostDay) = (id, regNo, vmake, vType, odometer, costKm, costDay);


    #endregion


}