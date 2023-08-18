<template>

  <div class="form-floating my-3 d-flex align-items-center">
    <textarea class="form-control form-control-lg input-font" cols="38" max-length="825" id="floatingTextarea" v-model="editable.instructions"></textarea>
    <label for="floatingTextarea" placeholder="Add a step">Add Step</label>
    <i class="mdi mdi-plus fs-3 selectable" title="Add Step" @click="editRecipeInstructions()"></i>
  </div>

</template>


<script>
import { ref, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({})

    watchEffect(() => {
      if (AppState.activeRecipe) {
        const recipeToEdit = { ...AppState.activeRecipe }
        editable.value = recipeToEdit
      }
    })

    return {
      editable,


      async editRecipeInstructions() {
        try 
        {
          const formData = editable.value
          const recipeId = AppState.activeRecipe.id
          await recipesService.editRecipeInstructions(formData, recipeId)
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

.input-font{
  font-size: medium;
}
</style>