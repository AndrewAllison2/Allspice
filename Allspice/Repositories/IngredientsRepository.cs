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
        INSERT INTO ingredients(name, quantity, recipeId, creatorId)
        VALUES(@Name, @Quantity, @RecipeId, @CreatorId);
        SELECT LAST_INSERT_ID()
        ;";

        int recipeId = _db.ExecuteScalar<int>(sql, ingredientData);
        return recipeId;
    }

    internal Ingredient EditIngredient(Ingredient originalI)
    {
        string sql = @"
        UPDATE ingredients
        SET
        quantity = @Quantity,
        name = @Name
        WHERE id = @Id
        LIMIT 1;
        SELECT * FROM ingredients WHERE id=@Id
        ;";
        Ingredient ingredient = _db.QueryFirstOrDefault<Ingredient>(sql, originalI);
        return ingredient;
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

    internal Ingredient RemoveIngredient(int ingredientId)
    {
        string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";

        Ingredient removedIngredient = _db.ExecuteScalar<Ingredient>(sql, new{ingredientId});
        return removedIngredient;
    }
}
