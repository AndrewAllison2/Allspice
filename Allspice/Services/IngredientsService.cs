using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allspice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _ingredientsRepository;

    public IngredientsService(IngredientsRepository ingredientsRepository)
    {
        _ingredientsRepository = ingredientsRepository;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, string id)
    {
    int ingredientId = _ingredientsRepository.CreateIngredient(ingredientData);

    Ingredient ingredient = GetIngredientById(ingredientId);
    return ingredient;
    }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _ingredientsRepository.GetIngredientById(ingredientId);

    if (ingredient == null)
    {
      throw new Exception("No ingredient by that ID");
    }
    return ingredient;
  }

    internal List<Ingredient> GetIngredientByRecipeId(int recipeId)
    {
    List<Ingredient> ingredients = _ingredientsRepository.GetIngredientByRecipeId(recipeId);
    return ingredients;
    }
}
