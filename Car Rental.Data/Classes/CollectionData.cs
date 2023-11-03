using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;

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

   
    //TODO skapa logiken för att skapa nya bokningar, personer, fordon


    #endregion


    int numberOfDays;
    int kmReturned;

    public CollectionData()
    {
        #region With VehicleStatuses

        var vehicle1 = new Car(1, "ABC 123", (VehiclesMake)1, VehiclesTypes.Sedan, 5500, 5, 250, VehicleStatuses.Available);
        Car vehicle2 = new (2, "ABC 345", VehiclesMake.BMW, VehiclesTypes.Combi, 8500, 2, 140, VehicleStatuses.Available);
        var vehicle3 = new Motorcycle(1, "DEF 123", (VehiclesMake)3, VehiclesTypes.Motorcycle, 500, 10, 300, VehicleStatuses.Available);
        Motorcycle vehicle4 = new (2, "DEF 345", VehiclesMake.VW, VehiclesTypes.Motorcycle, 2500, 1, 80, VehicleStatuses.Available);

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

        
        
        (DateTime startBook1, DateTime endBook1) = BookingDates(new DateTime(2023, 6, 12), new DateTime(2023, 6, 13));
        numberOfDays = DaysRented(startBook1, endBook1);
        double kmReturned1 = KmAmount(400);
        var cost1 = CostCalculator(vehicle1, endBook1);

        var b1 = new Booking(
                            1,
                            customer1,
                            vehicle1,
                            cost1,
                            //vehicle1.Odometer,
                            kmReturned1 + vehicle1.Odometer,
                            startBook1,
                            endBook1,
                            vehicle1.VStatus = VehicleStatuses.Available
                            ) ;
        _bookings.Add(b1);

        


        (DateTime startBook2, DateTime endBook2) = BookingDates(new DateTime(2023, 6, 12), DateTime.MinValue);
        numberOfDays = DaysRented(startBook2, endBook2);
        double kmReturned2 = KmAmount(0);
        double cost2 = CostCalculator(vehicle1, endBook2);
        var b2 = new Booking
            (
                           2,
                           customer2,
                           vehicle2,
                           //customer2.SSN,
                           //customer2.FName + " " + customer2.LName,
                           //vehicle2.RegNo,
                           //vehicle2.VehicleMake,
                           cost2,
                           //vehicle2.Odometer,
                           kmReturned2 + vehicle2.Odometer,
                           startBook2,
                           endBook2,
                           vehicle2.VStatus = VehicleStatuses.Booked
             ) ;
        _bookings.Add(b2);

        


        #endregion

    }


    #region All Methods

    int KmAmount(int km)
    {
        kmReturned = km;
        return kmReturned;
    }


    #region Old Way of typing method

    //(DateTime, DateTime) BookingDates(DateTime startingDate, DateTime endingDate) 
    //{ 
    //    return (startingDate, endingDate);
    //}
    #endregion


    (DateTime, DateTime) BookingDates(DateTime startingDate, DateTime endingDate) 
    =>  (startingDate, endingDate);


    int DaysRented(DateTime startBook, DateTime endBook)
    {
        TimeSpan days = startBook - endBook;
        int totalDays = days.Days;
        return totalDays;
    }

    double CostCalculator(IVehicle vehicle, DateTime endBook)
    {
       
        double cost = 0;
        
        if ( endBook == DateTime.MinValue )
        {
            return cost;
        }
        cost = (numberOfDays * vehicle.CostDay) + (kmReturned * vehicle.CostKm);
        return cost;

    }

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

            // Hämta data som den innehåller
            var value = fieldInfo.GetValue(this) 
                        ?? throw new InvalidDataException($"No data of found.");

            // Omvandla till en IQueryable så att man kan använda lambda
            // och filtrera innan datat hämtas istället för tvärtom
            var collection = (IQueryable<T>)value;
            
            if(expression is null) return collection.ToList();
            return collection.Where(expression).ToList();

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

        // TODO : Varför fungerade inte IQueryable och varför var denna tvungen att castas som List<T> ?
        var value = (List<T>)fieldInfo.GetValue(this)
                        ?? throw new InvalidDataException($"No data of found.");

        // var list = (IQueryable<T>)entity;




        /// TDO Varför fungera inte den code blocket under?
        //   value.Add(entity); /* Är det för att den kollar på value.add funktionen och inte entity variabeln? */
        //    ?? throw new ArgumentNullException($"Could not add null element");

        if (entity is not null)
        {
           value.Add(entity);
        }
        else
        {
            throw new ArgumentNullException($"Could not add null element");
        }

    }

    public T? Single<T>(Expression<Func<T, bool>>? expression)
    {
        try
        {

            // Hämta fälten Propertierna etc.
            var fieldInfo = GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>))
                ?? throw new InvalidOperationException("Unsupported type");

            // Hämta data som den innehåller
            var value = fieldInfo.GetValue(this)
                        ?? throw new InvalidDataException($"No data of found.");

            // Omvandla till en IQueryable så att man kan använda lambda
            // och filtrera innan datat hämtas istället för tvärtom
            var collection = (IQueryable<T>)value;

            if (expression is null) return collection.SingleOrDefault();
            return collection.Where(expression).SingleOrDefault();

        }
        catch (Exception ex)
        {

            throw ex;

        }

    }



    #endregion


    #region Booking Methods

    #endregion


    public IEnumerable<ICustomer> GetCustomers() => _customers;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
   
    public IEnumerable<IBooking> GetBookings() => _bookings;

    
}