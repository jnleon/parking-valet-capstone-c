<template>
  <div class="home">
    <div id="menu"> 
      <div id="lot-info">
        <h2>Lot Info</h2>
        <br>Street Address
        <br>City, State, Zip
        <br>Email
        <br>Phone
        </div>
    <div id="pricing">
      <h1>$5 AN HOUR ALL DAY EVERY DAY</h1>
      </div>
      <div>
        <parking-lot />
        </div>
    </div>

  <div id="map">
    <p>This box should be pretty pink</p>
    </div>
  </div>
</template>

<script>
import ParkingLot from '../components/ParkingLot.vue';
export default {
  components: { ParkingLot },
  name: "home"
};

</script>

<style >

.home{
display:grid;
grid-template-columns: 1fr 2fr;
grid-template-areas:
 "menu map";
grid-gap:40px;
height:fit-content;
margin: 0px 40px;
}

#menu {
  background-color: grey;
  grid-area: menu;
}

#map {
  background-color: hotpink;
  grid-area: map;
}

#spots {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
  grid-template-areas:
 "spot-1 spot-2 spot-3 spot-4 spot-5"
  "spot-6 spot-7 spot-8 spot-9 spot-10";
grid-gap:60px;
height:fit-content;
margin: 0px 40px;
}

</style>
