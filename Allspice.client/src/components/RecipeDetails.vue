<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-4">
        <img class="img-fluid recipe-img" :src="activeRecipe?.imgUrl" :alt="activeRecipe?.title">
      </div>

      <div class="col-8">
        <div class="d-flex align-items-center justify-content-between mb-4">
          <h1>{{ activeRecipe?.title }}</h1>
          <p class="category-elem text-white">{{ activeRecipe?.category }}</p>
        </div>

        <div class="row justify-content-around">
          <div class="col-5 card p-0">
            <div class="text-center text-white card-background">
              <h4 class="mt-1">Recipe Steps</h4>
            </div>
            <div class="text-center card-secondary-background">
              <p class="mb-0 p-1">{{ activeRecipe?.instructions }}</p>
            </div>
          </div>


          <div class="col-5 card p-0">
            <div class="text-center text-white card-background">
              <h4 class="mt-1">Ingredients</h4>
            </div>
            <div class="text-center card-secondary-background">
              <p class="mb-0 p-1">Ingredients</p>
            </div>
            
          </div>
        </div>
        <p class="text-end">Published By: {{ activeRecipe?.creator.name }}</p>
      </div>
    </div>
  </div>

</template>


<script>
import { computed, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import {ingredientsService} from "../services/IngredientsService.js"



export default {

  
  

  setup() {

    
    
    return {
      activeRecipe: computed(()=> AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped>

.recipe-img{
  object-fit: cover;
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

}

</style>