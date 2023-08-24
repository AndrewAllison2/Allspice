<template>

  <div class="modal fade " id="IngredientsOptions" tabindex="-1" aria-labelledby="ingredientsOptions" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content modal-elem">
      <div class="modal-header back-button">
        <h3 class="modal-title text-center" id="ingredientsOptionsModal">{{activeIngredient?.quantity}} {{ activeIngredient?.name }}</h3>
      </div>
      <div class="modal-body">
        <div class="d-flex flex-column justify-content-between align-items-center p-1">

          <div class="mb-3">
            <button class="btn edit-button" data-bs-target="#editIngredientModal" data-bs-toggle="modal">Edit</button>
          </div>

          <div class="mb-3">
            <button class="btn delete-button" @click="removeIngredient()">Delete</button>
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
            const ingredient = AppState.activeIngredient
            const ingredientId = ingredient.id
            await ingredientsService.removeIngredient(ingredientId)
            await ingredientsService.getIngredientsByRecipeId(AppState.activeRecipe.id)
            this.openRecipeModal()
            Pop.toast(`${ingredient.quantity} ${ingredient.name} was removed from your list!`)
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

.edit-button{
  color: white;
  background-color: rgb(29, 119, 255);
}
.edit-button:hover{
    border: 2px solid rgb(29, 119, 255);
    color: rgb(29, 119, 255);
    background-color: white;
}

.delete-button{
  color: white;
  background-color: red;
}
.delete-button:hover{
  border: 2px solid red;
  color: red;
  background-color: white;
}
</style>