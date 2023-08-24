import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { logger } from "../utils/Logger.js"
import { accountService } from "./AccountService.js"
import { api } from "./AxiosService.js"

class FavoritesService {

  async createFavorite(formData) {
    const res = await api.post(`api/favorites`, formData)
    logger.log('Making fav', res.data)
    const newFav = new Favorite(res.data)
    AppState.myFavorites.push(newFav)
    await accountService.getMyFavorites()
  }
  async removeFavorite(favoriteId) {
    const res = await api.delete(`api/favorites/${favoriteId}`)
    logger.log(res.data)
    // const favIndex = AppState.favorites.findIndex(i => i.id == favoriteId)
    // AppState.favorites.splice(favIndex, 1)
    const myFavIndex = AppState.myFavorites.findIndex(i => i.id == favoriteId)
    AppState.myFavorites.splice(myFavIndex, 1)
    await accountService.getMyFavorites()
  }

}


export const favoritesService = new FavoritesService()