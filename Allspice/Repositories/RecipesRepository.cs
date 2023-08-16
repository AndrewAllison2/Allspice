using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allspice.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateRecipe(Recipe recipeData)
    {
    string sql = @"
    INSERT INTO recipes (title, instructions, img, category, creatorId)
    VALUES (@Title, @Instructions, @Img, @Category, @CreatorId);
    SELECT LAST_INSERT_ID()
    ;";

    int recipeId = _db.ExecuteScalar<int>(sql, recipeData);
    return recipeId;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
    string sql = @"
    SELECT
    rep.*,
    acc.*
    FROM recipes rep
    JOIN accounts acc ON acc.id = rep.creatorId
    WHERE rep.id = @recipeId LIMIT 1
    ;";

    Recipe recipe = _db.Query<Recipe, Profile, Recipe>(
      sql,
      (recipe, profile) =>
      {
        recipe.Creator = profile;
        return recipe;
      },
      new { recipeId }).FirstOrDefault();
    return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
    string sql = @"
    SELECT
    rep.*,
    acc.*
    FROM recipes rep
    JOIN accounts acc ON acc.id = rep.creatorId
    ;";

    List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(
      sql,
      (recipe, profile) =>
      {
        recipe.Creator = profile;
        return recipe;
      }
    ).ToList();
    return recipes;
    }


// FIXME FAILING 1 TEST ON EDIT
    internal Recipe UpdateRecipe(Recipe ogRecipe)
    {
    string sql = @"
    UPDATE recipes
    SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @Category
    WHERE id = @Id
    LIMIT 1
    ;";

    Recipe updatedRecipes = _db.QueryFirstOrDefault<Recipe>(sql, ogRecipe);
    return updatedRecipes;
    }
}
