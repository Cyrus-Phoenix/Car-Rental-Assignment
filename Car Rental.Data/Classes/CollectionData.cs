using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Enums;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Car_Rental.Data.Classes;

/*
 Have to contain all the Data
 */

public class CollectionData : IData
{
    readonly List<IVehicle> _vehicles = new();
    readonly List<ICustomer> _customers = new();
    readonly List<IBooking> _bookings = new();

    #region NewIdVariabels

    public int NewVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(id => id.Id) + 1; 
    public int NewCustomerId => _customers.Count.Equals(0) ? 1 : _customers.Max(id => id.Id) + 1; 
    public int NewBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(id => id.Id) + 1; 


    #endregion


    int numberOfDays;
   // int kmReturned;

    public CollectionData()
    {
        #region With VehicleStatuses

        var vehicle1 = new Car(1, "ABC 123", (VehiclesMake)1, VehiclesTypes.Sedan, 5500, 5, 250, VehicleStatuses.Available);
        Car vehicle2 = new(2, "ABC 345", VehiclesMake.BMW, VehiclesTypes.Combi, 8500, 2, 140, VehicleStatuses.Available);
        var vehicle3 = new Motorcycle(3, "DEF 123", (VehiclesMake)3, VehiclesTypes.Motorcycle, 500, 10, 300, VehicleStatuses.Available);
        Motorcycle vehicle4 = new(4, "DEF 345", VehiclesMake.VW, VehiclesTypes.Motorcycle, 2500, 1, 80, VehicleStatuses.Available);

        _vehicles.Add(vehicle1);
        _vehicles.Add(vehicle2);
        _vehicles.Add(vehicle3);
        _vehicles.Add(vehicle4);

        #endregion

        #region Customers

        var customer1 = new Customer(1, "820512", "John", "Doe");
        var customer2 = new Customer(2, "801212", "Lucky", "Luke");
        var customer3 = new Customer(3, "581201", "John", "Snow");
        var customer4 = new Customer(4, "900126", "Louise", "Lane");

        _customers.Add(customer1);
        _customers.Add(customer2);
        _customers.Add(customer3);
        _customers.Add(customer4);


        #endregion

        #region Booking



      //TODO : Varför startar den som bookad när bokning avslutas här?
        var b1 = new Booking( 1 , customer2, vehicle3 );
        _bookings.Add(b1);
        BookingExtensions.Return(b1, 100);
        

        var b2 = new Booking( 2, customer1, vehicle1 ) ;
        _bookings.Add(b2);
        BookingExtensions.Return(b2, 500);



        #endregion

    }
    

    #region All Methods

    //int KmAmount(int km)
    //{
    //    kmReturned = km;
    //    return kmReturned;
    //}


    #region Old Way of typing method

    //(DateTime, DateTime) BookingDates(DateTime startingDate, DateTime endingDate) 
    //{ 
    //    return (startingDate, endingDate);
    //}
    #endregion


    //(DateTime, DateTime) BookingDates(DateTime startingDate, DateTime endingDate) 
    //=>  (startingDate, endingDate);


    //int DaysRented(DateTime startBook, DateTime endBook)
    //{
    //    TimeSpan days = startBook - endBook;
    //    int totalDays = days.Days;
    //    return totalDays;
    //}

    //double CostCalculator(IVehicle vehicle, DateTime endBook)
    //{

    //    double cost = 0;

    //    if (endBook == DateTime.MinValue)
    //    {
    //        return cost;
    //    }
    //    cost = (numberOfDays * vehicle.CostDay) + (kmReturned * vehicle.CostKm);
    //    return cost;

    //}

    #endregion



    #region Generic Methods


    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        try {
            
            // Hämta fälten Propertierna etc.
            var fieldInfo = GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>))
                ?? throw new InvalidOperationException("Unsupported type");


            #region Code that didn't work
            // Hämta data som den innehåller
            //var value = fieldInfo.GetValue(this)
            //            ?? throw new InvalidDataException($"No data of found.");

            //// Omvandla till en IQueryable så att man kan använda lambda
            //// och filtrera innan datat hämtas istället för tvärtom

            ////TODO :  Fråga varför (IQueryable<T>)value inte fungerade här?
            //var collection = (IQueryable<T>)value;

            //if (expression is null) return collection.ToList();
            //return collection.Where(expression).ToList();

            #endregion


            #region Code that worked

            var values = (List<T>)fieldInfo.GetValue(this)
               ?? throw new InvalidOperationException($"No list of type {typeof(T)} found.");

            if (expression is null) return values;
            // Execute the Compiled Lambda: You can now execute the compiled lambda expression as if it were a regular function: enligt chatgpt
            return values.Where(expression.Compile()).ToList();

            #endregion
          

        }
        catch (Exception ex) {

            throw ex;

        }
    }
    

    public void Add<T>(T entity)
    {
        var fieldInfo = GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>))
                ?? throw new InvalidOperationException($"No type of {typeof(T)} found.");

        // Varför fungerade inte IQueryable och varför var denna tvungen att castas som List<T> ? IQueryable är för filtrering och metoden i dethär fallet vill lägga till något och inte filtrera.
        var list = (List<T>)fieldInfo.GetValue(this)
                        ?? throw new InvalidDataException($"No data of found.");
        
        // var list = (IQueryable<T>)entity;




        /// TDO Varför fungera inte den code blocket under?
         // value.Add(entity) /* Är det för att den kollar på value.add funktionen och inte entity variabeln? */
          // ?? throw new ArgumentNullException($"Could not add null element");

        if (entity is not null)
        {
           list.Add(entity);
        }
        else
        {
            throw new ArgumentNullException($"Could not add null element");
        }

    }

    public T? Single<T>(Expression<Func<T, bool>>? expression)
    {
       
            // Hämta fälten Propertierna etc.
            var fieldInfo = GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>))
                ?? throw new InvalidOperationException("Unsupported type");

            //TODO : Fråga varför IQueryable inte gick här.
            #region Code that didn't work

            // Hämta data som den innehåller
            //var value = fieldInfo.GetValue(this)
            //            ?? throw new InvalidDataException($"No data of found.");

            //// Omvandla till en IQueryable så att man kan använda lambda
            //// och filtrera innan datat hämtas istället för tvärtom
            //var collection = (IQueryable<T>)value;

            //if (expression is null) return collection.SingleOrDefault();
            //return collection.Where(expression).SingleOrDefault();


            #endregion

        if(fieldInfo is not null) 
        {
            // Hämta data som den innehåller
            var value = (List<T>)fieldInfo.GetValue(this)
                        ?? throw new InvalidDataException($"No data of found.");

            if (expression is not null) 
            {
                var entity = value.SingleOrDefault(expression.Compile());
                if (entity is not null)
                    return entity;
            
            }
            throw new InvalidOperationException($"No matching element of type {typeof(T)} found.");

        }

        throw new InvalidOperationException($"No type of {typeof(T)} found.");


    }



    #endregion


    #region Booking Methods

    public IBooking RentVehicle(int vehicleId, int customerId)
    {
        Booking booking;
        var vehicle = Single<IVehicle>(v => v.Id == vehicleId);
        var customer = Single<ICustomer>(c => c.Id == customerId);

        if (vehicle is not null && customer != null)
        {
            return booking = new(NewBookingId,customer,vehicle);
        }
        else
            throw new Exception("Couldn't complete the booking");
        
    }


    //TODO : Fixa Return metoden och hela den funktionen för programmet.

    public IBooking ReturnVehicle(int vehicleId, double kmReturned)
    {
        var booking = _bookings.SingleOrDefault(b => b.Vehicle.Id.Equals(vehicleId) && b.BookingStatus == VehicleStatuses.Booked);
        
      
        if (booking is not null)
        {
            booking.BookingStatus = VehicleStatuses.Available;
            booking.Return(kmReturned);
            return booking;
        }
           
        throw new Exception("Couldn't find booking");
    }


    #endregion


    public IEnumerable<ICustomer> GetCustomers() => _customers;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
   
    public IEnumerable<IBooking> GetBookings() => _bookings;

    
}