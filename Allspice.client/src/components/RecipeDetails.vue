<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-5">
        <img src="" alt="">
      </div>

      <div class="col-7">
        Recipe
        <!-- <h1>{{ activeRecipe.title }}</h1> -->
      </div>
    </div>
  </div>

</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";



export default {
  

  setup(){
    return {
      activeRecipe: computed(()=> AppState.activeRecipe)
    }
  }
}
</script>


<style lang="scss" scoped>

</style>