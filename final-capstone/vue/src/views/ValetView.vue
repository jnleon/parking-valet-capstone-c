<template>
    <div id="valetMain">
           
         <div id="valetMenu">
              <div id="simpleBar">
        <h4>Valet Options</h4>
              </div>

          <div id="MenuButtons">  
                <b-button block variant="light">Check-In</b-button>
                <b-button block variant="light">Check-Out</b-button>
                <b-button block variant="light">View All Cars</b-button>
                <b-button block variant="light">Request Car Pickup</b-button>
                <b-button block variant="light">View Pickup Requests</b-button>
                <b-button block variant="light">Rate Calculator</b-button>
               </div>
            </div>
      
<div id="valetTopRightDiv">
            <!--<img id="ganggang" src="@/img/jjeb.png" />-->
            <div>
              <check-in-car />
              <list-of-cars />
            </div>
            
</div>
   
   <!-- <div id="valetBottomRightDiv">-->
           <div id="home-parking-lot-container">
          <parking-lot />
          
           </div>
   <!-- </div>-->
    </div>
</template>

<script>


import ParkingLot from "../components/ParkingLot.vue";
import CheckInCar from "../components/CheckInCar.vue";
import ListOfCars from "../components/ListOfCars.vue";



export default {
 components: { ParkingLot, CheckInCar, ListOfCars },
}
</script>
,
  ListOfCars
<style>
#MenuButtons{
margin:8%;
 

}
.btn-block:hover{
      transition: var(--transition-speed) !important;
  background-color: var(--li-color-hover) !important;
  color: var(--a-color-hover) !important;
}



.btn-block{
  background-color: rgb(241, 241, 241) !important;
  color: black !important;
  border: rgb(255, 255, 255) 4fr !important;
  font-weight: 500;
  font-family: "Jua";
  text-transform: uppercase;
  border-color: white !important;
  margin-bottom: 3.5vh;
  padding:2vh !important;
}

#MenuButtons .btn-secondary{
    max-width:1000px;
}


#valetMain {
  display: grid;
  grid-template-columns: 1fr 3fr;
  grid-template-areas: "valetMenu valetTopRight"
  "valetMenu valetBottomRight";
  
  grid-gap: 40px;
  height: fit-content;
  margin: 0px 40px;
}

#valetMenu {
  background-color:rgb(197, 197, 197);
  grid-area: valetMenu;
}

#valetTopRightDiv{
  grid-area: valetTopRight;

}

#valetBottomRightDiv{
grid-area: valetBottomRight;
grid-area: green;

}




</style>