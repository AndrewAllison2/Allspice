using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allspice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
    string sql = @"
    INSERT INTO favorites (accountId, recipeId)
    VALUES (@AccountId, @RecipeId);
    SELECT LAST_INSERT_ID()
    ;";

    int favoriteId = _db.ExecuteScalar<int>(sql, favoriteData);

    favoriteData.Id = favoriteId;

    return favoriteData;
    }

    internal List<RecipeFavorite> GetAccountFavorites(string userId)
    {
    string sql = @"
    SELECT
    fav.*,
    rec.*
    FROM favorites fav
    JOIN recipes rec ON rec.id = fav.recipeId
    WHERE fav.accountId = @userId
    ;";

    List<RecipeFavorite> favorites = _db.Query<Favorite, RecipeFavorite, RecipeFavorite>(
      sql,
      (favorite, recipe) => {
        recipe.FavoriteId = favorite.Id;
        recipe.RecipeId = favorite.RecipeId;
        recipe.AccountId = favorite.AccountId;
        
        return recipe;
      },
      new { userId }
      ).ToList();

    return favorites;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
    string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";

    Favorite favorite = _db.QueryFirstOrDefault<Favorite>(sql, new { favoriteId });
    return favorite;
    }

    internal void RemoveFavorite(int favoriteId)
    {
    string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1";

    _db.Execute(sql, new { favoriteId });
    
    }
}
