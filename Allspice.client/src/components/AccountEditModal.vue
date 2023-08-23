<template>

  <div class="modal fade" id="editAccount" aria-hidden="true" aria-labelledby="exampleModalToggleLabel2" tabindex="-1">
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
      
      
    </div>
  </div>
</div>

</template>


<script>
export default {
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>