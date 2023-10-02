using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Runtime.InteropServices;

namespace Car_Rental.Common.Classes;

internal class Booking : IBookings
{
    public int Id { get; set; }
    //public string Name { get; set; }
    DateTime DNow { get; set; }
    DateTime DReturned { get; set; }
    public int Cost { get; set; }

    public DateTime days { get; set; }


    public VehicleStatuses VStatus { get; set; }

    List<Booking> bookings = new();

    public Booking(int id, int cost, DateTime dNow, DateTime dReturn, VehicleStatuses vStatus) => (Id, Cost, DNow, DReturned,  VStatus) = (id, cost, dNow, dReturn, vStatus);
    


    void Book()
    {
        DateTime now = DateTime.Now;
        VStatus = (VehicleStatuses)1;
      //  bookings.Add(new Booking(1, "John Doe", (VehicleStatuses)1));
    }

    void ReturnVehicle(IVehicle vehicle) {



       // Cost = days * vehicle.CostDay + km * vehicle.CostKm;

    }

    void ReturnVehicle()
    {
        // Assign values to the class' properties with values from the vehicle parameter
        // Cost = days * vehicle.CostDay + km * vehicle.CostKm;
    }


}
