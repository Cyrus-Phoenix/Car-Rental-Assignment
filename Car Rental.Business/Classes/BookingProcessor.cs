using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{

    // Experiement processor 

    IData _db;

    public BookingProcessor(IData data)
    {
        _db = data;
    }


    public IEnumerable<ICustomer> GetCustomers() => _db.GetCustomers().OrderBy(c => c.LastName);
    public IEnumerable<IVehicle> GetVehicles() => _db.GetVehicles();
    public IEnumerable<IBooking> GetBookings() => _db.GetBookings();




}
