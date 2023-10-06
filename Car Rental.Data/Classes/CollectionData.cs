using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;

using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;

namespace Car_Rental.Data.Classes;

/*
 Have to contain all the Data
 */
public class CollectionData : IData
{
    List<IVehicle> _vehicles = new();
    List<ICustomer> _customers = new();
    List<IBookings> _bookings = new();


    DateTime start = new DateTime(2010, 6, 14);
    DateTime end = new DateTime(2010, 6, 16);
    int kmReturned = 500;
    

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

        #region Booking

        var b1 = new Booking(1, customer1.FName+ customer1.LName, vehicle1.VehicleMake, vehicle1.CostKm, vehicle1.Odometer, kmReturned, start, end, vehicle1.VStatus=VehicleStatuses.Booked);
        _bookings.Add(b1);

        #endregion
    }

    public book
    


    public IEnumerable<ICustomer> GetCustomers()=> _customers;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
   
    public IEnumerable<IBookings> GetBookings() => _bookings; 



}