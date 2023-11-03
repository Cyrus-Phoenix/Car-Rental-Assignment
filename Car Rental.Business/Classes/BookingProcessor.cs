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

    #region Props
    public string ErrorMessage { get; set; } = string.Empty; //Om den inte sätts till empty blir den null per default.
    #endregion





    //public Booking NewBooking = new();


    #region Customer

    //TODO : Varför gick det inte att skapa ny instans/object utav customer utan att skapa tom konstruktor

    public Customer NewCustomer = new();




    public IEnumerable<ICustomer> GetCustomers() => _db.GetCustomers().OrderBy(c => c.LastName);
    public ICustomer? GetCustomer(int ssn) => _db.Single<ICustomer>(c => c.Id.Equals(ssn));

    public void AddCustomer(string socialSecurityNumber, string firstName, string
    lastName)
    {
         ErrorMessage = string.Empty;
         socialSecurityNumber = socialSecurityNumber ?? string.Empty; 
         firstName = firstName ?? string.Empty; 
         lastName = lastName ?? string.Empty;

        if(socialSecurityNumber.Trim().Length.Equals(0) || socialSecurityNumber.Trim().Length != 6 || socialSecurityNumber == default 
            || firstName.Trim().Length.Equals(0) || lastName.Trim().Length.Equals(0) || firstName == default || lastName == default )
        {
            ErrorMessage = "Could not add customer: One of the fields seems to be empty";
            
            if (socialSecurityNumber == default || socialSecurityNumber.Length != 6)
            {
                ErrorMessage += ": Invalid Social Security Number or Wrong Fromat ( YYMMDD )";
                NewCustomer.SocialSecurityNumber = string.Empty;
            }
        }
        else
        {
            _db.Add<ICustomer>(new Customer(_db.NewCustomerId, socialSecurityNumber, firstName, lastName));
            NewCustomer = new();
        }
        
    }


    #endregion



    #region Vehicles
    public Vehicle NewVehicle = new();
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _db.GetVehicles();
    public IVehicle? GetVehicle(int vehicleId) => _db.Single<IVehicle>(v => v.Id.Equals(vehicleId));
    public IVehicle? GetVehicle(string regNo) => _db.Single<IVehicle>(v => v.RegNo.Equals(regNo));
    public void AddVehicle(VehiclesMake make, string registrationNumber, double
    odometer, double costKm, double costDay, VehicleStatuses status, VehiclesTypes type)
    {
        
        ErrorMessage = string.Empty;
        registrationNumber = registrationNumber.ToUpper();

        try
        {
            if (registrationNumber.Trim().Length.Equals(0) || registrationNumber.Trim().Length != 6 || registrationNumber == default
              || make == default || costKm == default || type == default)
            {
                ErrorMessage = "Couldn't add Vechicle: One of the fields seems to be missing information";
            }
            else
            { 
                if(type is VehiclesTypes.Motorcycle)
                _db.Add<IVehicle>(new Motorcycle(_db.NewVehicleId,  registrationNumber, make, type, odometer, costKm, costDay, status));
                else
                _db.Add<IVehicle>(new Car(_db.NewVehicleId, registrationNumber, make, type, odometer, costKm, costDay, status));

            }
            NewCustomer = new();
        }
        catch (Exception ex) 
        { 
        
            ErrorMessage = ex.Message;
        
        }
       

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
