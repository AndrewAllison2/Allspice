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

<SecondaryModal id="editIngredientModal">
<template #header>Edit Ingredient</template>
<template #body>
  <EditIngredientsForm/>
</template>
</SecondaryModal>

<SecondaryModal id="editAccount">
<template #header>Update Account</template>
<template #body>
  <EditAccountForm/>
</template>
</SecondaryModal>
</template>
<script>

import { computed } from 'vue'
import { AppState } from './AppState'


import MainModalComponent from "./components/MainModalComponent.vue";
import SecondaryModal from "./components/SecondaryModal.vue";
import IngredientsForm from "./components/IngredientsForm.vue";
import IngredientsOptionsModal from "./components/IngredientOptionsModal.vue"
import EditIngredientsForm from "./components/EditIngredientsForm.vue";
import EditAccountForm from "./components/EditAccountForm.vue";


export default {
    setup() {
        return {
            appState: computed(() => AppState)
        };
    },
    components: { MainModalComponent, SecondaryModal, IngredientsForm, IngredientsOptionsModal, EditIngredientsForm, EditAccountForm }
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
