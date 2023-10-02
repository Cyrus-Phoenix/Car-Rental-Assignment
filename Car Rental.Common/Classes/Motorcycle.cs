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

    //  public VehicleStatuses Status { get; set; }

    public Motorcycle(int id, string regNo, VehiclesMake vmake, VehiclesTypes vtype, int odometer, int costkm, int costday)
     => (Id, RegNo, VehicleMake, VehicleType, Odometer, CostKm, CostDay) = (id, regNo, vmake, vtype, odometer, costkm, costday);



}
