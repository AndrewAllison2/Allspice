<template>
  <h1>{{ recipeProp.title }}</h1>
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

</style>