<template>
  <div id="app">
        
        <header>
        <img id="headerlogo" src="../src/img/headerlogo1.png" alt="HeaderLogo">
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
    <router-view class="routerV" />
  </div>
</template>

<style >

#app{
display:grid;
grid-template-columns: 1fr 1fr 1fr 1fr 1fr;
grid-template-areas:
 "header header . loginB loginB"
 "content content content content content";
grid-gap:10px;
height:fit-content;

}

.routerV{
grid-area: content;

}

header{
  grid-area:header ;
}

img{
  max-width: 100%;
  
  padding: 0%;
  margin: 0%;
}

ul{
  grid-area: loginB;
  display:flex;
  justify-content: space-around;
  align-items: center;
  list-style: none;
}

ul li{
  background-color: orange  ;
  width: 30%;
  text-align: center;
  border-radius: .2rem;
  padding: 10px;
}

ul li a{
   color: white;
   text-transform: uppercase ;
    text-decoration: none;
}

</style>