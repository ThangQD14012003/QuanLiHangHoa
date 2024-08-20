<template>
  <div>
    <h1>Hello</h1>
      <h2 class="title">This is the home page</h2>
      <div class="container" style="margin-top: 100px;">
        
        <router-link  style="text-decoration: none;color:" to="/user">
          <div class="box">
              <h2>Customers</h2>
              <h3>{{ customers.length }}</h3>
          </div>
        </router-link>  
        <router-link  style="text-decoration: none;color:" to="/product">
          <div class="box" >
              <h2>Products</h2>
              <h3>{{ products.length }}</h3>
          </div>
        </router-link>
        <router-link  style="text-decoration: none;color:" to="/order">
          <div class="box">
              <h2>Orders</h2>
              <h3>{{ orders.length }}</h3>
          </div>
        </router-link>
      </div>
  </div>
</template>

<script>
import {ref} from 'vue'
import axios from 'axios';
import urlOrigin from '@/views/uses/urlOrigin';
export default {   
  name: 'Home', 
  setup(){
      const products = ref([]); 
      const customers = ref([]); 
      const orders = ref([]); 
      const {urlOriginCustomer, urlOriginOrder, urlOriginProduct} = urlOrigin();
      const getAllProduct = async() => {
        try {
          const res = await axios.get(urlOriginProduct, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('jwt')}`
            }
          }); 
          products.value = res.data; 
          console.log(products.value); 
        }catch(err) {
          console.log(err); 
        } 
      }
      getAllProduct(); 
      const getAllCustomer = async() => {
        try {
          const res = await axios.get(urlOriginCustomer, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('jwt')}`
            }
          }); 
          customers.value = res.data; 
          console.log(customers.value); 
        }catch(err) {
          console.log(err); 
        } 
      }
      getAllCustomer(); 
      const getAllOrder = async() => {
        try {
          const res = await axios.get(urlOriginOrder, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('jwt')}`
            }
          }); 
          orders.value = res.data; 
          console.log(orders.value); 
        }catch(err) {
          console.log(err); 
        } 
      }
      getAllOrder(); 
      return {
          products, 
          customers,
          orders
      }
  }
}
</script>

<style scoped>
  .container {
      display: flex;
      text-align: center;
      justify-content: center;
  }
  .box {
      background-color: rgb(62, 223, 210);
      padding: 10px ;
      margin-left: 10px ;
      border-radius: 10px;
      width: 250px;
  }
  h3{
      background-color: rgb(111, 86, 255);
      border-radius: 10px;
      color: rgb(255, 255, 255);
  }
  h1{
    font-weight: bold;    
    color: rgb(51, 51, 51); 
  }
  h2 {
    color: white
  }
  .title {
    color: rgb(51, 51, 51); 
    font-weight: bold;
  }
</style>