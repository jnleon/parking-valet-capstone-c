<template>
  <div id="formCheckInCar">
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="makeLabel"
        label="Make:"
        label-for="Make"
        description="Please enter make of car."
      >
        <b-form-input
          id="makeInput"
          v-model="car.vehicleMake"
          required
          placeholder="Make"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="modelLabel" label="Model:" label-for="Model">
        <b-form-input
          id="model"
          v-model="car.vehicleModel"
          required
          placeholder="model"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        id="licensePlateLabel"
        label="License Plate:"
        label-for="licensePlate"
      >
        <b-form-input
          id="licensePlate"
          v-model="car.licensePlate"
          required
          placeholder="License Plate"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="colorLabel" label="Color:" label-for="Color">
        <b-form-input
          id="color"
          v-model="car.vehicleColor"
          required
          placeholder="Color"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        id="emailLabel"
        label="Patron Email:"
        label-for="patronEmail"
      >
        <b-form-input
          id="patronEmail"
          v-model="car.patronEmail"
          required
          placeholder="Patron Email"
        ></b-form-input>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
import carDetailsService from "@/services/CarDetailsService.js";

export default {
  name: "check-in-car",
  //props: [checkedInCars],
  props: ["showCheckInForm"],
  data() {
    return {
      car: {
        vehicleMake: "",
        vehicleModel: "",
        licensePlate: "",
        vehicleColor: "",
        patronEmail: "",
        vehicleSpot: 0,
      },

      show: true,
    };
  },

  methods: {
    onSubmit(evt) {
      carDetailsService.checkInCar(this.car).then((response) => {
        if (response.status == 201) {
          //this.showCheckInForm = !this.showCheckInForm;
          //alert()
          location.reload();
        } else {
          console.log("Car not created.");
        }
      });

      evt.preventDefault();
      //this.$router.push({
      //path: '/valet'
      //});
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values
      this.car.vehicleMake = "";
      this.car.vehicleModel = "";
      this.car.licensePlate = "";
      this.car.vehicleColor = "";
      this.car.patronEmail = "";

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
#formCheckInCar {
  font-weight: 500;
  font-family: "Jua";
  text-transform: uppercase;
  border-color: white !important;
  padding: 2vh !important;
}
</style>