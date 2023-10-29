using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Extensions;

public static class BookingExtensions
{
    #region Calculations

    public static (DateTime, DateTime) BookingDates(DateTime startingDate, DateTime endingDate)
    => (startingDate, endingDate);

    public static int CostCalculator(IVehicle vehicle, DateTime startBook, DateTime endBook, int kmReturned)
    {

        TimeSpan numberOfDays = endBook - startBook;

        int totalDays = (int)numberOfDays.TotalDays;

        int cost = 0;

        if (endBook == DateTime.MinValue)
        {
            return cost;
        }
        cost = (totalDays * vehicle.CostDay) + (kmReturned * vehicle.CostKm);
        return cost;
        
    }

    #endregion

}
