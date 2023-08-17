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
}
