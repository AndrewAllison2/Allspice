using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allspice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients(name, quantity, recipeId)
        VALUES(@Name, @Quantity, @RecipeId);
        SELECT LAST_INSERT_ID()
        ;";

        int recipeId = _db.ExecuteScalar<int>(sql, ingredientData);
        return recipeId;
    }


    // TODO WRITE SQL STRING AND METHOD IN REPO
    internal Ingredient GetIngredientById(int ingredientId)
    {
        string sql = @"
        SELECT *
        FROM ingredients 
        WHERE id = @ingredientId
        ;";

        Ingredient ingredient = _db.QueryFirstOrDefault<Ingredient>(sql, new { ingredientId });
        return ingredient;
    }

    internal List<Ingredient> GetIngredientByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT *
        FROM ingredients
        WHERE ingredients.recipeId = @recipeId
        ;";

        List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new{recipeId}).ToList();
        return ingredients;
    }
}
