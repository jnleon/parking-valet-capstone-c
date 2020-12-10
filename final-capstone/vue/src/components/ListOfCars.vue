<template>
  <div>
      <p>{{checkedInCars[0]}}</p>
  </div>
</template>

<script>
import ParkingLotService from "@/services/ParkingLotService.js";

export default {
    
    name: "list-of-cars",
    
    created() {
      //get list of cars and send to mutation 
      //load list of cars
      ParkingLotService.getCheckedInCars().then((response ) => {
          this.$store.commit("LOAD_CAR_LIST",response.data)
      })

    },
}
</script>

<style>

</style>