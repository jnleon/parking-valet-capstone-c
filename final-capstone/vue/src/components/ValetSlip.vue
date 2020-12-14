<template>
  <div>
    <b-form @submit="PatronCarDetailsSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="input-group-1"
        label="Enter Valet Number:"
        label-for="input-1"
        description="Please enter your valet slip number."
      >
        <b-form-input
          id="input-1"
          v-model="form.valetSlipNumber"
          type="text"
          required
          placeholder="Valet Slip Number"
        ></b-form-input>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
    <h3 v-if="showValetCall">The valet will arrive shortly with your car.</h3>
    <patron-car-details v-if="showPatronCar" v-bind:slipId="slipId" />
  </div>
</template>

<script>
import PatronCarDetails from "@/components/PatronCarDetails.vue";

export default {
  slipId: "",
  props: ["patronSelection"],
  data() {
    return {
      form: {
        valetNumber: "",
        name: "",
        checked: [],
      },
      show: true,
      showValetCall: false,
      showPatronCar: false,
    };
  },
  components: { PatronCarDetails },
  methods: {
    PatronCarDetailsSubmit(evt) {
      evt.preventDefault();
      if (this.patronSelection == "showBalance") {
        this.showPatronCar = !this.showPatronCar;
        this.show = false;
        this.slipId = this.form.valetSlipNumber;
      } else if (this.patronSelection == "pickupCar") {
        this.showValetCall = !this.showValetCall;
        this.show = false;
        //verify that the Valet Slip ID exists***
      }
    },
    onSubmitPatronRequest() {
      this.show = false;
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

<style>
</style>

