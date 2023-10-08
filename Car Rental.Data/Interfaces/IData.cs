using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Interfaces
{
    public interface IData
    {
       public IEnumerable<ICustomer> GetCustomers();
       public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
       public IEnumerable<IBookings> GetBookings();


    }
}
