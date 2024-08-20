<template>
  <div>
    <div style="height: 80px; position: sticky; width: 100%; top: 0;" class="header d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom shadow-sm">
      <router-link v-if="!isLogin && !isRegister" class="my-0 mr-md-auto font-weight-normal" to="/Home">Home</router-link>
    
      <nav  v-if="!isLogin && !isRegister" class="my-2 my-md-0 mr-md-3">
        
        <router-link style="text-decoration: none;" to="/user">Customer</router-link>
        <router-link style="text-decoration: none;" to="/product">Product </router-link>
        <router-link style="text-decoration: none;" to="/order">Order</router-link>
        <!-- <router-link style="text-decoration: none;" to="/report">Report</router-link> -->
      </nav>
      <!-- <a class="btn btn-outline-primary" >Logout</a> -->
      <router-link v-if="!isLogin && !isRegister" class="btn btn-outline-primary" :to="{name: 'login'}">Logout</router-link>
      <router-link v-if="isRegister" class="btn btn-outline-primary" :to="{name: 'login'}">Login</router-link>
      <router-link v-if="isLogin" class="btn btn-outline-primary" :to="{name: 'register'}">Register</router-link>
    </div>
    <router-view></router-view>
    <!-- <div style="position: fixed; width: 100%;" class="footer">
      <div class="container-f">
        <h4 class="footer-content">This is website from Quang Thang</h4>
      </div>
    </div> -->
  </div>
</template>

<script>
import {useRoute} from "vue-router"; 
import {computed} from "vue"
export default {
  setup(){
    const route = useRoute(); 
    const isLogin = computed(()=> route.name === 'login'); 
    const isRegister = computed(()=> route.name === 'register'); 
    console.log(isLogin.value); 
    return {
      isLogin, isRegister
    }
  }
}
  
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
.container-f {
  background-color: #ffffff;
  height: 60px;
  width: 100%; 
  text-align: center;
  margin: auto;
  position: relative;
  margin-bottom: 10px;
  box-shadow: 0px -2px 10px rgb(199, 199, 199);
}
.footer-content {
  position: absolute;
  display: flex;
  justify-content: center; 
  align-items: center;
  top: 18px;
  left: 500px; 
}
.header {
  background-color: red;
}
</style>