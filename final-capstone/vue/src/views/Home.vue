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
    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3093.9952100165006!2d-84.46970818427397!3d39.15209057953221!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8841b2f72057d245%3A0x27bc76f0bdcb7dfd!2sTech%20Elevator%20Cincinnati!5e0!3m2!1sen!2sus!4v1607198989499!5m2!1sen!2sus" width="800" height="600" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
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
  background-color:grey;
  grid-area: map;
  padding: 10%;
  max-width: 100%;
}

div > iframe {
  display: flex;
  justify-content: center;
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
