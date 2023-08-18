<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-4 p-0">
        <img class="img-fluid recipe-img" :src="activeRecipe?.imgUrl" :alt="activeRecipe?.title">
      </div>

      <div class="col-8 p-3">
        <div class="d-flex justify-content-end mb-3">
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>

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
              <p class="mb-0 p-2">{{ activeRecipe?.instructions }}</p>
            </div>
          </div>


          <div class="col-5 card p-0">
            <div class="text-center text-white card-background">
              <h4 class="mt-1">Ingredients</h4>
            </div>
            <div class="text-center card-secondary-background">
              <ul v-for="i in ingredients" :key="i.id">
                <li>
                  <p class="p-2 mb-1">{{ i?.quantity }} {{ i?.name }}</p>
                </li>
              </ul>
            </div>
            
          </div>
        </div>
        <p class="text-end">Published By: {{ activeRecipe?.creator.name }}</p>
      </div>
    </div>
  </div>

</template>


<script>
import { computed} from "vue";
import { AppState } from "../AppState.js";




export default {

  
  

  setup() {

    
    
    return {
      activeRecipe: computed(() => AppState.activeRecipe),
      ingredients: computed(()=> AppState.ingredients)
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