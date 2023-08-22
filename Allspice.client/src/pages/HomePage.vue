<template>
  <div class="container-fluid">

    <div class="row">
      <div class="hero-img m-auto my-4">
        <div class="col-12 m-auto">

          <div class="d-flex justify-content-end align-items-center">

            <div class="me-3 mt-1">
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
import { computed, onMounted} from "vue";
import { AppState } from "../AppState.js";
import RecipeCard from "../components/RecipeCard.vue";



export default {
  setup() {

    async function getRecipes(){
      try 
      {
        await recipesService.getRecipes()
      }
      catch (error)
      {
        return Pop.error(error.message)
      }
    }

    onMounted(() => {
      getRecipes()
    })
    
    return {

      recipes: computed(() => AppState.recipes),

      
        };
    },
    components: { Login, RecipeCard }
}
</script>

<style scoped lang="scss">
.hero-img{
  background-image: url(https://images.unsplash.com/photo-1466637574441-749b8f19452f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fGNvb2tpbmclMjBzdGF0aW9ufGVufDB8fDB8fHww&auto=format&fit=crop&w=500&q=60);
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  border-radius: 1%;
  height: 40vh;
  width: 97vw;
}
</style>
