using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using System.Runtime.InteropServices;

namespace Car_Rental.Common.Classes;

public class Booking : IBookings
{
    public int Id { get; set; }
    public int CustomerSSN { get; }
    public string Customer { get; }
    public string RegNo { get; }
    public VehiclesMake VehiclesMake { get; }
    public DateTime Start { get; init; }
    public DateTime? End { get; init; }
    public int Cost { get; init; }
    public int KmRented { get; init; }
    public int KmReturned { get; init; }
    public DateTime days { get; init; }
    public VehicleStatuses VStatus { get; init; }

    
    public Booking(int id, int customerSSN,  string customer, string regNo, VehiclesMake vehiclesMake, int cost, int kmRented, int kmReturned, DateTime start, DateTime end, VehicleStatuses vStatus)
   => (Id, CustomerSSN, Customer, RegNo, VehiclesMake, Cost, KmRented, KmReturned, Start, End, VStatus)
    = (id, customerSSN, customer, regNo, vehiclesMake, cost, kmRented, kmReturned, start, end, vStatus);

    #region Ut kommenterade saker

    // List<Booking> bookings = new();

    //void BookVechile()
    //{

    //    Start = DateTime.Now; //Or if I want to code it DateTime start = new DateTime(2010, 6, 14);
    //    VStatus = VehicleStatuses.Booked;
    //    //  bookings.Add(new Booking(1, "John Doe", (VehicleStatuses)1));


    //}

    //  void ReturnVehicle(IVehicle vehicle) {

    //    // TimeSpan days = End - Start;
    //    int totalDays = Int32.Parse(days.ToString());

    //    int DifferenceKm = KmRented - KmReturned;

    //    Cost = totalDays * vehicle.CostDay + DifferenceKm * vehicle.CostKm;

    //    int newTotalKm = KmRented + KmReturned;

    //    KmRented = newTotalKm;

    //    VStatus = VehicleStatuses.Available;



    //    // Assign values to the class' properties with values from the vehicle parameter
    //    // Cost = days * vehicle.CostDay + km * vehicle.CostKm;

    //}
    #endregion



}
