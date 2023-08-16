using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allspice.Services;

public class RecipesService
{
  private readonly RecipesRepository _recipesRepository;

    public RecipesService(RecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
    int recipeId = _recipesRepository.CreateRecipe(recipeData);

    Recipe recipe = GetRecipeById(recipeId);
    return recipe;
    
    }

    internal Recipe GetRecipeById (int recipeId)
    {
    Recipe recipe = _recipesRepository.GetRecipeById(recipeId);

    if (recipe == null)
    {
      throw new Exception("Bruh, this ain't it");
    }
    return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
    List<Recipe> recipes = _recipesRepository.GetRecipes();
    return recipes;
    }

    internal Recipe UpdateRecipe(int recipeId, Recipe recipeData)
    {
    Recipe ogRecipe = GetRecipeById(recipeId);

    ogRecipe.Title = recipeData.Title ?? ogRecipe.Title;
    ogRecipe.Instructions = recipeData.Instructions ?? ogRecipe.Instructions;
    ogRecipe.Img = recipeData.Img ?? ogRecipe.Img;
    ogRecipe.Category = recipeData.Category ?? ogRecipe.Category;

    Recipe recipe = _recipesRepository.UpdateRecipe(ogRecipe);
    return recipe;
    }
}
