using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Shared;
using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations;
internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("bookings");

        builder.HasKey(b => b.Id);

        builder.OwnsOne(b => b.PriceForPeriod, pricebuilder =>
        {
            pricebuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(b => b.CleaningFee, pricebuilder =>
        {
            pricebuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(b => b.AmenitiesUpcharge, pricebuilder =>
        {
            pricebuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(b => b.TotalPrice, pricebuilder =>
        {
            pricebuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(b => b.Duration);

        builder.HasOne<Apartment>()
            .WithMany()
            .HasForeignKey(b => b.ApartmentId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(b => b.UserId);
    }
}
