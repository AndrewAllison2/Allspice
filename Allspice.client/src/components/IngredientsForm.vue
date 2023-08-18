<template>

  <div class="form-floating my-3 d-flex align-items-center">
    <textarea class="form-control form-control-lg input-font" cols="38" max-length="825" id="floatingIngredientarea" v-model="editable.name"></textarea>
    <label for="floatingIngredientarea" placeholder="Add an Ingredient">Add Ingredient</label>
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

</style>