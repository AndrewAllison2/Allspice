import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService {

  async getRecipes() {
    const res = await api.get('api/recipes')
    logger.log('GETTING RECIPES', res.data)
    const recipes = res.data.map(r => new Recipe(r))
    AppState.recipes = recipes
  }

  setActiveRecipe(recipe) {
    AppState.activeRecipe = recipe
  }

  async editRecipeInstructions(formData, recipeId) {
    const res = await api.put(`api/recipes/${recipeId}`, formData)
    logger.log('EDITING RECIPE STEPS', res.data)
    let updatedRecipe = new Recipe(res.data)
    AppState.activeRecipe = updatedRecipe
  }

}

export const recipesService = new RecipesService()