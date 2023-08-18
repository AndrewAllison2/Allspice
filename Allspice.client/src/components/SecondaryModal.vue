<template>
  <div class="modal fade" id="exampleModalToggle2" aria-hidden="true" aria-labelledby="exampleModalToggleLabel2" tabindex="-1">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalToggleLabel2">Add Ingredient</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <IngredientsForm/>
      </div>
      <div class="modal-footer">
        <button class="btn back-button" data-bs-target="#exampleModal" data-bs-toggle="modal">Back to Recipe</button>
      </div>
    </div>
  </div>
</div>
</template>


<script>
import IngredientsForm from "./IngredientsForm.vue";

export default {
    setup() {
        return {};
    },
    components: { IngredientsForm }
}
</script>


<style lang="scss" scoped>
.back-button{
  background-color: #527360;
  color: white;
}
</style>