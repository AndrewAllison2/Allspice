<template>
  
  <main>
    <router-view />
  </main>
   
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
