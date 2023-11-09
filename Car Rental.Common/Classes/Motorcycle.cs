using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{

    /* 
    * Just a inheritance example
    * In this case it makes no sense to have this property.
    */

    int McID {  get; init; }

    #region Constructors
    public Motorcycle(int id, string regNo, VehiclesMake vMake, VehiclesTypes vType, double odometer, double costKm, double costDay, VehicleStatuses vStatus)
        : base( id, regNo, vMake, vType, odometer, costKm, costDay, vStatus ) { }

    public Motorcycle( int mcid, int id, string regNo, VehiclesMake vMake, VehiclesTypes vType, double odometer, double costKm, double costDay, VehicleStatuses vStatus)
      : base(id, regNo, vMake, vType, odometer, costKm, costDay, vStatus) { McID = mcid; }

    #endregion



}
