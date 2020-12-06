


<template>
  <div class="parking-lot-container">
      <parking-spot v-for="parkingSpot in parkingSpots" :key="parkingSpot.parkingSpotId" 
      v-bind:parking-spot="parkingSpot"/>
      
    </div>
</template>

<script>
import ParkingService from '@/services/ParkingLotService.js';
import ParkingSpot from '@/components/ParkingSpot.vue';

export default {
    data() {
        return {
        parkingSpots: []
        }
    },
    components: { ParkingSpot},
    name: 'parking-lot',
    
    created() {
        
        ParkingService.getParkingSpots().then((response) => {
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

