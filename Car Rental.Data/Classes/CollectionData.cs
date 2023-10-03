using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;

using System.Reflection.Metadata.Ecma335;

namespace Car_Rental.Data.Classes;

/*
 Have to contain all the Data
 */
public class CollectionData : IData
{
    List<IVehicle> _vehicles = new();
    List<ICustomer> _customers = new();
    List<IBookings> _bookings = new();
    

    public CollectionData()
    {
        #region With VehicleStatuses

        _vehicles.Add(new Car(1, "ABC 123", (VehiclesMake)1, VehiclesTypes.Sedan, 5500, 10, 250, VehicleStatuses.Booked));
        _vehicles.Add(new Car(2, "ABC 345", VehiclesMake.BMW, VehiclesTypes.Combi, 8500, 5, 140, VehicleStatuses.Available));
        _vehicles.Add(new Motorcycle(1, "DEF 123", (VehiclesMake)3, VehiclesTypes.Motorcycle, 500, 50, 300, VehicleStatuses.Booked));
        _vehicles.Add(new Motorcycle(2, "DEF 345", VehiclesMake.VW, VehiclesTypes.Motorcycle, 2500, 2, 80, VehicleStatuses.Available));

        #endregion

        #region Without VehicleStatuses 

        //_vehicles.Add(new Car(1, "ABC 123", (VehiclesMake)1, VehiclesTypes.Sedan, 5500, 10, 250));
        //_vehicles.Add(new Car(2, "ABC 345", VehiclesMake.BMW, VehiclesTypes.Combi, 8500, 5, 140));
        //_vehicles.Add(new Motorcycle(1, "DEF 123", (VehiclesMake)3, VehiclesTypes.Motorcycle, 500, 50, 300));
        //_vehicles.Add(new Motorcycle(2, "DEF 345", VehiclesMake.VW, VehiclesTypes.Motorcycle, 2500, 2, 80));

        #endregion


        #region Customers

        _customers.Add(new Customer(2345, "John", "Doe"));
        _customers.Add(new Customer(5234, "Jimmy", "Shoe"));
        _customers.Add(new Customer(6666, "Jimmy", "Shoe"));
        _customers.Add(new Customer(7543, "Stina", "Stinsson"));
        _customers.Add(new Customer(4753, "Alba", "Albatrauson"));

        #endregion

         
    }
    

    

 
    public IEnumerable<ICustomer> GetCustomers()=> _customers;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
   
    public IEnumerable<IBookings> GetBookings() => _bookings; 



}