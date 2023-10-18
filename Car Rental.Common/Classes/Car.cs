namespace Car_Rental.Common.Classes;

using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

/*
 Should contain all the Classes, Constructs, Enums etc
 that can be access from all the projekts.
 */

public class Car : IVehicle
{
    public int Id { get; init; }

    public string RegNo { get; init; }

    public VehiclesMake VehicleMake { get; }

    public VehiclesTypes VehicleType { get; }

    public int Odometer { get; init; }

    public int CostKm { get; init; }

    public int CostDay { get; init; }

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