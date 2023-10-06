using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces
{
    public interface IBookings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VehiclesMake VehiclesMake { get; set; }
        //public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Cost { get; set; }
        public int KmRented { get; set; }
        public int KmReturned { get; set; }
        public DateTime days { get; set; }
        public VehicleStatuses VStatus { get; set; }





    }


}
