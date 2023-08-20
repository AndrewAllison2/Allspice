<template>
  
  <main>
    <router-view />
  </main>

  <!-- SECTION RECIPE MODAL -->

  <MainModalComponent/>

<!-- SECTION INGREDIENT FORM MODAL -->

<SecondaryModal id="AddIngredientModal">
<template #header>Add Ingredient</template>
<template #body>
  <IngredientsForm />
</template>
</SecondaryModal>

<IngredientsOptionsModal id="IngredientsOptions">
  <template #header>Add Ingredient</template>
<template #body>
  
</template>
</IngredientsOptionsModal>

</template>
<script>

import { computed } from 'vue'
import { AppState } from './AppState'


import MainModalComponent from "./components/MainModalComponent.vue";
import SecondaryModal from "./components/SecondaryModal.vue";
import IngredientsForm from "./components/IngredientsForm.vue";
import IngredientsOptionsModal from "./components/IngredientOptionsModal.vue"


export default {
    setup() {
        return {
            appState: computed(() => AppState)
        };
    },
    components: { MainModalComponent, SecondaryModal, IngredientsForm, IngredientsOptionsModal}
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
