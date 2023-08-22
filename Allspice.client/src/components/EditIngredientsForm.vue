<template>

<div class="text-center mb-3">
  <h4>{{ activeIngredient?.quantity }} {{ activeIngredient?.name }}</h4>
</div>
  <div>
  <form action="" @submit.prevent="editIngredient()">

      <div class="form-floating mb-3">
        <input type="text" class="form-control" :required="editable.quantity" id="ingredientQuantity" placeholder="Add an ingredient!" v-model="editable.quantity">
        <label for="ingredientQuantity">Quantity of Ingredient</label>
      </div>

      <div class="form-floating mb-3">
        <input type="text" class="form-control" :required="editable.name" placeholder="Add an ingredient!" v-model="editable.name">
        <label for="ingredientName">Name of Ingredient</label>
      </div>
      
        <button class="btn back-button" :disabled="editable.quantity == null || editable.name == null" data-bs-target="#exampleModal" data-bs-toggle="modal">Update Ingredient</button>
      
    </form>

</div>

</template>


<script>
import {computed, ref } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { ingredientsService } from "../services/IngredientsService.js";

export default {
  setup() {
    const editable = ref({})


    return {
      editable,
      activeIngredient: computed(()=> AppState.activeIngredient),

      async editIngredient() {
        try 
        {
          const formData = editable.value
          const ingredientId = AppState.activeIngredient.id
          await ingredientsService.editIngredient(formData, ingredientId)
          await ingredientsService.getIngredientsByRecipeId(AppState.activeRecipe.id)
          editable.value = {}

        }
        catch (error)
        {
          return Pop.error(error.message)
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>

</style>