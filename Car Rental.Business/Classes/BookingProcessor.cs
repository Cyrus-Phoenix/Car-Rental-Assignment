using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    #region Variabel & Constructor
    
    private readonly IData _db;
    public BookingProcessor(IData data) => _db = data;

    #endregion


    #region Customer

    public IEnumerable<ICustomer> GetCustomers() => _db.GetCustomers().OrderBy(c => c.LastName);
    public ICustomer? GetCustomer(int ssn) => _db.Single<ICustomer>(c => c.Id.Equals(ssn));

    public void AddCustomer(int socialSecurityNumber, string firstName, string
    lastName)
    {

        _db.Add<ICustomer>(new Customer(_db.NewCustomerId, socialSecurityNumber, firstName, lastName));
       
    }


    #endregion
    


    #region Vehicles

    public void AddVehicle(VehiclesMake make, string registrationNumber, double
    odometer, double costKm, VehicleStatuses status, VehiclesTypes type)
    {
        


    }


    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _db.GetVehicles();
    
    public IVehicle? GetVehicle(int vehicleId) { 
        return (IVehicle?)GetVehicles(); 
    }
    public IVehicle? GetVehicle(string regNo) { 
        return (IVehicle)GetVehicles(); 
    }

    #endregion




    //public lägg till asynkron returdata typ RentVehicle(int vehicleId, int
    // customerId)
    //{
    //    // Använd Task.Delay för att simulera tiden det tar 
    //    // att hämta data från ett API.
    //}

    // public IBooking ReturnVehicle(int vehicleId, double ditance) { }

    
    // Calling Default Interface Methods
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public string[] VehicleMakeNames => _db.VehicleMakeNames;
    public VehiclesTypes GetVehiclesType(string name) => _db.GetVehicleType(name);
    public VehiclesMake GetVehiclesMake(string name) => _db.GetVehicleMake(name);


  
  // public IEnumerable<IBooking> GetBookings() => _db.GetBookings();




}
