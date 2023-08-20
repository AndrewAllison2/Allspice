<template>
  <div class="modal fade" id="AddIngredientModal" aria-hidden="true" aria-labelledby="exampleModalToggleLabel2" tabindex="-1">
  <div class="modal-dialog modal-dialog-centered">


    <div class="modal-content modal-elem">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalToggleLabel2">
          <slot name="header"></slot>
        </h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">

        <slot name="body"></slot>
        
      </div>
      <button class="btn back-button" data-bs-target="#exampleModal" data-bs-toggle="modal">Back to Recipe</button>
      
    </div>
  </div>
</div>
</template>


<script>
// import IngredientsForm from "./IngredientsForm.vue";

export default {
    setup() {
        return {};
    },
    // components: { IngredientsForm }
}
</script>


<style lang="scss" scoped>
.back-button{
  background-color: #527360;
  color: white;
  height: 4em;
}

.modal-elem{
  // border: 2px solid black;
  box-shadow: 2px 2px white;
}
</style>