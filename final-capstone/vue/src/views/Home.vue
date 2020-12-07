<template>
  <div class="home">
    <div id="menu">
      <div id="simpleBar">
        <p>full service Valet</p>
      </div>
      <div id="lotInfo">
        <div class="svcBarName">
          <h1>Tech Elevator</h1>
          <h2>Cincinnati</h2>
          <p>1776 Mentor Ave Suite 355</p>
          <p>Cincinnati OH 45212</p>
        </div>
        <div class="svcContacts">
          <p>✉ hello@techelevator.com</p>
          <p><i class="fa">&#xf095;</i> (877) 606-3203</p>
        </div>
      </div>

      <div id="pricingSection">
        <div>
          <marquee font style="bold" scrolldelay="0.4"
            ><font size="5" face="Jua" family="Jua" /><font color="#BC8F8F" />$5
            AN HOUR ALL DAY EVERY DAY!</marquee
          >
        </div>
      </div>
      <div>
        <parking-lot />
      </div>
      <div id="palceholderFunnyPhoto">
        <img id="ganggang" src="../img/croppedGang.png" />
      </div>
    </div>

    <div id="map">
      <iframe
        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3093.9952100165006!2d-84.46970818427397!3d39.15209057953221!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8841b2f72057d245%3A0x27bc76f0bdcb7dfd!2sTech%20Elevator%20Cincinnati!5e0!3m2!1sen!2sus!4v1607198989499!5m2!1sen!2sus"
        width="2000"
        height="1000"
        frameborder="0"
        style="border: 0"
        allowfullscreen=""
        aria-hidden="false"
        tabindex="0"
      ></iframe>
    </div>
  </div>
</template>

<script>
import ParkingLot from "../components/ParkingLot.vue";
export default {
  components: { ParkingLot },
  name: "home",
};
</script>

<style >
marquee {
  font-family: "Jua";
  font-size: 6vh;
}
#simpleBar {
  display: flex;
  background-color: orange;
  font-family: "Jua";
  font-weight: 900;
  text-transform: uppercase;
  justify-content: center;
  padding-top: 1.3%;
}

#lotInfo {
  background-color: rgb(236, 234, 234);
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: "SvcBarInfo SvcBarContact";
  padding: 3%;
  grid-gap: 5vh;
}

#palceholderFunnyPhoto {
  display: flex;
  padding: 4%;
}
#ganggang {
  align-items: center;
  max-width: 100%;
}

#pricingSection {
  display: block;
  background-color: orange;
  padding: 3%;
}

.svcBarName {
  grid-area: SvcBarInfo;
}

.svcContacts {
  grid-area: SvcBarContact;
}

.svcContacts p {
  margin-top: 1%;
  margin-bottom: 1%;
  font-family: "Jua", sans-serif;
  font-weight: 500;
  text-align: right;
}

.svcContacts img {
  max-width: 50%;
  align-items: right;
}

.svcBarName h1,
h2 {
  margin-top: 1%;
  margin-bottom: 1%;
  text-transform: uppercase;
  font-family: "Jua", sans-serif;
  font-weight: 900;
}

.svcBarName P {
  margin-top: 0%;
  margin-bottom: 0%;
  font-family: "Jua", sans-serif;
  font-weight: 300;
}

.home {
  display: grid;
  grid-template-columns: 1fr 2fr;
  grid-template-areas: "menu map";
  grid-gap: 40px;
  height: fit-content;
  margin: 0px 40px;
}

#menu {
  background-color: rgb(240, re, 240);
  grid-area: menu;
  background-color: rgb(236, 234, 234);
}

#map {
  grid-area: map;
  padding: 0.5%;
  background-color: orange;
  border-radius: 0.5rem;
}

div > iframe {
  max-width: 100%;
  max-height: 20%;
}

#spots {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
  grid-template-areas:
    "spot-1 spot-2 spot-3 spot-4 spot-5"
    "spot-6 spot-7 spot-8 spot-9 spot-10";
  grid-gap: 60px;
  height: fit-content;
  margin: 0px 40px;
}
</style>
