using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces
{
    public interface IBooking
    { 
        public int Id { get; set; }

       public ICustomer Person { get; }
       public IVehicle Vehicle { get; }
       
       
       // public int CustomerSSN { get; }
       // public string Customer { get; }
       // public string RegNo { get; }
       // public VehiclesMake VehiclesMake { get; }
       // public string Name { get; set; }

        public DateTime Start { get; init; }
        public DateTime? End { get; init; }
        public double Cost { get; init; }

       // public int KmRented { get; init; }
        public double KmReturned { get; init; }
        public DateTime days { get; init; }

       // public VehicleStatuses VStatus { get; init; }





    }


}
