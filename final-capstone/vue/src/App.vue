<template>
  <div id="app">
    <div id="headerBar">
      <b-navbar fixed="top" toggleable="lg" type="light" variant="infoBar">
        <router-link v-bind:to="{ name: 'home' }"
          ><img id="headerlogo" src="@/img/jjebTitle.png" alt="Kitten"
        /></router-link>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <!-- Right aligned nav items -->
          <b-navbar-nav class="ml-auto">
            <registration-button v-if="$store.state.token === ''" />

            <login-button v-if="$store.state.token === ''" />
            <!-- Using 'button-content' slot -->
            <b-dropdown
              right
              text="Logout"
              id="logoutButtonDPD"
              min-width="12rem"
              v-if="$store.state.token !== ''"
            >
              <b-dropdown-header id="dropdown-header-label">
                Are you sure?
              </b-dropdown-header>
              <b-dropdown-divider></b-dropdown-divider>
              <b-dropdown-item v-bind:to="{ name: 'logout' }" href="#">
                <b-icon icon="power" aria-hidden="true"></b-icon>
                Logout</b-dropdown-item
              >
            </b-dropdown>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
    <router-view class="routerV" />
    <footer-thing-component class="footer" />
  </div>
</template>

<script>
import RegistrationButton from "@/components/topbarFooter/RegistrationButton.vue";
import LoginButton from "@/components/topbarFooter/LoginButton.vue";
import FooterThingComponent from "@/components/topbarFooter/Footer.vue";

export default {
  components: {
    RegistrationButton,
    LoginButton,
    FooterThingComponent,
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

@import url("https://fonts.googleapis.com/css2?family=Jua&display=swap");

#app {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
  grid-template-areas:
    "header header header header header"
    "content content content content content"
    "footer footer footer footer footer";
  grid-gap: 10px;
  height: fit-content;
  background-color: rgb(246, 246, 246);

  padding-top: 70px;
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

.footer {
  grid-area: footer;
}
</style>
