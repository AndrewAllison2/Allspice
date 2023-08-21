import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class IngredientsService {

  async getIngredientsByRecipeId(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log('GETTING RECIPE INGREDIENTS', res.data)
    const ingredients = await res.data.map(i => new Ingredient(i))
    AppState.ingredients = ingredients
  }

  async addIngredient(formData) {
    const res = await api.post(`api/ingredients`, formData)
    logger.log('[CREATING INGREDIENT]', res.data)
    const ingredient = new Ingredient(res.data)
    AppState.ingredients.push(ingredient)
  }

  setActiveIngredient(ingredient) {
    AppState.activeIngredient = ingredient
  }

  async removeIngredient(ingredientId) {
    await api.delete(`api/ingredients/${ingredientId}`)
    const iIndex = AppState.ingredients.findIndex(i => i.id = ingredientId)
    AppState.ingredients.splice(iIndex, 1)
  }

  async editIngredient(formData, ingredientId) {
    const res = await api.put(`api/ingredients/${ingredientId}`, formData)
    // logger.log('EDITING INGREDIENT', res.data)
    AppState.activeIngredient = new Ingredient(res.data)
  }

}


export const ingredientsService = new IngredientsService()