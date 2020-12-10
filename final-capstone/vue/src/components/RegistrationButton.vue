<template>
  <b-dropdown
    id="dropdown-form"
    right
    text="Register"
    ref="dropdown"
    class="m-2"
  >

   <b-alert :show="6"  class="alertsRegist" variant="success" v-if="registrationCorrect">User Registered</b-alert>
    <b-alert :show="6" class="alertsRegist" variant="danger" v-if="registrationErrors">{{registrationErrorMsg}}</b-alert>
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

 <b-form-group label="First Name" label-for="dropdown-form-username">
        <b-form-input
          id="dropdown-form-username"
          size="sm"
          placeholder="firstname"
          v-model="user.firstname"
          required
        ></b-form-input>
      </b-form-group>

       <b-form-group label="Last Name" label-for="dropdown-form-username">
        <b-form-input
          id="dropdown-form-username"
          size="sm"
          placeholder="lastname"
          v-model="user.lastname"
          required
          autofocus
        ></b-form-input>
      </b-form-group>

    <b-form-group label="Email" label-for="dropdown-form-username">
        <b-form-input
          id="dropdown-form-username"
          size="sm"
          placeholder="email@example.com"
          v-model="user.emailaddress"
          required
          autofocus
        ></b-form-input>
      </b-form-group>

  <b-form-group label="Phone Number" label-for="dropdown-form-username">
        <b-form-input
          id="dropdown-form-username"
          size="sm"
          placeholder="352-123-1234"
          v-model="user.phonenumber"
          required
          autofocus
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
        firstname:"",
        lastname:"",
        emailaddress:"",
        phonenumber:"",
        role: "patron",
      },
      registrationErrors: false,
      registrationCorrect:false,
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
          .then(() => {
              this.user={};
              this.registrationCorrect =true;
              this.registrationErrors =false;
          })
          this.registrationCorrect =true;
              this.registrationErrors =false
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            this.registrationErrors = false;
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


.alertsRegist{
    font-size: 1rem !important;
    font-weight:400 !important;
    letter-spacing: 1px !important;
    margin-bottom:4% ;
    font-family: 'Jua', 'Times New Roman', Times, serif;
    text-transform: uppercase;
}

</style>