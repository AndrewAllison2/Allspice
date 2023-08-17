export class Recipe {
  constructor(data) {
    this.id = data.id
    this.title = data.title
    this.instructions = data.instructions
    this.imgUrl = data.img
    this.category = data.category
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.creatorId = data.creatorId
    this.creator = data.creator
  }

}

// let recipeasy = {
//   "id": 1,
//   "title": "The Senior Jake Burrito",
//   "instructions": "Take your burrito and cook it, then add hotdog.  Boom, Burrito.",
//   "img": "https://images.unsplash.com/photo-1584031036380-3fb6f2d51880?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=80",
//   "category": "Mexican",
//   "createdAt": "2023-08-17T21:35:51",
//   "updatedAt": "2023-08-17T21:35:51",
//   "creatorId": "64d522d0b1279326b555200d",
//   "creator": {
//     "id": "64d522d0b1279326b555200d",
//     "name": "lordfarquad@from.shreck",
//     "picture": "https://s.gravatar.com/avatar/eee41216e6f21edec6e767e5e000529f?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Flo.png"
//   }
// }