<template>
  
  <main>
    <router-view />
  </main>
   
  <!-- SECTION RECIPE MODAL -->
  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl">
    <div class="modal-content">
      
      <div class="modal-body p-0">
        <RecipeDetails/>
      </div>
        <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button> -->
    </div>
  </div>
</div>

<!-- SECTION INGREDIENT FORM MODAL -->

<div class="modal fade" id="exampleModalToggle2" aria-hidden="true" aria-labelledby="exampleModalToggleLabel2" tabindex="-1">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalToggleLabel2">Modal 2</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        Hide this modal and show the first with the button below.
      </div>
      <div class="modal-footer">
        <button class="btn btn-primary" data-bs-target="#exampleModal" data-bs-toggle="modal">Back to first</button>
      </div>
    </div>
  </div>
</div>
<!-- <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModalToggle" role="button">Open first modal</button> -->


</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import RecipeDetails from "./components/RecipeDetails.vue";


export default {
    setup() {
        return {
            appState: computed(() => AppState)
        };
    },
    components: { RecipeDetails }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
