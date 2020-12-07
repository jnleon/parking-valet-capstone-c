<template>
  <b-dropdown
    id="dropdown-form"
    right
    text="Register"
    ref="dropdown"
    class="m-2"
  >
    <b-dropdown-form @submit.prevent="register">
      <b-form-group label="Username" label-for="dropdown-form-username">
        <b-form-input
          id="dropdown-form-username"
          size="sm"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus
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

        <b-form-input
          id="dropdown-form-confirmPassword"
          type="password"
          size="sm"
          placeholder="Confirm Password"
          v-model="user.confirmPassword"
          required
        ></b-form-input>
      </b-form-group>

      <b-button variant="primary" size="sm" type="submit"
        >Create Account</b-button
      >
    </b-dropdown-form>
  </b-dropdown>
</template>

<script>
import authService from "@/services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/valet",
                query: { registration: "success" },
              }); 
              this.user={};
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style>
</style>