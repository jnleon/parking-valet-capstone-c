<template>
  <div>
    <!--//need a for each statement to loop through each car in array-->
      <p>{{this.$store.state.checkedInCars[1].licensePlate}}</p>
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