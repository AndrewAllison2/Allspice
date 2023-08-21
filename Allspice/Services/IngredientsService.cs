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

    internal Ingredient EditIngredient(Ingredient iData, int ingredientId)
    {
    Ingredient originalIngredient = GetIngredientById(ingredientId);

    originalIngredient.Quantity = iData.Quantity ?? originalIngredient.Quantity;
    originalIngredient.Name = iData.Name ?? originalIngredient.Name;

    Ingredient ingredient = _ingredientsRepository.EditIngredient(originalIngredient);
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

    internal Ingredient RemoveIngredient(int ingredientId, string userId)
    {
    // Ingredient ingredient = GetIngredientById(ingredientId);

    // if (ingredient.CreatorId != userId)
    // {
    //   throw new Exception("You cannot remove ingredients you did not add.");
    // } 
    Ingredient removedIngredient = _ingredientsRepository.RemoveIngredient(ingredientId);
    return removedIngredient;
    }
}
