<template>
  <div id="valetMain">
    <div id="valetMenu">
      <div id="simpleBar">
        <h4>Valet Options</h4>
      </div>

      <div id="MenuButtons">
        <b-button block variant="light" @click="onCheckIn">Check-In</b-button>
        <b-button block variant="light" @click="onCheckOut">Check-Out</b-button>
        <b-button block variant="light" @click="onViewAllCars">View All Cars</b-button>
        <b-button block variant="light" @click="onRequestCarPickup">Request Car Pickup</b-button>
        <b-button block variant="light" @click="onViewPickupRequest">View Pickup Requests</b-button>
        <b-button block variant="light" @click="RateCalculator">Rate Calculator</b-button>
      </div>
    </div>

    <div id="valetTopRightDiv">
      <!--<img id="ganggang" src="@/img/jjeb.png" />-->
      <div id="componentsValet">
        <check-in-car v-if="showCheckInForm" v-bind:showCheckInForm='showCheckInForm'/>
        <list-of-cars v-if="showListOfCars"/>
        <valet-slip />
        <div id="home-parking-lot-container" v-if="showLotTop">
      <parking-lot/>
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
import CheckInCar from "../components/CheckInCar.vue";
import ListOfCars from "../components/ListOfCars.vue";
import ValetSlip from "../components/ValetSlip.vue";

export default {
  components: { ParkingLot, CheckInCar, ListOfCars, ValetSlip },
  data() {
    return {
      showCheckInForm: false,
      showListOfCars: false,
      showLotTop: true,

    }
  },
  methods: {
    onCheckIn() {
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
      //this.showLotTop = !this.showLotTop;
    },
    onViewPickupRequest() {
      console.log("under construction");
      //this.showLotTop = !this.showLotTop;
    },
    RateCalculator() {
      console.log("under construction");
      //this.showLotTop = !this.showLotTop;
    }
  }
};
</script>

<style>
#MenuButtons {
  margin: 8%;
}
.btn-block:hover {
  transition: var(--transition-speed) !important;
  background-color: var(--li-color-hover) !important;
  color: var(--a-color-hover) !important;
}

.btn-block {
  background-color: rgb(241, 241, 241) !important;
  color: black !important;
  border: rgb(255, 255, 255) 4fr !important;
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

#componentsValet{
  background-color:  rgb(245, 245, 245);
  padding: 0.5%;
  border-radius: 0.5rem;

}
</style>