using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Extensions;

public static class BookingExtensions
{
    #region Calculations

    public static void Return(this IBooking  booking, double kmReturned)
    {
        booking.Vehicle.StatusSwitch(VehicleStatuses.Available);
        booking.BookingStatus = VehicleStatuses.Available;
        booking.End = DateTime.Now;
        booking.LastKnownOdometer = booking.Vehicle.Odometer;
        booking.Vehicle.UpdateOdometer(kmReturned);
        booking.KmReturned = booking.OdormeterRented + kmReturned;
        booking.Cost = VehicleExtensions.DaysCalculator(booking.Start, booking.End) * booking.Vehicle.CostDay + booking.Vehicle.CostKm * kmReturned;
    }

    //public static double DaysCalculator( DateTime startBook, DateTime endBook)
    //{

    //    TimeSpan numberOfDays = endBook - startBook;
    //    double totalDays = (double)numberOfDays.TotalDays;
    //    return totalDays < 1 ? 1 : totalDays;
        
    //}

    #endregion

}
