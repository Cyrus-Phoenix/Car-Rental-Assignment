using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    IData _data;

    public BookingProcessor(IData data)
    {
        _data = data;
    }

    public IEnumerable<ICustomer> GetCustomers() => _data.GetCustomers();
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
    {
            
            return _data.GetVehicles();
    }
    
    
    

}
