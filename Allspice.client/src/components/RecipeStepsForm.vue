<template>

  <div class="form-floating my-3 d-flex align-items-center">
    <textarea class="form-control form-control-lg" cols="25" placeholder="Add a step" id="floatingTextarea"></textarea>
    <label for="floatingTextarea">Add Step</label>
    <i class="mdi mdi-plus fs-3 selectable" title="Add Step" @click="addStepToRecipe()"></i>
                
  </div>

</template>


<script>
import { logger } from "../utils/Logger.js";

export default {
  setup(){
    return {

      async addStepToRecipe() {
        logger.log('clicked the button!')
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>