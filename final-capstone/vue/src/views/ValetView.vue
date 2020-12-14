<template>
  <div id="valetMain">
    <div id="valetMenu">
      <div id="simpleBar">
        <h4>Valet Options</h4>
      </div>

      <div id="MenuButtons">
        <b-button
          block
          variant="light"
          @click="onCheckIn"
          v-bind:class="{
            notpressed: !showCheckInForm,
            pressed: showCheckInForm,
          }"
          >Check-In</b-button
        >
        <b-button block variant="light" @click="onCheckOut">Check-Out</b-button>
        <b-button
          block
          variant="light"
          @click="onViewAllCars"
          v-bind:class="{
            notpressed: !showListOfCars,
            pressed: showListOfCars,
          }"
          >View All Cars</b-button
        >
        <b-button block variant="light" @click="onRequestCarPickup"
          >Request Car Pickup</b-button
        >
        <b-button block variant="light" @click="onViewPickupRequest"
          >View Pickup Requests</b-button
        >
        <b-button block variant="light" @click="RateCalculator"
          >Rate Calculator</b-button
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

    <div id="valetTopRightDiv">
      <!--<img id="ganggang" src="@/img/jjeb.png" />-->
      <div id="componentsValet">
        <license-plate-entry v-if="showLicensePlateEntry" />
        <!--<check-in-car
          v-if="showCheckInForm"
          v-bind:showCheckInForm="showCheckInForm"
        />-->
        <list-of-cars v-if="showListOfCars" />
        <valet-slip v-if="showValetSlipIdForm" v-bind:valetSelection="valetSelection" />
        <div id="home-parking-lot-container" v-if="showLotTop">
          <parking-lot />
        </div>
      </div>
    </div>

    <!-- <div id="valetBottomRightDiv">-->
    <div id="valetTopBottomDiv" v-if="!showLotTop">
      <div id="home-parking-lot-container">
        <parking-lot />
      </div>
    </div>
    <!-- </div>-->
  </div>
</template>

<script>
import ParkingLot from "../components/ParkingLot.vue";
//import CheckInCar from "../components/CheckInCar.vue";
import ListOfCars from "../components/ListOfCars.vue";
import ValetSlip from "../components/ValetSlip.vue";
import LicensePlateEntry from '../components/LicensePlateEntry.vue';


export default {
  components: { ParkingLot, ListOfCars, ValetSlip, LicensePlateEntry },
  data() {
    return {
      showCheckInForm: false,
      showListOfCars: false,
      showValetSlipIdForm: false,
      showLotTop: true,
      valetSelection: "",
      showLicensePlateEntry: false,
    };
  },
  methods: {
    onCheckIn() {
      //show license plate enter component
      this.showLicensePlateEntry = !this.showLicensePlateEntry;
      //if license plate exists in car details table then add car to valet slip table
      //if license plate is new then show form to add car (check in car component)
      this.showCheckInForm = !this.showCheckInForm;
      this.showLotTop = !this.showLotTop;
    },
    onCheckOut() {
      console.log("under construction");
      //this.showLotTop = !this.showLotTop;
    },
    onViewAllCars() {
      this.showListOfCars = !this.showListOfCars;
      this.showLotTop = !this.showLotTop;
    },
    onRequestCarPickup() {
      console.log("under construction");
      this.showValetSlipIdForm = !this.showValetSlipIdForm
      this.showLotTop = !this.showLotTop;
      this.valetSelection = "pickupCar";
      //this.showLotTop = !this.showLotTop;
    },
    onViewPickupRequest() {
      console.log("under construction");
      //this.showLotTop = !this.showLotTop;
    },
    RateCalculator() {
      console.log("under construction");
      //this.showLotTop = !this.showLotTop;
    },
    
  },
};
</script>

<style>
.notpressed {
  background-color: rgb(246, 246, 246) !important;
  color: black !important;
  border: rgb(255, 255, 255) 4fr !important;
  font-weight: 500;
  font-family: "Jua";
  text-transform: uppercase;
  border-color: white !important;
  margin-bottom: 3.5vh;
  padding: 2vh !important;
}

.pressed {
  background-color: var(--li-color-hover) !important;
  color: var(--a-color-hover) !important;
  border: rgb(255, 255, 255) 4fr !important;
  font-weight: 500;
  font-family: "Jua";
  text-transform: uppercase;
  border-color: white !important;
  margin-bottom: 3.5vh;
  padding: 2vh !important;
}

#MenuButtons {
  margin: 8%;
}

.btn-block:hover {
  transition: var(--transition-speed) !important;
  background-color: var(--li-color-hover) !important;
  color: var(--a-color-hover) !important;
}

.btn-block {
  background-color: rgb(241, 241, 241);
  color: black;
  border: rgb(255, 255, 255) 4fr;
  font-weight: 500;
  font-family: "Jua";
  text-transform: uppercase;
  border-color: white !important;
  margin-bottom: 3.5vh;
  padding: 2vh !important;
}

#MenuButtons .btn-secondary {
  max-width: 1000px;
}

#valetMain {
  display: grid;
  grid-template-columns: 1fr 3fr;
  grid-template-areas:
    "valetMenu valetTopRight"
    "valetMenu valetBottomRight";

  grid-gap: 40px;
  height: fit-content;
  margin: 0px 40px;
}

#valetMenu {
  background-color: rgb(226, 226, 226);
  grid-area: valetMenu;
}

#valetTopRightDiv {
  grid-area: valetTopRight;
  background-color: orange;
  padding: 0.5%;
  border-radius: 0.5rem;
}

#valetTopBottomDiv {
  grid-area: valetBottomRight;
  background-color: orange;
  padding: 0.5%;
  border-radius: 0.5rem;
  margin-bottom: 2%;
}

#componentsValet {
  background-color: rgb(245, 245, 245);
  padding: 0.5%;
  border-radius: 0.5rem;
}
</style>