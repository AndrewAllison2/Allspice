<template>

  <div class="modal fade" id="IngredientsOptions" tabindex="-1" aria-labelledby="ingredientsOptions" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h3 class="modal-title text-center" id="ingredientsOptions">{{activeIngredient.quantity}} of {{ activeIngredient?.name }}</h3>
      </div>
      <div class="modal-body">
        <div class="d-flex flex-column justify-content-between align-items-center p-1">

          <div class="mb-3">
            <button class="btn btn-primary">Edit</button>
          </div>

          <div class="mb-3">
            <button class="btn btn-danger">Delete</button>
          </div>

          <div class="mb3">
            <button class="btn back-button" data-bs-target="#exampleModal" data-bs-toggle="modal">Back to Recipe</button>
          </div>

        </div>
      </div>
      
        
      
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
      activeIngredient: computed(()=> AppState.activeIngredient)
    }
  }
}
</script>


<style lang="scss" scoped>
.back-button{
  background-color: #527360;
  color: white;
}
</style>