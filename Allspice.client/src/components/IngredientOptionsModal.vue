<template>

  <div class="modal fade " id="IngredientsOptions" tabindex="-1" aria-labelledby="ingredientsOptions" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content modal-elem">
      <div class="modal-header back-button">
        <h3 class="modal-title text-center" id="ingredientsOptions">{{activeIngredient?.quantity}} {{ activeIngredient?.name }}</h3>
      </div>
      <div class="modal-body">
        <div class="d-flex flex-column justify-content-between align-items-center p-1">

          <div class="mb-3">
            <button class="btn btn-primary">Edit</button>
          </div>

          <div class="mb-3">
            <button class="btn btn-danger" @click="removeIngredient()">Delete</button>
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
import Pop from "../utils/Pop.js";
import { ingredientsService } from "../services/IngredientsService.js";
import { Modal } from "bootstrap";

export default {
  setup(){
    return {
      activeIngredient: computed(() => AppState.activeIngredient),

      async removeIngredient() {
        try 
        {
          if (await Pop.confirm("Are you sure you want to remove this ingredient?")) {
            const ingredientId = AppState.activeIngredient.id
            await ingredientsService.removeIngredient(ingredientId)
            this.openRecipeModal()
          } return
        }
        catch (error)
        {
          return Pop.error(error.message)
        }
      },

      openRecipeModal() {
        Modal.getOrCreateInstance('#IngredientsOptions').hide()
        Modal.getOrCreateInstance('#exampleModal').show()
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

.modal-elem{
  box-shadow: 2px 2px #ffffff;
}
</style>