<template>
  <div>
      <b-alert style="text-align:center;" show variant="danger" v-if="isFull">Parking Lot Full!</b-alert>
        <div v-if="!isFull" class="parking-lot-container">
            <parking-spot v-for="parkingSpot in parkingSpots" :key="parkingSpot.parkingSpotId" 
                v-bind:parking-spot="parkingSpot"/>         
        </div>
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
        /* Add method in methods block for check-in - UpdateSpots()*/
    },
    computed: {
        isFull() {
            let occupiedSpots = 0;
            this.parkingSpots.forEach(spot =>  {
                if(spot.isOccupied) {
                    occupiedSpots++;
                } 
            })
            return this.parkingSpots.length == occupiedSpots;
        }
    }
}
</script>

<style>
#p-lot-container-header {
    color: white;
    background-image: url("../img/p-lot-background.jpg");
}
#p-lot-parent-container {
    grid-template-rows: 1fr 2fr;

}
.parking-lot-container {
    color: white;
    display: flex;
    justify-content: space-evenly;
    flex-wrap: wrap;
    align-items: center;
    
    
}
</style>

