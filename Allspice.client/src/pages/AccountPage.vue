<template>
  <div class=" background-img">

    <div class="container-fluid">
      <div class="row">
        <div class="col-12 m-auto">
          <div class="about text-center">
            <h1 class="mb-3">Welcome {{ account.name }}</h1>
            <img class="avatar mb-3" :src="account.picture" alt="" />
            <p>{{ account.email }}</p>
          </div>
        </div>
      </div>
    
      <div class="row">
        <div class="col-2 m-auto text-center d-flex flex-column">
  
          <button class="btn btn-info mb-4" data-bs-target="#editAccount" data-bs-toggle="modal">Edit Account</button>
          <router-link :to="{name: 'Home'}">
            <button class="btn back-button">Home</button>
          </router-link>
        </div>
    
      </div>
  
    </div>

  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';

export default {
  setup() {



    return {
      account: computed(() => AppState.account),
    }
  }
}
</script>

<style scoped>
button{
  width: 100%;
}
.avatar{
  height: 20em;
  border-radius: 50%;
}

.background-img{
  background-image: url(https://d39l2hkdp2esp1.cloudfront.net/img/photo/174350/174350_00_2x.jpg);
  background-repeat: no-repeat;
  background-size: cover;
  height: 100vh;
}
</style>
