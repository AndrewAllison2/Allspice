
namespace Allspice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepository;

    public FavoritesService(FavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }

    internal Favorite CreateFavorite(Favorite favoriteData, string userId)
    {
    Favorite favorite = _favoritesRepository.CreateFavorite(favoriteData);
    return favorite;
    }

    internal List<RecipeFavorite> GetAccountFavorites(string userId)
    {
    List<RecipeFavorite> favorites = _favoritesRepository.GetAccountFavorites(userId);
    return favorites;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
    Favorite favorite = _favoritesRepository.GetFavoriteById(favoriteId);

    if (favorite == null)
    {
      throw new Exception("Something went wrong");
    }
    return favorite;
    }

    internal void RemoveFavorite(int favoriteId, string userId)
    {
    Favorite favorite = GetFavoriteById(favoriteId);

    if (favorite.AccountId != userId)
    {
      throw new Exception("Cannot delete data that is not yours");
    }
    _favoritesRepository.RemoveFavorite(favoriteId);
    }
}
