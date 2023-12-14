﻿using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;
public static class ApartmentErrors
{
    public static Error NotFound => new(
        "Apaartment.NotFound",
        "The apartment with the specified identifier was not found.");
}
