<template>
  <div>
    <b-form @submit.prevent="UpdateSpotNumber" @reset="onReset" v-if="show">
      <b-form-group
        id="Spot Label"
        label="Enter Spot Number:"
        label-for="Spot Label"
        description="Enter Spot Number"
      >
        <b-form-input
          id="Spot Number Input"
          v-model="form.spotNumber"
          type="text"
          required
          placeholder="Spot Number"
        ></b-form-input>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
import ValetService from "@/services/ValetService.js";

export default {
  name: "update-spot-id",
  show: false,
  props: ["ticketId"],
  data() {
    return {
      form: {
        spotNumber: "",
        name: "",
      },
      show: true,
      showValetCall: false,
      showPatronCar: false,
      showValetRequestMessage: false,
    };
  },
  methods: {
    UpdateSpotNumber() {
      if (this.form.spotNumber < 1 || this.form.spotNumber > 10) {
        alert("Please enter a valid spot number");
      } else {
        this.$store.state.parkingSpots.forEach((spot) => {
          if (spot.parkingSpotId == this.form.spotNumber) {
            if (spot.isOccupied == true) {
              alert("Parking spot already taken");
            } else {
              ValetService.updateParkingSpot(
                this.ticketId,
                this.form.spotNumber
              );
              alert("Spot number updated");
            }
          }
        });
      }
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values
      this.form.email = "";
      this.form.name = "";
      this.form.food = null;
      this.form.checked = [];
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
  },
};
</script>