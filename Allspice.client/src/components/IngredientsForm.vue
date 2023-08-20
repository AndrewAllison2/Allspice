<template>

<div>
  <form action="" @submit.prevent="addIngredient()">

      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="ingredientQuantity" placeholder="Add an ingredient!" v-model="editable.quantity">
        <label for="ingredientQuantity">Quantity of Ingredient</label>
      </div>

      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="ingredientName" required placeholder="Add an ingredient!" v-model="editable.name">
        <label for="ingredientName">Name of Ingredient</label>
      </div>
      
        <button class="btn back-button" data-bs-target="#exampleModal" data-bs-toggle="modal">Add Ingredient</button>
      
    </form>

</div>
    
</template>


<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import { ingredientsService } from "../services/IngredientsService.js";


export default {
  setup() {
    const editable = ref({})


    return {
      editable,

      async addIngredient() {
        try 
        {
          const formData = editable.value
          const creatorId = AppState.account.id
          const recipeId = AppState.activeRecipe.id
          formData.recipeId = recipeId
          formData.creatorId = creatorId
          await ingredientsService.addIngredient(formData)
          editable.value = {}
        }
        catch (error)
        {
          return Pop.error(error.message)
        }
      }
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