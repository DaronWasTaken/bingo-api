using bingo_api.Models.Entities;

namespace bingo_api.Models.EntityProviders;

public static class UserProvider
{
    public static User User { get; set; } = EntityProvider.User;
}