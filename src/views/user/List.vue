<template>
    <div>
        <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center" style="padding: 0;">
        <h3 class="display-4">Customer list</h3>
        <p ><router-link to="/user/form">Add new</router-link></p>
        <input type="button" value="Back list" class="back" @click="back">
        <form @submit.prevent="searchU" style="display: inline">  
          <input placeholder="Điền vào tên khách hàng ..." class="input-search" type="text" name="search" style="width: 400px; padding-left: 4px; margin-right: 4px"
           v-model="searchText">
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
            <th scope="col">ID</th>
            <th scope="col">Name</th>
            <th scope="col">Email</th>
            <th scope="col">SĐT</th>
            <th scope="col">Handle</th>
          </tr>
        </thead>
        <tbody v-if="(usersearch.length == 0)" >
          <tr  v-for="(user, index) in Users" :key="index">
            <th scope="row">{{ index + 1 }}</th>
            <td>{{ user.id }}</td>
            <td>{{ user.name }}</td>
            <td>{{ user.email }}</td>
            <td>{{ user.sdt }}</td>
            <td>
              <router-link :to="{name: 'userEdit', params: {id: user.id}}">
              <!-- <router-link :to="{name: 'productEdit', params: {id: product.id}}"> -->
                <button class="btn-handle-edit btn-handle">Edit</button>
              </router-link>
              <button @click="onDelete(user.id)" class="btn-handle-delete btn-handle">Delete</button>
            </td>
          </tr>
        </tbody>
        <tbody v-else >
          <tr  v-for="(userse, index) in usersearch" :key="index">
            <th scope="row">{{ index + 1 }}</th>
            <td>{{ userse.id }}</td>
            <td>{{ userse.name }}</td>
            <td>{{ userse.email }}</td>
            <td>{{ userse.sdt }}</td>
            <td>
              <router-link :to="{name: 'userEdit', params: {id: userse.id}}">
              <!-- <router-link :to="{name: 'productEdit', params: {id: product.id}}"> -->
                <button class="btn-handle-edit btn-handle">Edit</button>
              </router-link>
              <button @click="onDelete(userse.id)" class="btn-handle-delete btn-handle">Delete</button>
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
import customer from '../uses/customer';
export default {
  setup() {
        const {urlOriginCustomer, urlOriginOrder} = urlOrigin();
        const searchText = ref('');
        const usersearch = ref([]); 
        const orders = ref([]); 
        const Users = ref([])
        const {getCustomer, deleteCustomer} = customer;
        const onDelete = async (id) => {
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
            getAllOrderCustomer();
            console.log("orders sau khi xóa: ",orders.value)
            const orderExists = orders.value.some(order => order.customerId == id);
            console.log('orderExists', orderExists)
            if(!orderExists ){
              try {
                // await axios.delete(`${urlOriginCustomer}/${id}`, {
                //   headers: {
                //     Authorization: `Bearer ${localStorage.getItem('jwt')}`
                //   }
                // });
                await deleteCustomer(id)
                getAll();
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                );
            } catch (err) {
                console.log(err);
            }
            }else {
              alert('Cannot remove customer'); 
            }
            
          }
        };
        const searchU = ()=> {
          if(searchText.value=='') {
            alert('Vui lòng nhập từ khóa tìm kiếm'); 
            return 
          }
          console.log("run search ....")
          if(Users.value.length > 0){
            try{
            usersearch.value = Users.value.filter(u=> u.name.toLowerCase().includes(searchText.value.toLowerCase()))
            // string mới sử dụng được inlcudes ( lúc đầu để là u.id)
            console.log('yess')
            console.log(Users.value); 
            if(usersearch.value.length == 0){
                alert("Không có khách hàng được tìm kiếm")
              }
            }catch(err) {
              console.log(err); 
            }
          }
        }
        const back = () => {
          console.log('back')
          usersearch.value = []
        }
        const getAll = async()=> {
            try {
              console.log("enter gatAll");
              const response = await getCustomer();

              Users.value = response.data; 
            } catch(err) {
              console.log(err); 
            }
        } 
        getAll(); 
        const getAllOrderCustomer = async() => {
          const res = await axios.get('https://localhost:7257/api/MyCustomer', {
            headers: {
                    Authorization: `Bearer ${localStorage.getItem('jwt')}`
                  }
          })
          orders.value = res.data; 
        }
        getAllOrderCustomer();
        return {Users, onDelete, searchText, searchU, usersearch, back}
    }
}
</script>