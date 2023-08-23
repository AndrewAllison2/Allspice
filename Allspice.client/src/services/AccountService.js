import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Favorite } from "../models/Favorite.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async editAccount(formData) {
    const res = await api.put('/account', formData)
    logger.log('EDITING ACCOUNT', res.data)
    AppState.account - new Account(res.data)
  }

  async getMyFavorites() {
    const res = await api.get('/account/favorites')
    logger.log('GETTING MY FAVORITES', res.data)
    AppState.myFavorites = res.data.map(f => new Favorite(f))
  }
}

export const accountService = new AccountService()
