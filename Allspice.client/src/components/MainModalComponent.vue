<template>
  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl">
    
    <div class="modal-content">
      <div class="modal-body p-0">
        <RecipeDetails/>
      </div>
    </div>
  </div>
</div>
</template>


<script>
import RecipeDetails from "./RecipeDetails.vue";

export default {
    setup() {
        return {};
    },
    components: { RecipeDetails }
}
</script>


<style lang="scss" scoped>

</style>