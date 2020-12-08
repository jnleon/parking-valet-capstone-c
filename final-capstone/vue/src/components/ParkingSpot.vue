<template>
  <div class="spots" v-bind:class="{occupied: parkingSpot.isOccupied, available: !parkingSpot.isOccupied}">
     
      <p> {{parkingSpot.parkingSpotId}} </p>
      
      
      </div>
</template>

<script>


export default {    
    name: 'parking-spot',
    props: ['parkingSpot'],   

}
</script>

<style>
.spots {
    border: 2px solid white;
    border-radius: 10px;
    width: 10%;
    height: 100px;
    margin: 4%;
    color: white;
    text-align: center;
    
}

.available {
    background-color: green;
}

.occupied {
    background-color:red;
}

</style>