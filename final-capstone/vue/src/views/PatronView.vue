<template>
  <div id="valetMain">
    <div id="valetMenu">
      <div id="simpleBar">
        <h4>Patron Options</h4>
      </div>

      <div id="MenuButtons">
        <b-button block variant="light">Balance</b-button>
        <b-button block variant="light">Request Pickup</b-button>
        
      </div>
      <div>
      <div id="map">
      <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d8516.561050240627!2d-84.46975296246113!3d39.15195057631328!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8841b2f72057d245%3A0x27bc76f0bdcb7dfd!2sTech%20Elevator%20Cincinnati!5e1!3m2!1sen!2sus!4v1607456474306!5m2!1sen!2sus" 
      width="2000" 
      height="500"
      
      frameborder="0" 
      style="border:0;" 
      allowfullscreen="" 
      aria-hidden="false" 
      tabindex="0">
      </iframe>
    </div>
    </div>
    </div>
    
    <div id="valetTopRightDiv">
      <!--<img id="ganggang" src="@/img/jjeb.png" />-->
      <div id="componentsValet">
        <valet-slip />
      </div>
    </div>

    <!-- <div id="valetBottomRightDiv">-->
   <div id="valetTopBottomDiv">
    <div id="home-parking-lot-container">
      <parking-lot />
    </div>
   </div>
    <!-- </div>-->


  </div>
</template>

<script>
import ParkingLot from "../components/ParkingLot.vue";
import ValetSlip from "../components/ValetSlip.vue";

export default {
  components: { ParkingLot, ValetSlip },
};
</script>

<style>
#MenuButtons {
  margin: 8%;
}
.btn-block:hover {
  transition: var(--transition-speed) !important;
  background-color: var(--li-color-hover) !important;
  color: var(--a-color-hover) !important;
}

.btn-block {
  background-color: rgb(241, 241, 241) !important;
  color: black !important;
  border: rgb(255, 255, 255) 4fr !important;
  font-weight: 500;
  font-family: "Jua";
  text-transform: uppercase;
  border-color: white !important;
  margin-bottom: 3.5vh;
  padding: 2vh !important;
}

#MenuButtons .btn-secondary {
  max-width: 1000px;
}

#valetMain {
  display: grid;
  grid-template-columns: 1fr 3fr;
  grid-template-areas:
    "valetMenu valetTopRight"
    "valetMenu valetBottomRight";

  grid-gap: 40px;
  height: fit-content;
  margin: 0px 40px;
}

#valetMenu {
  background-color: rgb(226, 226, 226);
  grid-area: valetMenu;
}

#valetTopRightDiv {
  grid-area: valetTopRight;
  background-color: orange;
  padding: 0.5%;
  border-radius: 0.5rem;
}

#valetTopBottomDiv {
  grid-area: valetBottomRight;
    background-color: orange;
  padding: 0.5%;
  border-radius: 0.5rem;
  margin-bottom: 2%;
}

#componentsValet{
  background-color:  rgb(245, 245, 245);
  padding: 0.5%;
  border-radius: 0.5rem;

}
</style>