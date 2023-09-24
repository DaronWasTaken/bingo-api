using bingo_api.Models.Entities;

namespace bingo_api.Models.EntityProviders;

public static class QuickplayProvider
{
    public static Quickplay Quickplay { get; } = EntityProvider.Quickplay;
}