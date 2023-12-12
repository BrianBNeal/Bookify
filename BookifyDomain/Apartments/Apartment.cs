using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;

public sealed class Apartment(Guid id) : Entity(id)
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public decimal PriceAmount { get; private set; }
    public Currency PriceCurrency { get; private set; }
    public decimal CleaningFeeAmount { get; private set; }
    public Currency CleaningFeeCurrency { get; private set; }
    public DateTime? LastBooked { get; private set; }
    public List<Amenity> Amenities { get; private set; } = new();
}
