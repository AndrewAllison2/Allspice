import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class FavoritesService {

  async createFavorite(formData) {
    const res = await api.post(`api/favorites`, formData)
    logger.log('Making fav', res.data)
    const newFav = new Favorite(res.data)
    AppState.favorites.push(newFav)
  }

  async removeFavorite(favoriteId) {
    const res = await api.delete(`api/favorites/${favoriteId}`)
    logger.log(res.data)
    const favIndex = AppState.favorites.findIndex(i => i.id == favoriteId)
    AppState.favorites.splice(favIndex, 1)
  }
}


export const favoritesService = new FavoritesService()