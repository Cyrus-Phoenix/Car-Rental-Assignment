using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces
{
    public interface IBooking
    { 
        public int Id { get; set; }
        public VehicleStatuses BookingStatus { get; set; }
        public ICustomer Person { get; }
        public IVehicle Vehicle { get; }
        public DateTime Start { get; init; }
        public DateTime End { get; set; }
        public DateTime days { get; init; }
        public double Cost { get; set; }
        public double LastKnownOdometer { get; set; }
        public double OdormeterRented { get; set; }
        public double KmReturned { get; set; }
        
       


        #region commented props
        // public int CustomerSSN { get; }
        // public string Customer { get; }
        // public string RegNo { get; }
        // public VehiclesMake VehiclesMake { get; }
        // public string Name { get; set; }


        // public VehicleStatuses VStatus { get; init; }
        #endregion







    }


}
