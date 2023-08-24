export class Favorite {
  constructor(data) {
    this.id = data.id
    this.favoriteId = data.favoriteId
    this.accountId = data.accountId
    this.recipeId = data.recipeId
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}

