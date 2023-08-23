<template>
  <div class="container-fluid">
    <div class="row">

      <!-- SECTION RECIPE IMG/LIKE BTN -->
      <div class="col-4 p-0">
        <img class="img-fluid recipe-img" :src="activeRecipe?.imgUrl" :alt="activeRecipe?.title">
      </div>

      <!-- SECTION RECIPE DETAILS/FORMS -->
      <div class="col-8 p-3">
        <div class="d-flex justify-content-end">
          <div class="favorite-elem text-center">
            <i v-if="isFavorite == true" class="mdi mdi-heart fs-2 selectable" title="Remove from favorites" @click="removeFavorite(activeRecipe.id)"></i>
          <i v-else class="mdi mdi-heart-outline fs-2 selectable" title="Add to favorites" @click="createFavorite()"></i>
        </div>
        <div class="align-items-center">
          <i class="mdi mdi-delete fs-4 selectable" title="Delete Recipe" selectable @click="removeRecipe()"></i>
          <button type="button" class="btn-close ms-2" title="Close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
          
        </div>

        <!-- SECTION RECIPE INFO -->
        <div class="d-flex align-items-center justify-content-between mb-4">
          <h1>{{ activeRecipe?.title }}</h1>
          <p class="category-elem text-white">{{ activeRecipe?.category }}</p>
        </div>

        <!-- SECTION RECIPE STEPS -->
        <div class="row justify-content-around">
          <div class="col-6 card elevation-4 p-0">
            <div class="text-center text-white card-background">
              <h4 class="mt-1">Recipe Steps</h4>
            </div>
            <div class="card-secondary-background d-flex flex-column justify-content-between">
              <div class="text-center">
                <p class="mb-0 p-2">{{ activeRecipe?.instructions }}</p>
              </div>
              <div class="ps-2">
                <!-- recipe steps form component here -->
                <RecipeStepsForm/>
              </div>
            </div>
          </div>

          <!-- SECTION INGREDIENTS -->
          <div class="col-5 card elevation-4 p-0">
            <div class="text-center text-white card-background ">
              <h4 class="mt-1 text-center">Ingredients</h4>
            </div>
            <div class="card-secondary-background">
              <div class="text-center">
                <ul v-for="i in ingredients" :key="i.id">
                  <li>
                    <p v-if="i.creatorId == account.id" class="p-2 mb-1 selectable" @click="setActiveIngredient(i)" data-bs-toggle="modal" data-bs-target="#IngredientsOptions">{{ i?.quantity }} {{ i?.name }}</p>
                    <p v-else class="p-2 mb-1">{{ i?.quantity }} {{ i?.name }}</p>

                  </li>
                </ul>
              </div>
            </div>
            <div class="card-background text-center">
              <i v-if="activeRecipe?.creatorId == account?.id" class="mdi mdi-plus fs-4 selectable text-white" title="Add an Ingredient" data-bs-target="#AddIngredientModal" data-bs-toggle="modal"> Add Ingredient</i>
            </div>
          </div>

        </div>

        <p class="text-end mt-2 mb-0 pe-2">Published By: {{ activeRecipe?.creator?.name }}</p>

      </div>
    </div>
  </div>

</template>


<script>
import { computed, onMounted, watchEffect} from "vue";
import { AppState } from "../AppState.js";
import RecipeStepsForm from "./RecipeStepsForm.vue";
import { ingredientsService } from "../services/IngredientsService.js";
import {favoritesService} from "../services/FavoritesService.js"

import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";
import { Modal } from "bootstrap";
import { accountService } from "../services/AccountService.js";




export default {
  setup() {


    
        return {
          activeRecipe: computed(() => AppState.activeRecipe),
          // TODO COMPUTED CONDITIONALS 
          ingredients: computed(() => AppState.ingredients),
          activeIngredient: computed(() => AppState.activeIngredient),
          favorites: computed(() => AppState.favorites),
          account: computed(() => AppState.account),
          isFavorite: computed(() => {
            let activeFav = AppState.favorites.find(f => f.recipeId == AppState.activeRecipe?.id)
            if (activeFav) {
              return true
            } return false
          }),


          
          async createFavorite() {
              try 
              {
              const activeRecipe = AppState.activeRecipe
              const recipeId = AppState.activeRecipe.id
              const formData = {recipeId: recipeId}
              // const accountId = AppState.account.id
                await favoritesService.createFavorite(formData)
                await accountService.getMyFavorites
              Pop.toast(`${activeRecipe.title} has been added to your favorites!`)
              }
              catch (error)
              {
                return Pop.error(error.message)
              }
          },

          async removeFavorite(recipeId) {
            try 
            {
              if (!await Pop.confirm('Unfavorite this Recipe?')) {
                return
              }
              const favorite = AppState.favorites.find(f => f.recipeId == recipeId)
              await favoritesService.removeFavorite(favorite.id)
              Pop.toast(`${this.activeRecipe.title} has been removed from your favorites!`)
            }
            catch (error)
            {
              return Pop.error(error.message)
            }
          },

          setActiveIngredient(ingredient){
            ingredientsService.setActiveIngredient(ingredient)
          },

          async removeRecipe() {
            try 
            {
              if (!await Pop.confirm('Are you sure you want to delete this recipe?')) {
                return
              }
              const recipeToRemove = AppState.activeRecipe
              const recipeId = AppState.activeRecipe.id
              await recipesService.removeRecipe(recipeId)
              Modal.getOrCreateInstance('#exampleModal').hide()
              Pop.toast(`${recipeToRemove.title} has been deleted!`)
            }
            catch (error)
            {
              return Pop.error(error.message)
            }
          },


        };
    },
    components: { RecipeStepsForm}
}
</script>


<style lang="scss" scoped>

.recipe-img{
  object-fit: cover;
  object-position: center;

  width: 100%;
  height: 41.5em;
}

.category-elem{
  background-color: gray;
  border-radius: 2px;
  padding: .5em;
}

.card-background{
  background-color: #527360;
}

.card-secondary-background{
  background-color: #F0F4F2;
  height: 100%;
}

.favorite-elem{
  background-color: gray;
  border-radius: 2px;
  position: relative;
  width: 8%;
  top: -1.0em;
  left: -45.5em;
}

.card{
  height: 27.2em;
}

</style>