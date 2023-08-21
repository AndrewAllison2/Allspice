<template>
  <form @submit.prevent="editAccount()">
    <div class="mb-2">
        <label for="name">Name</label>
        <input class="form-control" type="text" id="name" minlength="3" maxlength="75" v-model="editable.name">
      </div>
      <div class="mb-2">
        <label for="email">Email</label>
        <input v-model="editable.email" type="text" class="form-control" name="email" id="email">
      </div>
      <div class="mb-2">
        <label for="picture">Picture</label>
        <input class="form-control" type="url" id="picture" minlength="3" maxlength="200" v-model="editable.picture">
      </div>
      <button type="submit">Update</button>
  </form>
</template>


<script>
import { ref } from "vue"
import { accountService } from "../services/AccountService.js"
import Pop from "../utils/Pop.js"
import { Modal } from "bootstrap"

export default {
  setup() {
    const editable = ref({})
    return {
      editable,


        async editAccount() {
        try 
        {
          const formData = editable.value
          await accountService.editAccount(formData)
          Modal.getOrCreateInstance('#editAccount').hide()
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