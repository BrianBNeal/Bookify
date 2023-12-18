namespace Bookify.Domain.Bookings;

public enum BookingStatus
{
    Reserved = 1,
    Confirmed = 2,
    Rejected = 3,
    Cancelled = 4,
    Completed = 5
}

public class BookingStatuses
{
    public static IReadOnlyCollection<BookingStatus> Active =>
        new BookingStatus[]
        {
            BookingStatus.Reserved,
            BookingStatus.Confirmed,
            BookingStatus.Completed
        };
};