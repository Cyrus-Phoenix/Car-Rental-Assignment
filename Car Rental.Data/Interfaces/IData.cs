using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Interfaces
{
    public interface IData
    {
        #region Properties

        int NewVehicleId { get; }
        int NewCustomerId { get; }
        int NewBookingId { get; }

        #endregion


         List<T> Get<T>(Expression<Func<T, bool>>? expression);
         T? Single<T>(Expression<Func<T, bool>>? expression);
         public void Add<T>(T entity);

        public IEnumerable<ICustomer> GetCustomers();
        public  IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
        public IEnumerable<IBooking> GetBookings();


      
        IBooking RentVehicle(int vehicleId, int customerId);
        //IBooking ReturnVehicle(int vehicleId);



        // Default Interface Methods
        public string[] VehicleStatusNames => Enum.GetNames(typeof(VehicleStatuses));// Retunera enum konstanterna
        public string[] VehicleTypeNames => Enum.GetNames(typeof(VehiclesTypes));// Retunera enum konstanterna
        public string[] VehicleMakeNames => Enum.GetNames(typeof(VehiclesMake));// Retunera enum konstanterna

        //Fråga om varför den måste "castas" ? Den castas pga att Parse vill ha en object och då måste man ange vad för dadatyp objecten blir när den kommer in.
        public VehiclesTypes GetVehicleType(string name) => (VehiclesTypes)Enum.Parse(typeof(VehiclesTypes), name); // Retunera en enum konstants värde med hjälp av konstantens namn
        public VehiclesMake GetVehicleMake(string name) => (VehiclesMake)Enum.Parse(typeof(VehiclesMake), name); // Retunera en enum konstants värde med hjälp av konstantens namn
    }
}
 