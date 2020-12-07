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
            <b-dropdown
              id="dropdown-form"
              right
              text="Register"
              ref="dropdown"
              class="m-2"
            >
              <b-dropdown-form>
                <b-form-group
                  label="Email"
                  label-for="dropdown-form-email"
                  @submit.stop.prevent
                >
                  <b-form-input
                    id="dropdown-form-email"
                    size="sm"
                    placeholder="email@example.com"
                  ></b-form-input>
                </b-form-group>

                <b-form-group
                  label="Password"
                  label-for="dropdown-form-password"
                >
                  <b-form-input
                    id="dropdown-form-password"
                    type="password"
                    size="sm"
                    placeholder="Password"
                  ></b-form-input>

                  <b-form-input
                    id="dropdown-form-confirmPassword"
                    type="password"
                    size="sm"
                    placeholder="Confirm Password"
                  ></b-form-input>
                </b-form-group>

                <b-button variant="primary" size="sm" @click="onClick"
                  >Create Account</b-button
                >
              </b-dropdown-form>
            </b-dropdown>

            <b-dropdown
              id="dropdown-form"
              right
              text="Login"
              ref="dropdown"
              class="m-2"
            >
              <b-dropdown-form size="lg">
                <b-form-group
                  label="Email"
                  label-for="dropdown-form-email"
                  @submit.stop.prevent
                >
                  <b-form-input
                    id="dropdown-form-email"
                    size="sm"
                    placeholder="email@example.com"
                  ></b-form-input>
                </b-form-group>

                <b-form-group
                  label="Password"
                  label-for="dropdown-form-password"
                >
                  <b-form-input
                    id="dropdown-form-password"
                    type="password"
                    size="sm"
                    placeholder="Password"
                  ></b-form-input>
                </b-form-group>

                <b-button variant="primary" size="sm" @click="onClick"
                  >Sign In</b-button
                >
              </b-dropdown-form>
            </b-dropdown>

            <!-- Using 'button-content' slot -->
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>

    <router-view class="routerV" />
  </div>
</template>

<style >
.navbar-light {
  background-color: orange !important;
}

.dropdown-menu {
  min-width: 12.2rem !important;
}

:root {
  --li-color: white;
  --li-color-hover: rgb(255, 145, 0);
  --transition-speed: 0.6s;
  --a-color: red;
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

ul li:hover {
  transition: var(--transition-speed);
  background-color: var(--li-color-hover);
}

ul li a:hover {
  transition: var(--transition-speed);
  color: var(--a-color-hover);
}
</style>
