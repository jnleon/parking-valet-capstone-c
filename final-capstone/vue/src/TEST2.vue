<!--<template>
  <body id="navStuff">
    <nav class="navbar navbar-default navbar-expand-lg navbar-light">
      <div class="navbar-header">
        <router-link v-bind:to="{ name: 'home' }"
          ><img
            class="navbar-brand"
            src="../src/img/bejjTitle.png"
            alt="HeaderLogo"
        /></router-link>
        <button
          type="button"
          data-target="#navbarCollapse"
          data-toggle="collapse"
          class="navbar-toggle"
        >
          <span class="navbar-toggler-icon"></span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
        </button>
      </div>
      <div id="navbarCollapse" class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right">
          <li>
            <router-link v-bind:to="{ name: 'register' }">
              <a href="#" data-toggle="dropdown" class="dropdown-toggle"
                >Register</a
              >
            </router-link>
            <ul class="dropdown-menu form-wrapper">
              <li>
                <form action="/examples/actions/confirmation.php" method="post">
                  <p class="hint-text">
                    Fill in this form to create your account as a Patron!
                  </p>
                  <div class="form-group">
                    <input
                      type="text"
                      class="form-control"
                      placeholder="Username"
                      required="required"
                    />
                  </div>
                  <div class="form-group">
                    <input
                      type="password"
                      class="form-control"
                      placeholder="Password"
                      required="required"
                    />
                  </div>
                  <div class="form-group">
                    <input
                      type="password"
                      class="form-control"
                      placeholder="Confirm Password"
                      required="required"
                    />
                  </div>
                  <input
                    type="submit"
                    class="btn btn-primary btn-block"
                    value="Sign up"
                  />
                </form>
              </li>
            </ul>
          </li>
          <li>
            <ul>
              <router-link v-bind:to="{ name: 'login' }">
                <a
                  data-toggle="dropdown"
                  class="btn btn-primary dropdown-toggle get-started-btn mt-1 mb-1"
                  href="#"
                  >Login</a
                >
              </router-link>
            </ul>
            <ul class="dropdown-menu form-wrapper">
              <li>
                <form action="/examples/actions/confirmation.php" method="post">
                  <div class="form-group">
                    <input
                      type="text"
                      class="form-control"
                      placeholder="Username"
                      required="required"
                    />
                  </div>
                  <div class="form-group">
                    <input
                      type="password"
                      class="form-control"
                      placeholder="Password"
                      required="required"
                    />
                  </div>
                  <input
                    type="submit"
                    class="btn btn-primary btn-block"
                    value="Login"
                  />
                </form>
              </li>
            </ul>
          </li>
        </ul>
      </div>
    </nav>
    <div>
      <router-view class="routerV" />
    </div>
  </body>
</template>

    
    
    <style>
@import url("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js");

@import url("https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js");
@import url("https://fonts.googleapis.com/css?family=Varela+Round");
@import url("https://fonts.googleapis.com/icon?family=Material+Icons");
@import url("https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css");
@import url("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css");

@import url("https://fonts.googleapis.com/css2?family=Jua&display=swap");

:root {
  --li-color: white;
  --li-color-hover: #31bfb1;
  --transition-speed: 0.6s;
  --a-color: rgb(255, 255, 255);
  --a-color-hover: white;
}

#navStuff {
  font-family: sans-serif;
}
.form-control {
  box-shadow: none;
  font-weight: normal;
  font-size: 13px;
}
.form-control:focus {
  border-color: #33cabb;
  box-shadow: 0 0 8px rgba(0, 0, 0, 0.1);
}

.navbar {
  background: orange;
  padding-left: 5vh;
  padding-right: 6vh;
  border-bottom: 1px solid #dfe3e8;
  border-radius: 0;
  text-transform: uppercase;
  font-family: "Jua", sans-serif;
  letter-spacing: 0.2vh;
}

.navbar-brand {
  padding: 1%;
}

.navbar .form-inline {
  display: inline-block;
}
.navbar .nav li {
  position: relative;
}
.navbar .nav li a {
  color: black;
  text-decoration: none;
  font-weight: 900;
}
.navbar .nav .btn-primary,
.navbar .nav .btn-primary:active {
  color: black;
  padding-top: 5px;
  padding-bottom: 5px;
  vertical-align: middle;
  border: none;
  background-color: rgba(255, 255, 255, 0.719);
}
.navbar .nav .btn-primary:hover,
.navbar .nav .btn-primary:focus {
  transition: var(--transition-speed);
  background-color: var(--li-color-hover);
}
.navbar .navbar-right li:first-child a {
  padding-right: 0px;
}
.navbar ul li i {
  font-size: 18px;
}
.navbar .dropdown-menu i {
  font-size: 16px;
  min-width: 22px;
}
.navbar ul.nav li.active a,
.navbar ul.nav li.open > a {
  background: transparent !important;
}
.navbar .nav .get-started-btn {
  min-width: 120px;
  margin-top: 8px;
  margin-bottom: 8px;
}
.navbar ul.nav li.open > a.get-started-btn {
  color: #fff;
  background: #31bfb1 !important;
}
.navbar .dropdown-menu {
  border-radius: 1px;
  border-color: #e5e5e5;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
}
.navbar .nav .dropdown-menu li {
  color: #999;
  font-weight: normal;
}
.navbar .nav .dropdown-menu li a,
.navbar .nav .dropdown-menu li a:hover,
.navbar .nav .dropdown-menu li a:focus {
  padding: 8px 20px;
  line-height: normal;
}
.navbar .navbar-form {
  border: none;
}
.navbar .dropdown-menu.form-wrapper {
  width: 280px;
  padding: 20px;
  left: auto;
  right: 0;
  font-size: 14px;
}
.navbar .dropdown-menu.form-wrapper a {
  color: #33cabb;
  padding: 0 !important;
}
.navbar .dropdown-menu.form-wrapper a:hover {
  text-decoration: underline;
}
.navbar .form-wrapper .hint-text {
  text-align: center;
  margin-bottom: 15px;
  font-size: 13px;
}
.navbar .form-wrapper .social-btn .btn,
.navbar .form-wrapper .social-btn .btn:hover {
  color: #fff;
  margin: 0;
  padding: 0 !important;
  font-size: 13px;
  border: none;
  transition: all 0.4s;
  text-align: center;
  line-height: 34px;
  width: 47%;
  text-decoration: none;
}
.navbar .social-btn .btn-primary {
  background: #507cc0;
}
.navbar .social-btn .btn-primary:hover {
  background: #4676bd;
}
.navbar .social-btn .btn-info {
  background: #64ccf1;
}
.navbar .social-btn .btn-info:hover {
  background: #4ec7ef;
}
.navbar .social-btn .btn i {
  margin-right: 5px;
  font-size: 16px;
  position: relative;
  top: 2px;
}
.navbar .form-wrapper .form-footer {
  text-align: center;
  padding-top: 10px;
  font-size: 13px;
}
.navbar .form-wrapper .form-footer a:hover {
  text-decoration: underline;
}

@media (min-width: 1200px) {
  .form-inline .input-group {
    width: 300px;
    margin-left: 30px;
  }
}
@media (max-width: 768px) {
  .navbar .dropdown-menu.form-wrapper {
    width: 100%;
    padding: 10px 15px;
    background: transparent;
    border: none;
  }
  .navbar .form-inline {
    display: block;
  }
  .navbar .input-group {
    width: 100%;
  }
  .navbar .nav .btn-primary,
  .navbar .nav .btn-primary:active {
    display: block;
  }
}
</style>                                           