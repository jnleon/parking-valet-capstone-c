<template>
  <div id="app">
    <div id="headerBar">
      <b-navbar toggleable="lg" type="light" variant="infoBar">
        <router-link v-bind:to="{ name: 'home' }"
          ><img id="headerlogo" src="@/img/jjebTitle.png" alt="Kitten"
        /></router-link>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <!-- Right aligned nav items -->
          <b-navbar-nav class="ml-auto">
           
            <registration-button/>

           <login-button/>
            <!-- Using 'button-content' slot -->
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>

    <router-view class="routerV" />
  </div>
</template>

<script>
import RegistrationButton from "@/components/RegistrationButton.vue";
import LoginButton from "@/components/LoginButton.vue";

export default {
 
  components: {
    RegistrationButton, LoginButton
  },
};
</script>


<style >

.navbar-light {
  background-color: #ffa500 !important;
}

.dropdown-menu {
  min-width: 12rem !important;
}

:root {
  --li-color: white;
  --transition-speed: 0.6s;
  --a-color-hover: white;
}

@import url("https://fonts.googleapis.com/css2?family=Jua&display=swap");

#headerBar {
  grid-area: header;
  display: inline-block;
}

#app {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
  grid-template-areas:
    "header header header header header"
    "content content content content content";
  grid-gap: 10px;
  height: fit-content;
}
.routerV {
  grid-area: content;
}

#headerlogo {
  max-width: 190px;
  size: fixed;
  padding-left: 5%;
  display: inline-block;
}

</style>
