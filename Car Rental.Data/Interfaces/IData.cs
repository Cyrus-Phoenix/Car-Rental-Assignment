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

        
        public IEnumerable<ICustomer> GetCustomers();
        public  IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
        public IEnumerable<IBooking> GetBookings();

    }
}
