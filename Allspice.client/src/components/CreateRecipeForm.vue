<template>

  <form action="" @submit.prevent="createRecipe()">

      <div class="form-floating mb-3">
        <input type="text" class="form-control" :required="editable.title" id="recipeTitle" placeholder="Name of Recipe" v-model="editable.title">
        <label for="recipeTitle">Recipe Title</label>
      </div>

      <div class="form-floating mb-3">
        <input type="text" class="form-control" :required="editable.instructions" placeholder="Add Instructions!" v-model="editable.instructions" id="recipeInstructions">
        <label for="recipeInstructions">Instructions</label>
      </div>

      <div class="form-floating mb-3">
        <input type="text" class="form-control" :required="editable.img" placeholder="Add an Image!" v-model="editable.img" id="recipeImg">
        <label for="recipeImg">Add an Image</label>
      </div>

      <div class="mb-3">
        <label for="recipeCategory">Pick A Category</label>
        <select class="form-control" :required="editable.category" placeholder="Pick A Category" v-model="editable.category" id="recipeCategory">
          <option v-for="category in categories" :key="category" value="category">{{ category }}</option>
        </select>
      </div>
      
        <button class="btn back-button" data-bs-target="#createRecipe" data-bs-toggle="modal" >Add Recipe</button>
      
    </form>


</template>


<script>
import { ref } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";



export default {

  setup() {
    const editable = ref({})



    return {
      editable,
      categories: ['Mexican', 'Specialty Coffee', 'Soup', 'Italian', 'Cheese'],

      async createRecipe() {
        try 
        {
          const formData = editable.value
          await recipesService.createRecipe(formData)
          
          
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
