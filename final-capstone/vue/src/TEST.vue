<template>
  <div id="app">
      <div id="headerBar">
        <header>
        <img id="headerlogo" src="../src/img/croppedGang.png" alt="HeaderLogo">
      </header>

        <ul>
          <li>
             <router-link v-bind:to="{name: 'login'}">
            <a href="#">Login</a>
              </router-link></li>
          <li>
              <router-link v-bind:to="{name: 'register'}">
            <a href="#">Register</a> </router-link></li>
      </ul>
    <!--\\  <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
     <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>-->
    
    

    </div>
    
    <router-view class="routerV" />
  </div>
</template>

<style >
:root {
  --li-color: white;
  --li-color-hover:rgb(255, 145, 0);
  --transition-speed: .60s;
  --a-color:red;
  --a-color-hover:white;
}


@import url('https://fonts.googleapis.com/css2?family=Jua&display=swap');

#headerBar{
background-color: orange;;
grid-area: header;
display:grid;
grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
grid-template-rows: 1fr;
grid-template-areas:
 "header header . loginB loginB";
height:fit-content;
margin-left: -10px;
margin-right: -10px;
margin-top: -10px;
grid-gap:20px;

}


#app{
display:grid;
grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
grid-template-areas:
 "header header header header header"
 "content content content content content";
grid-gap:10px;
height:fit-content;

}
.routerV{
grid-area: content;

}

header{
  grid-area:header ;
  display: flex;
}

#headerlogo{
  grid-area:header ;
  max-width:35vh;
  padding-left: 5%;
  padding-top: 1%;
  flex-grow: 10%;
}

ul{
  grid-area: loginB;
  display:flex;
  justify-content: space-around;
  align-items: center;
  list-style: none;
}

ul li{
  background-color: rgba(255, 255, 255, 0.719)  ;
  width: 25%;
  text-align: center;
  border-radius: .9rem;
  padding: 9px;
  border: .5vh solid white;

}

ul li a{
   color: black;
   text-transform: uppercase ;
  text-decoration: none;
  font-weight: 900;
  font-family:'Jua', sans-serif;
  letter-spacing: .3vh;
}


ul li:hover {
  transition: var(--transition-speed);
  background-color: var(--li-color-hover);
}

ul li a:hover {
  transition: var(--transition-speed);
  color: var(--a-color-hover);
}



</style>





