<template>
  <b-dropdown id="dropdown-form" right text="Login" ref="dropdown" class="m-2">
    <b-dropdown-form size="lg" @submit.prevent="login">
     
        <b-alert style="text-align:center;" show variant="danger" v-if="invalidCredentials">Invalid username and password!</b-alert>
      <b-form-group label="Username" label-for="dropdown-form-username">
        <b-form-input
          id="dropdown-form-username"
          size="sm"
          placeholder="Username"
          v-model="user.username"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group label="Password" label-for="dropdown-form-password">
        <b-form-input
          id="dropdown-form-password"
          type="password"
          size="sm"
          placeholder="Password"
          v-model="user.password"
          required
        ></b-form-input>
      </b-form-group>

      <b-button variant="primary" size="sm" type="submit">Sign In</b-button>
    </b-dropdown-form>
  </b-dropdown>
</template>

<script>
import authService from "@/services/AuthService";

export default {
  name: "login",
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/valet");
            this.user = {};
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style>
:root {
  --li-color: white;
  --li-color-hover: grey;
  --transition-speed: 0.6s;
  --a-color-hover: white;
}

.btn-secondary:hover {
  transition: var(--transition-speed) !important;
  background-color: var(--li-color-hover) !important;
  color: var(--a-color-hover) !important;
}

.btn-secondary {
  background-color: rgb(241, 241, 241) !important;
  color: black !important;
  border: rgb(255, 255, 255) 4fr !important;
  font-weight: 500;
  font-family: "Jua";
  text-transform: uppercase;
  border-color: white !important;
}
</style>