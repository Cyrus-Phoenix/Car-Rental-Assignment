using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using System.Runtime.InteropServices;

namespace Car_Rental.Common.Classes;

public class Booking : IBookings
{
    public int Id { get; set; }
    //public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int Cost { get; set; }
    public int Km { get; set; }
    public DateTime days { get; set; }
    public VehicleStatuses VStatus { get; set; }

    List<Booking> bookings = new();

   // public Booking(int id, int cost, DateTime end, DateTime start, VehicleStatuses vStatus) => (Id, Cost, Start, End,  VStatus) = (id, cost, start, end, vStatus);
    public Booking(int id, VehicleStatuses vStatus) => (Id,  VStatus) = (id, vStatus);
    


    void BookVechile()
    {

        Start = DateTime.Now; //Or if I want to code it DateTime start = new DateTime(2010, 6, 14);
        VStatus = VehicleStatuses.Booked;
        //  bookings.Add(new Booking(1, "John Doe", (VehicleStatuses)1));

        
    }

    void ReturnVehicle(IVehicle vehicle) {

        End = DateTime.Now;
        TimeSpan days = End - Start;
        int totaldays = Int32.Parse(days.ToString());

        Cost = totaldays * vehicle.CostDay + Km * vehicle.CostKm;

        VStatus = VehicleStatuses.Available;

        // Assign values to the class' properties with values from the vehicle parameter
        // Cost = days * vehicle.CostDay + km * vehicle.CostKm;

    }


}
