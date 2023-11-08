using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{

    public int Id { get; set; }
    public ICustomer Person { get; }
    public IVehicle Vehicle { get; }
    public string RegNo { get; }
    public DateTime Start { get; init; }
    public DateTime? End { get; init; }
    public double Cost { get; init; }
    public double KmRented { get; init; }
    public double KmReturned { get; set; }
    public DateTime days { get; init; }
    // public VehicleStatuses VStatus { get; init; }



    #region Constructors

    public Booking(){}

    public Booking(int id, ICustomer customer, IVehicle vehicle,   /*int customerSSN,  string customer, string regNo, VehiclesMake vehiclesMake,*/ double cost, /*int kmRented,*/ double kmReturned, DateTime start, DateTime end, VehicleStatuses vStatus)
    => (Id, Person, Vehicle, /*CustomerSSN, Customer, RegNo, VehiclesMake,*/ Cost, /* KmRented, */ KmReturned, Start, End/*, VStatus*/)
    = (id, customer, vehicle, /*customerSSN, customer, regNo, vehiclesMake,*/ cost, /* kmRented, */  kmReturned, start, end/*, VStatus*/);

    public Booking(int id, ICustomer customer, IVehicle vehicle)
    {
        Id = id;
        Person = customer;
        Vehicle = vehicle;
        RegNo = vehicle.RegNo;
        Start = DateTime.Now;
        KmRented = vehicle.Odometer;
        //VStatus = VehicleStatuses.Booked;

        //TODO : Varför behövde jag göra en metod för detta? Kort sagt varför fungera inte det ovan? Är det för att den sätter en ny status på själva bookingen?
        vehicle.StatusSwitch(VehicleStatuses.Booked);
    }

    #endregion







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
