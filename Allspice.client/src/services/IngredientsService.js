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
}


export const ingredientsService = new IngredientsService()