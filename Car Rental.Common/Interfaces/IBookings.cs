using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces
{
    public interface IBookings
    {
        public int Id { get; set; }
        public int CustomerSSN { get; }
        public string Customer { get; }
        public string RegNo { get; }
        public VehiclesMake VehiclesMake { get; }
        //public string Name { get; set; }
        public DateTime Start { get; init; }
        public DateTime? End { get; init; }
        public int Cost { get; init; }
        public int KmRented { get; init; }
        public int KmReturned { get; init; }
        public DateTime days { get; init; }
        public VehicleStatuses VStatus { get; init; }





    }


}
