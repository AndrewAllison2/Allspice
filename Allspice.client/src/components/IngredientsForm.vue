<template>

  <form action="" @submit.prevent="addIngredient()">

      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="ingredientQuantity" placeholder="Add an ingredient!" v-model="editable.quantity">
        <label for="ingredientQuantity">Quantity of Ingredient</label>
      </div>

      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="ingredientName" placeholder="Add an ingredient!" v-model="editable.name">
        <label for="ingredientName">Name of Ingredient</label>
      </div>

      <button>Add Ingredient</button>

  </form>

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
          const recipeId = AppState.activeRecipe.id
          formData.recipeId = recipeId
          await ingredientsService.addIngredient(formData)
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