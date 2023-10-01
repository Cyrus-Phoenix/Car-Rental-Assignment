using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

internal class Motorcycle : IVehicles
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
