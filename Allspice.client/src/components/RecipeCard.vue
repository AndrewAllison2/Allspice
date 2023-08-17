<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 my-2 selectable">
        <img class="recipe-img img-fluid" :src="recipeProp.imgUrl" alt="">

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

</style>