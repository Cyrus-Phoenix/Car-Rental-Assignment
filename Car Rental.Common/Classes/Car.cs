namespace Car_Rental.Common.Classes;

using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

/*
 Should contain all the Classes, Constructs, Enums etc
 that can be access from all the projekts.
 */

public class Car : IVehicles
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