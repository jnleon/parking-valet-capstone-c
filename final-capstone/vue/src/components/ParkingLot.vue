<template>
  <div class="parking-lot-container">
      
      <parking-spot v-for="parkingSpot in theParkingSpots" :key="parkingSpot.parkingSpotId" 
      v-bind:parkingSpot="parkingSpot"> </parking-spot>
      
    </div>
</template>

<script>
import ParkingSpot from '../components/ParkingSpot.vue'
import ParkingService from '../services/ParkingLotService.js';


export default {
    data() {
        return {
        theParkingSpots: []
        }
    },
    components: {ParkingSpot, ParkingService},
    name: 'parking-lot',
    methods: {
        getSpotInfo () {
            ParkingService.getParkingSpots().then((response) => {
            this.theParkingSpots = response.data
        })
        }
    },
    created() {
        this.getSpotInfo();
    }
    /*created() {
        
        ParkingSpot.getParkingSpots().then((response) => {
            this.parkingSpots = response.data
        })
    },*/
}
</script>

<style>
.parking-lot-container {
    display: flex;
    justify-content: space-evenly;
    flex-wrap: wrap;
}
</style>