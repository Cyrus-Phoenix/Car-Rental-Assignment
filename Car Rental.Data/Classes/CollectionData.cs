using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;

using System.Reflection.Metadata.Ecma335;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Car_Rental.Data.Classes;

/*
 Have to contain all the Data
 */
public class CollectionData : IData
{
    List<IVehicle> _vehicles = new();
    List<ICustomer> _customers = new();
    List<IBookings> _bookings = new();

    #region Booking timers







    // static DateTime dNow = DateTime.Now;


    #endregion


    int numberOfDays;
    int kmReturned;
    DateTime startBook;
    DateTime endBook;




    public CollectionData()
    {
        #region With VehicleStatuses

        var vehicle1 = new Car(1, "ABC 123", (VehiclesMake)1, VehiclesTypes.Sedan, 5500, 10, 250, VehicleStatuses.Available);
        var vehicle2 = new Car(2, "ABC 345", VehiclesMake.BMW, VehiclesTypes.Combi, 8500, 5, 140, VehicleStatuses.Available);
        var vehicle3 = new Motorcycle(1, "DEF 123", (VehiclesMake)3, VehiclesTypes.Motorcycle, 500, 50, 300, VehicleStatuses.Available);
        var vehicle4 = new Motorcycle(2, "DEF 345", VehiclesMake.VW, VehiclesTypes.Motorcycle, 2500, 2, 80, VehicleStatuses.Available);

        _vehicles.Add(vehicle1);
        _vehicles.Add(vehicle2);
        _vehicles.Add(vehicle3);
        _vehicles.Add(vehicle4);

        #endregion

       



        #region Without VehicleStatuses 

        //_vehicles.Add(new Car(1, "ABC 123", (VehiclesMake)1, VehiclesTypes.Sedan, 5500, 10, 250));
        //_vehicles.Add(new Car(2, "ABC 345", VehiclesMake.BMW, VehiclesTypes.Combi, 8500, 5, 140));
        //_vehicles.Add(new Motorcycle(1, "DEF 123", (VehiclesMake)3, VehiclesTypes.Motorcycle, 500, 50, 300));
        //_vehicles.Add(new Motorcycle(2, "DEF 345", VehiclesMake.VW, VehiclesTypes.Motorcycle, 2500, 2, 80));

        #endregion


        #region Customers

        var customer1 = new Customer(2345, "John", "Doe");
        var customer2 = new Customer(5678, "Lucky", "Luke");
        var customer3 = new Customer(9012, "John", "Snow");
        var customer4 = new Customer(3456, "Louise", "Lane");

        _customers.Add(customer1);
        _customers.Add(customer2);
        _customers.Add(customer3);
        _customers.Add(customer4);


        #endregion



        // Assign values to the class' properties with values from the vehicle parameter
        // Cost = days * vehicle.CostDay + km * vehicle.CostKm;

        #region Booking

        
        
        (DateTime startBook1, DateTime endBook1) = BookTime(new DateTime(2023, 6, 12), new DateTime(2023, 6, 13));
        numberOfDays = DaysBooked(startBook1, endBook1);
        int kmReturned1 = KmAmount(400);
        var cost1 = calc(vehicle1, endBook1);

        var b1 = new Booking(
                            1,
                            customer1.FName + " " + customer1.LName,
                            vehicle1.VehicleMake,
                            cost1,
                            vehicle1.Odometer,
                            kmReturned1 + vehicle1.Odometer,
                            startBook1,
                            endBook1,
                            vehicle1.VStatus = VehicleStatuses.Available
                            ) ;
        _bookings.Add(b1);

        


        (DateTime startBook2, DateTime endBook2) = BookTime(new DateTime(2023, 6, 12), DateTime.MinValue);
        numberOfDays = DaysBooked(startBook2, endBook2);
        int kmReturned2 = KmAmount(0);
        var cost2 = calc(vehicle1, endBook2);
        var b2 = new Booking
            (
                           2,
                           customer2.FName + " " + customer2.LName,
                           vehicle2.VehicleMake,
                           cost2,
                           vehicle2.Odometer,
                           kmReturned2 + vehicle2.Odometer,
                           startBook2,
                           endBook2,
                           vehicle1.VStatus = VehicleStatuses.Booked
             ) ;
        _bookings.Add(b2);

        


        #endregion
    }


    int KmAmount(int km)
    {
        kmReturned = km;
        return kmReturned;
    }


    (DateTime, DateTime) BookTime(DateTime startingDate, DateTime endingDate) 
    { 
        startBook = startingDate;
        endBook = endingDate;
        return (startingDate, endingDate);
    }




    int DaysBooked(DateTime startBook, DateTime endBook)
    {
        TimeSpan days = startBook - endBook;
        int totalDays = days.Days;
        return totalDays;
    }

    int calc(IVehicle vehicle, DateTime endBook)
    {
       
        int cost = 0;
        
        if ( endBook == DateTime.MinValue )
        {
            return cost;
        }
        cost = (numberOfDays * vehicle.CostDay) + (kmReturned * vehicle.CostKm);
        return cost;

    }







    public IEnumerable<ICustomer> GetCustomers()=> _customers;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
   
    public IEnumerable<IBookings> GetBookings() => _bookings; 



}