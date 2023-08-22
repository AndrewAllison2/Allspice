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

  async removeRecipe(recipeId) {
    const res = await api.delete(`api/recipes/${recipeId}`)
    logger.log('DELETED RECIPE', res.data)
    const rIndex = AppState.recipes.findIndex(r => r.id == recipeId)
    AppState.recipes.splice(rIndex, 1)
  }

  async createRecipe(formData) {
    const res = await api.post('api/recipes', formData)
    AppState.recipes.push(new Recipe(res.data))
  }
}

export const recipesService = new RecipesService()