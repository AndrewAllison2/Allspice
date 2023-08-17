
namespace Allspice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepository;

    public FavoritesService(FavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
    Favorite favorite = _favoritesRepository.CreateFavorite(favoriteData);
    return favorite;
    }

    internal List<Favorite> GetAccountFavorites(string userId)
    {
    List<Favorite> favorites = _favoritesRepository.GetAccountFavorites(userId);
    return favorites;
    }
}
