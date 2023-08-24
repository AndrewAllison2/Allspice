<template>
  <div class="container-fluid">

    <div class="row">
      <div class="hero-img m-auto my-4">
        <div class="col-12 m-auto">

          <div class="d-flex justify-content-end align-items-center">

            <div class="me-3 mt-1">
              <!-- <div>
                <h2 class="selectable">All</h2>
                <h2 class="selectable">Likes</h2>

              </div> -->
              <button class="btn back-button" data-bs-target="#createRecipe" data-bs-toggle="modal">
                <i class="mdi mdi-plus fs-4" > Add Recipe</i>
              </button>
            </div>

            <div class="me-3">
              Search Bar
            </div>

            <Login/>
          </div>

          <div class="text-white text-center py-5">
            <h1>All Spice</h1>
            <h4>Cherish Your Family</h4>
            <h4>And Their Cooking</h4>
          </div>
        </div>
      </div>

      <div class="row">
        <div class="col-8 m-auto d-flex justify-content-around mb-3">
          <button class="btn-btn-secondary rounded p-2" @click="filterBy=''">All</button>
          <button class="btn-btn-secondary rounded p-2" @click="filterBy='Cheese'">Cheese</button>
          <button class="btn-btn-secondary rounded p-2" @click="filterBy='Italian'">Italian</button>
          <button class="btn-btn-secondary rounded p-2" @click="filterBy='Mexican'">Mexican</button>
          <button class="btn-btn-secondary rounded p-2" @click="filterBy='Specialty Coffee'">Specialty Coffee</button>
          <button class="btn-btn-secondary rounded p-2" @click="filterBy='Soup'">Soup</button>
        </div>
      </div>

      <div class="row">
        <div class="col-4" v-for="recipe in recipes" :key="recipe.id">
          <RecipeCard :recipeProp="recipe"/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Login from "../components/Login.vue";
import Pop from "../utils/Pop.js";
import {recipesService} from '../services/RecipesService.js'
import { computed, onMounted, ref, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import RecipeCard from "../components/RecipeCard.vue";
import { accountService } from "../services/AccountService.js";




export default {
  setup() {
    const sortBy = ref('')
    const filterBy = ref('')

    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      }
      catch (error) {
        return Pop.error(error.message)
      }
    }

    function computeRecipes(sortBy) {
        recipesService.computeRecipes(sortBy.value)
      }

    // async function getMyFavorites() {
    //   try {
    //     await accountService.getMyFavorites()
    //   }
    //   catch (error) {
    //     return Pop.error(error.message)
    //   }
    // }
      

      onMounted(() => {
        getRecipes()
        
      })

    watchEffect(() => {
        if (AppState.account?.id) {
          accountService.getMyFavorites()
      } return{},
        computeRecipes
      })

    return {

      account: computed(() => AppState.account),
      recipes: computed(() => {
        if (filterBy.value == '') {
          return AppState.recipes
        } else {
          return AppState.recipes.filter(a => a.category == filterBy.value)
        }
      }),
    
      filterBy,
        sortBy


      };
    
  },
  components: { Login, RecipeCard }
}
</script>

<style scoped lang="scss">
.hero-img{
  background-image: url(https://www.shutterstock.com/image-photo/healthy-clean-food-cooking-eating-260nw-1847997298.jpg);
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  border-radius: 1%;
  height: 40vh;
  width: 97vw;
}
</style>
