<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 mt-2 selectable" data-bs-toggle="modal" data-bs-target="#exampleModal" @click="setActiveRecipe(this.recipeProp)" >
        <img class="recipe-img img-fluid" :src="recipeProp.imgUrl" alt="">

        <div class="category-elem">
          <p class="text-center text-white">
            {{ recipeProp.category }}
          </p>
        </div>

        <div class="favorite-elem text-center text-danger">
          <i class="mdi mdi-heart fs-4"></i>
        </div>

        <div class="info-elem">
          <div class="text-center text-white">
            <h5 class="m-0">{{ recipeProp.title }}</h5>
            
          </div>
        </div>

        </div>
      </div>
    </div>
  
</template>


<script>
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";


export default {
  props: {
    recipeProp: {type: Recipe, required: true}
  },


  setup(props) {


    
    return {

      setActiveRecipe() {
        recipesService.setActiveRecipe(props.recipeProp)
      }

    }
  }
}
</script>


<style lang="scss" scoped>

.recipe-img{
  width: 100%;
  height: 15em;
  object-fit: cover;
  border-radius: 2px;
  background-attachment: fixed;
}

.category-elem{
  background-color: gray;
  border-radius: 2px;
  position: relative;
  width: 42%;
  top: -229px;
  left: 10px;
}

.favorite-elem{
  background-color: gray;
  border-radius: 2px;
  position: relative;
  width: 12%;
  top: -17.5em;
  left: 24em;
}

.info-elem{
  background-color: gray;
  border-radius: 2px;
  position: relative;
  width: 75%;
  height: 2em;
  bottom: 5.7em;
  left: 3.4em;
}

</style>