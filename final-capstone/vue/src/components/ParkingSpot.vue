<template>
  <div class="spots" v-bind:class="{occupied: !parkingSpot.available, available: parkingSpot.available}">
      <p> {{parkingSpot.spotId}} </p>
      </div>
</template>

<script>
export default {
    name: 'parking-spot',
    props: ['parkingSpot']
}
</script>

<style>
.spots {
    border: 2px solid black;
    border-radius: 10px;
    width: 10%;
    height: 40%;
    margin: 4%;
}

.available {
    background-color: green;
}

.occupied {
    background-color:red;
}

</style>