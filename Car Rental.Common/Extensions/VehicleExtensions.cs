namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static int DaysCalculator(this DateTime startDate, DateTime endDate)
    {
        TimeSpan numberOfDays = startDate - endDate;
        int totalDays = (int)numberOfDays.TotalDays;
        return totalDays < 1 ? 1 : totalDays;
    }
}
