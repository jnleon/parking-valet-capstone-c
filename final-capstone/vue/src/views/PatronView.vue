<template>
  <div id="valetMain">
    <div id="valetMenu">
      <div id="simpleBar">
        <h4><strong>Patron Options</strong></h4>
      </div>

      <div id="MenuButtons">
        <b-button
          @click="onSubmitBalanceRequest"
          block
          variant="light"
          v-bind:class="{
            notpressed: !viewBalanceButton,
            pressed: viewBalanceButton,
          }"
          >View Balance</b-button
        >
        <b-button
          @click="requestPickup"
          block
          variant="light"
          v-bind:class="{
            notpressed: !viewPickupButton,
            pressed: viewPickupButton,
          }"
          >Request Pickup</b-button
        >
      </div>
      <div class="mapViews">
        <iframe
          src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d8516.561050240627!2d-84.46975296246113!3d39.15195057631328!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8841b2f72057d245%3A0x27bc76f0bdcb7dfd!2sTech%20Elevator%20Cincinnati!5e1!3m2!1sen!2sus!4v1607456474306!5m2!1sen!2sus"
          width="2000"
          frameborder="0"
          style="border: 0"
          allowfullscreen=""
          aria-hidden="false"
          tabindex="0"
          height="100%"
        >
        </iframe>
      </div>
    </div>

    <div class="valetTopRightDiv">
      <!--<img id="ganggang" src="@/img/jjeb.png" />-->
      <div class="componentsValet" v-if="showValetSlip">
        <valet-slip v-bind:patronSelection="patronSelection" />
      </div>

      <parking-lot id="home-parking-lot-container" />
    </div>
  </div>
</template>

<script>
import ParkingLot from "../components/ParkingLot.vue";
import ValetSlip from "../components/ValetSlip.vue";

export default {
  data() {
    return {
      showValetSlip: false,
      viewBalanceButton: false,
      viewPickupButton: false,
      patronSelection: "",
    };
  },
  components: { ParkingLot, ValetSlip },
  methods: {
    onSubmitBalanceRequest() {
      this.patronSelection = "showBalance";
      this.viewBalanceButton = !this.viewBalanceButton;
      this.showValetSlip = !this.showValetSlip;
    },
    requestPickup() {
      this.patronSelection = "pickupCar";
      this.viewPickupButton = !this.viewPickupButton;
      this.showValetSlip = !this.showValetSlip;
    },
  },
};
</script>

<style>
.mapViews {
  display: flex;
  padding: 1.5%;
  background-color: orange;
  border-radius: 0.5rem;
  margin-right: 8%;
  margin-left: 8%;
  margin-bottom: 5%;

  grid-area: GoogleMapsBar;
}

#MenuButtons {
  margin-right: 8%;
  margin-left: 8%;
  margin-top: 6.5%;
  grid-area: ButtonBar;
}

#MenuButtons .btn-secondary {
  max-width: 1000px;
}

.valetTopRightDiv {
  grid-area: components;
  display: flex;
  flex-direction: column;
}

.componentsValet {
  background-color: rgb(241, 241, 241);
  padding: 1%;
  border-radius: 0.5rem;
  margin-bottom: 1%;
  border: 0.8vh solid orange;
  font-family: "Jua", "Times New Roman", Times, serif;
  text-transform: uppercase;
  color: rgb(0, 0, 0);
}
</style>