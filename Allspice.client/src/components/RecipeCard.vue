<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 my-2 selectable">
        <img class="recipe-img img-fluid" :src="recipeProp.imgUrl" alt="">

        <div class="category-elem">
          <h5 class="text-center text-white">
            {{ recipeProp.category }}
          </h5>
        </div>

        <div class="favorite-elem text-center text-danger">
          <i class="mdi mdi-heart fs-4"></i>
        </div>

        <div class="info-elem">
          <div class="text-center">
            <h5>{{ recipeProp.title }}</h5>
            
          </div>
        </div>

        </div>
      </div>
    </div>
  
</template>


<script>
import { Recipe } from "../models/Recipe.js";

export default {
  props: {
    recipeProp: {type: Recipe, required: true}
  },


  setup() {


    
    return {

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
  top: -17em;
  left: 24em;
}

</style>