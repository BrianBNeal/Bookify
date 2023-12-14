using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public class PricingService : IPricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
    {
        var currency = apartment.Price.Currency;
        var priceForPeriod = new Money(
            apartment.Price.Amount * period.LengthInDays,
            currency);

        decimal percentageUpcharge = 0;
        foreach (var amenity in apartment.Amenities)
        {
            percentageUpcharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m,
                Amenity.AirConditioning => 0.01m,
                Amenity.Parking => 0.01m,
                _ => 0
            };
        }

        var amenitiesUpcharge = Money.Zero(currency);
        if (percentageUpcharge > 0)
        {
            amenitiesUpcharge = new Money(
                priceForPeriod.Amount * percentageUpcharge,
                currency);
        }

        var totalPrice = Money.Zero();
        totalPrice += priceForPeriod;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenitiesUpcharge, totalPrice);
    }
}
