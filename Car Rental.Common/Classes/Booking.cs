using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace Car_Rental.Common.Classes;

public class Booking : IBookings
{
    public int Id { get; set; }
    public string Name { get; set; }
    public VehiclesMake VehiclesMake { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int Cost { get; set; }
    public int KmRented { get; set; }
    public int KmReturned { get; set; }
    public DateTime days { get; set; }
    public VehicleStatuses VStatus { get; set; }

    List<Booking> bookings = new();
    
    //Original
    //public Booking(int id, int cost, DateTime end, DateTime start, VehicleStatuses vStatus) => (Id, Cost, Start, End,  VStatus) = (id, cost, start, end, vStatus);
    
    // Temporary
    public Booking(int id, string name, VehiclesMake vehiclesMake, int cost, int kmRented, int kmReturned, DateTime end, DateTime start, VehicleStatuses vStatus) => (Id, Name, VehiclesMake, Cost, KmRented, KmReturned, Start, End,  VStatus) = (id, name, vehiclesMake, cost, kmRented, kmReturned, start, end, vStatus);
   // public Booking(int id, VehicleStatuses vStatus) => (Id,  VStatus) = (id, vStatus);
    


    void BookVechile()
    {

        Start = DateTime.Now; //Or if I want to code it DateTime start = new DateTime(2010, 6, 14);
        VStatus = VehicleStatuses.Booked;
        //  bookings.Add(new Booking(1, "John Doe", (VehicleStatuses)1));

        
    }

    void ReturnVehicle(IVehicle vehicle) 
    {

        // End = DateTime.Now;
        TimeSpan days = End - Start;
        int totalDays = Int32.Parse(days.ToString());

        int DifferenceKm = KmRented - KmReturned; 

        Cost = totalDays * vehicle.CostDay + DifferenceKm * vehicle.CostKm;

        int newTotalKm = KmRented + KmReturned;

        KmRented = newTotalKm;

        VStatus = VehicleStatuses.Available;

        // Assign values to the class' properties with values from the vehicle parameter
        // Cost = days * vehicle.CostDay + km * vehicle.CostKm;

    }


}
