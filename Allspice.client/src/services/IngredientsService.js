import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class IngredientsService {

  async getIngredientsByRecipeId(recipeId) {
    const res = api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log('GETTING RECIPE INGREDIENTS', res.data)
  }
}


export const ingredientsService = new IngredientsService()