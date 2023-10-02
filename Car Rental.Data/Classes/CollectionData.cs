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

    public CollectionData()
    {

        _vehicles.Add(new Car(1, "ABC 123", (VehiclesMake)1, (VehiclesTypes)2, 5500, 10, 250));
        _vehicles.Add(new Car(2, "ABC 345", (VehiclesMake)2, (VehiclesTypes)1, 8500, 5, 140));
        _vehicles.Add(new Motorcycle(1, "DEF 345", (VehiclesMake)3, (VehiclesTypes)4, 500, 50, 300));
        _vehicles.Add(new Motorcycle(2, "EFG 345", (VehiclesMake)4, (VehiclesTypes)4, 2500, 2, 80));


        _customers.Add(new Customer(2345, "John", "Doe"));
        _customers.Add(new Customer(5234, "Jimmy", "Shoe"));
        _customers.Add(new Customer(6666, "Jimmy", "Shoe"));
        _customers.Add(new Customer(7543, "Stina", "Stinsson"));
        _customers.Add(new Customer(4753, "Alba", "Albatrauson"));


    }

   

 

    public List<ICustomer> GetCustomers()=> _customers;
    public List<IVehicle> GetVehicles()=> _vehicles;






}