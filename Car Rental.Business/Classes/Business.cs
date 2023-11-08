using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;

namespace Car_Rental.Business.Classes;

/*
 Business logic ( validation logic if a vehicle is booked or not )
 To do the logic it should have access to the data in " Car Rental.Data " project.
 */
public class Business
{
    IData _data;

    public Business(IData data)
    {
        _data = data;
    }

    //public IEnumerable<ICustomer> GetCustomers() => _data.GetCustomers();
    //public IEnumerable<IVehicle> GetVehicles() => _data.GetVehicles();
    //public IEnumerable<IBooking> GetBookings() => _data.GetBookings();




    // IEnumerable <ICustomer> GetCustomers();
    // IEnumerable <IVechile> GetVechicles();
    // IEnumerable <IBooking> GetBookings();

}