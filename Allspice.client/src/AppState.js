import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Recipe.js').Recipe} */
  recipes: [],

  /** @type {import('./models/Recipe.js').Recipe} */
  activeRecipe: null,

  /** @type {import('./models/Ingredient.js').Ingredient} */
  activeIngredient: null,

  /** @type {import('./models/Ingredient.js').Ingredient[]} */
  ingredients: [],

  /** @type {import('./models/Favorite.js').Favorite[]} */
  favorites: [],
  /** @type {import('./models/Favorite.js').Favorite[]} */
  myFavorites: []
})
