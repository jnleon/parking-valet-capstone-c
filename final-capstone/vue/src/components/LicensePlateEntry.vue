<template>
  <div>
    <h3>CHECK-IN</h3>
    <b-form @submit="LicensePlateSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="license-plate-entry-label"
        label="Enter License Plate:"
        label-for="license-plate-entry"
        description="Please enter the car's license plate."
      >
        <b-form-input
          id="license-plate-input"
          v-model="form.licensePlate"
          type="text"
          required
          placeholder="License Plate"
        ></b-form-input>
      </b-form-group>
      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
    <check-in-car v-if="showCheckInForm" v-bind:licensePlate="licensePlate" />
    <h3 v-if="confirmCarAddedMessage">Valet Slip has been created for car</h3>
  </div>
</template>
<script>
import ValetService from "@/services/ValetService.js";
import CheckInCar from "../components/CheckInCar.vue";
import carDetailsService from "@/services/CarDetailsService.js";

export default {
  carExists: "",
  name: "license-plate-entry",
  props: [],
  data() {
    return {
      form: {
        licensePlate: "",
      },
      licensePlate: "",
      show: true,
      showCheckInForm: false,
      confirmCarAddedMessage: false,
    };
  },
  components: { CheckInCar },
  methods: {
    LicensePlateSubmit(evt) {
      evt.preventDefault();
      //alert(this.form.valetSlipNumber)
      ValetService.checkLicensePlate(this.form.licensePlate).then(
        (response1) => {
          if (response1.data.licensePlate != null) {
             carDetailsService.checkInCar(response1.data).then((response) => {
              alert(response.status)
              if (response.status == 201) {
                //this.showCheckInForm = !this.showCheckInForm;
                location.reload();
              } else {
                console.log("Car not created.");
              }
            });
            //as long as car exists, do this . .
            //if license plate exists in car details table then add car to valet slip table
            this.show = !this.show;
            this.showCheckInForm = false;
            this.confirmCarAddedMessage = true;
          } else {
            //if car doesn't exist/entered incorrectly do this
            //if license plate is new then show form to add car (check in car component)
            this.licensePlate = this.form.licensePlate;
            this.showCheckInForm = !this.showCheckInForm;
            this.show = !this.show;
          }
        }
      );
    },
    onSubmitPatronRequest() {
      this.show = false;
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values
      this.form.licensePlate = "";
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
  },
};
</script>
<style>
</style>