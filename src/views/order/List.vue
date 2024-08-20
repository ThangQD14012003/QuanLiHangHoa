<template>
    <div>
        <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
        <h3 class="display-4">Order list</h3>
        <p><router-link to="/order/form">Add new</router-link></p>
        <input type="button" value="Back list" @click="back" class="back">
        <form  @submit.prevent="searchO" style="display: inline;">
          <input placeholder="Điền ID đơn đặt hàng ..." v-model="searchText" class="input-search" type="text" 
            name="search" style="width: 400px; padding-left: 4px; margin-right: 4px; " autocomplete="on">
          <!-- <button type="submit" class="btn-search">Tìm kiếm</button> -->
          <input type="submit" value="Tìm kiếm" class="btn-search">
        </form>
    </div>

  <div class="container">
    <div class="card-deck mb-3 text-center">
      <table class="table table-bordered">
        <thead>
          <tr>
            <th scope="col">STT</th>
            <th scope="col">Order ID</th>
            <th scope="col">Product name</th>
            <th scope="col">Customer name</th>
            <th scope="col">Address</th>
            <th scope="col">Customer phone</th>
            <th scope="col">Total price</th>
            <th scope="col">Handle</th>
          </tr>
        </thead>
        <tbody v-if="ordersearchs.length == 0">
          <tr v-for="(order, index) in orders" :key="index">
            <th scope="row">{{ index + 1 }}</th>
            <td>{{ order.id }}</td>
            <td>{{ productNames[order.productId] }}</td>
            <td>{{ customerNames[order.customerId] }}</td>
            <td>{{ order.address }}</td>
            <td>{{ order.customerPhone }}</td>
            <td>{{ order.totalPrice }}</td>
            <!-- <td>{{ order.datecreate }}</td> -->
            <td>
              <router-link :to="{name: 'orderEdit', params: {id: order.id}}">
                <!-- nghĩa là ở router mình có nói là khi chuyển đến /order/edit/:id, thì id ở đây
                sẽ được nhận giá trị là order.id
                -->
                <button class="btn-handle-edit btn-handle">Edit</button>
              </router-link>
              <button @click="onDelete(order.id)" class="btn-handle-delete btn-handle">Delete</button>
            </td>
          </tr>
        </tbody>
        <tbody v-else>
          <tr v-for="(ordersearch, index) in ordersearchs" :key="index">
            <th scope="row">{{ index + 1 }}</th>
            <td>{{ ordersearch.id }}</td>
            <td>{{ productNames[ordersearch.productId] }}</td>
            <td>{{ customerNames[ordersearch.customerId] }}</td>
            <td>{{ ordersearch.address }}</td>
            <td>{{ ordersearch.customerPhone }}</td>
            <td>{{ ordersearch.totalPrice }}</td>
            
            <td>
              <router-link :to="{name: 'orderEdit', params: {id: ordersearch.id}}">
                <!-- nghĩa là ở router mình có nói là khi chuyển đến /order/edit/:id, thì id ở đây
                sẽ được nhận giá trị là order.id
                -->
                <button style="background-color:#007bff;" class="btn-handle-edit btn-handle">Edit</button>
              </router-link>
              <button @click="onDelete(ordersearch.id)" class="btn-handle-delete btn-handle">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
    </div>
</template>

<script>
import { ref } from 'vue';
import Swal from 'sweetalert2';
import axios from 'axios'
import urlOrigin from '../uses/urlOrigin';
export default {
  setup() {
        const {urlOriginOrder, urlOriginCustomer, urlOriginProduct} = urlOrigin();
        const searchText = ref(''); 
        const orders = ref([]); 
        const ordersearchs = ref([]); 
        const customerNames = ref({})
        const productNames = ref({})
        const onDelete = async id => {
          const { value: confirmed } = await Swal.fire({
          title: 'Are you sure?',
          text: "You won't be able to revert this!",
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Yes, delete it!'
          });
          if (confirmed) {
            try {
                await axios.delete(`${urlOriginOrder}/${id}`, {
                  headers: {
                   Authorization: `Bearer ${localStorage.getItem('jwt')}`
                  }
                });
                getAll();
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                );
            } catch (err) {
                console.log(err);
            }
          }
        };
        const getOderProductName = async (id) => {
          const res = await axios.get(`${urlOriginProduct}/${id}`, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('jwt')}`
            }
          });
          var name = res.data.name; 
          // console.log(customerNames);
          return name;
        }
        const getOrderCustomerName = async id => {
          const res = await axios.get(`${urlOriginCustomer}/${id}`, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('jwt')}`
            }
          });
          const customerName = res.data.name; 
          return customerName; 
        }
        console.log('--------------------')
        // console.log(getOderProductName(8));
        console.log('--------------------')
        const searchO = ()=> {
          if(searchText.value == '') {
            console.log('khong nhap tư khoa'); 
            alert('Vui lòng nhập từ khóa tìm kiếm'); 
            return 
          }
          console.log("run search ....")
          if(orders.value.length > 0){
            try{
            ordersearchs.value = orders.value.filter(o=> o.id.toString().includes(searchText.value))
            console.log('yess')
            console.log("-------------"); 
            // console.log(orders.value); 
            console.log(ordersearchs.value); 
            // console.log(searchText.value); 
            console.log("-------------"); 
            if(ordersearchs.value.length == 0){
              alert("Không có đơn hàng được tìm kiếm")
            }
            }catch(err) {
              console.log(err); 
            }
          }
        }

        const getAll = async()=> {
            try {
              const response = await fetch(urlOriginOrder, {
                headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
              }) 
              orders.value = await response.json(); 
              for (var order of orders.value) {
              const productName = await getOderProductName(order.productId);
              // console.log(customerName)
              productNames.value = {...productNames.value, [order.productId]: productName};

              const customerName = await getOrderCustomerName(order.customerId); 
              customerNames.value = {...customerNames.value, [order.customerId]: customerName}
              } 
              for (var order of orders.value){
              console.log('đây là product name:', productNames.value[order.productId]);
              console.log('đây là customer name:', customerNames.value[order.customerId]);
              }

            } catch(err) {
              console.log(err); 
            }
           
        }
        //----------------------------HÀM BACK
        // const back = () => {
        //   console.log('back'); 
        //   ordersearchs.value = []
        // } C1
        const back = function() {
          console.log('back'); 
          ordersearchs.value = []
        } // C2
        // back() {
        //   console.log('back'); 
        //   ordersearchs.value = []
        // } SAI
        //-------------------------------------
        getAll(); 
        return {orders, onDelete, searchO, ordersearchs, searchText, getOderProductName, back, productNames, customerNames}
    }
}
</script>

<style>
  .input-search::placeholder {
  color: rgba(0, 0, 0, 0.5); 
}
</style>