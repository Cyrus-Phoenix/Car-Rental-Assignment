using Car_Rental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IBookings
    {
        public int Id { get; set; }
       // public string Name { get; set; }



        public VehicleStatuses VStatus { get; set; }
    }


}
