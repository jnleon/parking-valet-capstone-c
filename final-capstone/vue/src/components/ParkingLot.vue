<template>
  <div class="parking-lot-container">
      <parking-spot v-for="parkingSpot in $store.state.parkingSpots" 
      v-bind:key="parkingSpot.spotId" 
      v-bind:parkingSpot="parkingSpot"/>
    </div>
</template>

<script>
import ParkingSpot from '@/components/ParkingSpot.vue';
export default {
    components: {
        ParkingSpot
    },
    name: 'parking-lot',
}
</script>

<style>
.parking-lot-container {
    display: flex;
    justify-content: space-evenly;
    flex-wrap: wrap;
}
</style>