using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    IData _data;

    public BookingProcessor(IData data)
    {
        _data = data;
    }

    public List<ICustomer> GetCustomers() => _data.GetCustomers();
    public List<IVehicle> GetVehicles() => _data.GetVehicles();



}
