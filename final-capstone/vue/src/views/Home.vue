<template>
  <div class="home">
    <div id="menu">
      <div id="simpleBarHome">
        <h2><strong>full service Valet</strong></h2>
      </div>
      <info-component />
      <div id="pricingSection">
        <div>
          <marquee font style="bold" scrolldelay="0.4"
            ><font size="5" face="Jua" family="Jua" /><font color="#BC8F8F" />$5
            PARKING AN HOUR ALL DAY EVERY DAY!</marquee
          >
        </div>
      </div>
      <parking-lot />

      <div id="palceholderFunnyPhoto">
        <img id="ganggang" src="../img/jjeb.png" />
      </div>
    </div>

    <div class="mapHome">
      <iframe
        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d8516.561050240627!2d-84.46975296246113!3d39.15195057631328!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8841b2f72057d245%3A0x27bc76f0bdcb7dfd!2sTech%20Elevator%20Cincinnati!5e1!3m2!1sen!2sus!4v1607456474306!5m2!1sen!2sus"
        width="2000"
        height="100%"
        frameborder="0"
        aria-hidden="false"
      >
      </iframe>
    </div>
  </div>
</template>

<script>
import ParkingLot from "../components/ParkingLot.vue";
import InfoComponent from "../components/InfoComponent.vue";
export default {
  components: { ParkingLot, InfoComponent },
  name: "home",
};
</script>

<style >
.mapHome {
  display: flex;
  grid-area: map;
  padding: 0.8%;
  background-color: orange;
  border-radius: 0.5rem;
}

.hr4 {
  color: green;
}

.hr5 {
  color: red;
}

.container-text li {
  list-style: none;
  text-align: left;
  font-size: 90%;
  color: rgb(230, 230, 230);
  padding-right: 50%;
}
s #available-box {
  background-color: green;
  color: green;
  width: 20px;
}
#occupied-box {
  background-color: red;
  color: red;
  width: 20px;
}

#home-parking-lot-container-yes {
  color: white;
  background-image: url("../img/p-lot-background.jpg");
  padding-top: 3%;
  padding-bottom: 0.05%;
  font-family: "Jua";
  text-transform: uppercase;
  text-align: center;
}

#home-parking-lot-container {
  color: white;
  background-image: url("../img/p-lot-background.jpg");
  padding-top: 3%;
  padding-bottom: 0.05%;
  font-family: "Jua";
  text-transform: uppercase;
  text-align: center;
}
marquee {
  font-family: "Jua";
  font-size: 6vh;
}
#simpleBarHome{
  display: flex;
  background-color: orange;
  font-family: "Jua";
  text-transform: uppercase;
  justify-content: center;
  align-items: center;
  padding-top: 1.3%;
  border-top-right-radius: 0.3rem;
  border-top-left-radius: 0.3rem;
}

#lotInfo {
  background-color: rgb(236, 234, 234);
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: "SvcBarInfo SvcBarContact";
  padding: 3%;
}

#palceholderFunnyPhoto {
  display: flex;
  padding: 4%;
  background-color: rgb(236, 234, 234);
  border-bottom-left-radius: 0.3rem;
  border-bottom-right-radius: 0.3rem;
  /*rgb(46, 83, 46)*/
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

div > iframe {
  max-width: 100%;
  max-height: 100%;
}
</style>
