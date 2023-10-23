namespace Car_Rental.Common.Classes;

using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Reflection.Metadata.Ecma335;

/*
 Should contain all the Classes, Constructs, Enums etc
 that can be access from all the projekts.
 */

public class Car : Vehicle
{
    /* 
     * Just for inheritance example
     * In this case makes no sense to have this.
     */
    public int CarID { get; set; }

    #region With VehicleStatuses

    public Car(int id, string regNo, VehiclesMake vmake, VehiclesTypes vType, int odometer, int costKm, int costDay, VehicleStatuses vStatus)
    : base(id, regNo, vmake, vType, odometer, costKm, costDay, vStatus) { }

    public Car(int carId, int id, string regNo, VehiclesMake vmake, VehiclesTypes vType, int odometer, int costKm, int costDay, VehicleStatuses vStatus)
    : base(id, regNo, vmake, vType, odometer, costKm, costDay, vStatus) => (carId) = (CarID);


    #endregion

    #region Without VehicleStatuses

    //public Car(int id, string regNo, VehiclesMake vmake, VehiclesTypes vType, int odometer, int costKm, int costDay)
    //=> (Id, RegNo, VehicleMake, VehicleType, Odometer, CostKm, CostDay) = (id, regNo, vmake, vType, odometer, costKm, costDay);


    #endregion


}