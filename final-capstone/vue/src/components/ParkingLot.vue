<template>
  <div class="parking-lot-container">
      <parking-spot v-for="parkingSpot in parkingSpots" :key="parkingSpot.parkingSpotId" 
      v-bind:parkingSpot="parkingSpot"/>
      
    </div>
</template>

<script>
import ParkingSpot from '@/services/ParkingLotService.js';


export default {
    data() {
        return {
        parkingSpots: []
        }
    },
    components: {ParkingSpot},
    name: 'parking-lot',
    
    created() {
        
        ParkingSpot.getParkingSpots().then((response) => {
            this.parkingSpots = response.data
        })
    },
}
</script>

<style>
.parking-lot-container {
    display: flex;
    justify-content: space-evenly;
    flex-wrap: wrap;
}
</style>