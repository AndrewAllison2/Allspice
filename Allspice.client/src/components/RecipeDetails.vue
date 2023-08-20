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
          <i class="mdi mdi-heart-outline fs-2 selectable" title="Add to favorites" @click="CreateFavorite()"></i>
        </div>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          
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
                    <p class="p-2 mb-1">{{ i?.quantity }} {{ i?.name }}</p>
                  </li>
                </ul>
              </div>
            </div>
            <div class="card-background text-center">
              <i class="mdi mdi-plus fs-4 selectable text-white" title="Add an Ingredient" data-bs-target="#exampleModalToggle2" data-bs-toggle="modal"> Add Ingredient</i>
            </div>
          </div>

        </div>

        <p class="text-end mt-2 mb-0 pe-2">Published By: {{ activeRecipe?.creator?.name }}</p>

      </div>
    </div>
  </div>

</template>


<script>
import { computed} from "vue";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import RecipeStepsForm from "./RecipeStepsForm.vue";




export default {
  setup() {
    
        return {
          activeRecipe: computed(() => AppState.activeRecipe),
          // TODO COMPUTED CONDITIONALS 
          ingredients: computed(() => AppState.ingredients),

          
            async CreateFavorite() {
                logger.log('Gonna make a fave!');
            }
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
  height: 41.3em;
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
  width: 12%;
  top: -1.0em;
  left: -45.5em;
}

.card{
  height: 27.2em;
}

</style>