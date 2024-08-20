<template>
    <div>
        <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
        <h3 class="display-4">Product list</h3>
        <p ><router-link to="/product/form">Add new</router-link></p>
        <input type="button" value="Back list" @click="back" class="back">
        <form class="search" @submit.prevent="search" style="display: inline;">
          <input placeholder="Điền vào tên sản phẩm ..." class="input-search" type="text" 
          name="search" style="width: 400px; padding-left: 4px; margin-right: 4px" v-model="searchText">
          <!-- <button type="submit" class="btn-search">Tìm kiếm</button> -->
          <input type="submit" value="Tìm kiếm" class="btn-search" >
        </form>
    </div>

  <div class="container">
    <div class="card-deck mb-3 text-center">
      <table class="table table-bordered">
        <thead>
          <tr>
            <th scope="col">STT</th>
            <th scope="col">ID</th>
            <th scope="col">Product name</th>
            <th scope="col">Price</th>
            <th scope="col">Description</th>
            <th scope="col">Image</th>
            <th scope="col">Handle</th>
          </tr>
        </thead>
        <tbody v-if="productsearch.length == 0">
          <tr v-for="(product, index) in products" :key="index">
            <th scope="row">{{ index + 1 }}</th>
            <td>{{ product.id }}</td>
            <td>{{ product.name }}</td>
            <td>{{ product.price }}</td>
            <td>{{ product.description }}</td>
            <td>
                <router-link :to="{name: 'productImg', params: {id: product.id}}" >
                  <i class="fa-solid fa-eye"></i>
                </router-link>
            </td>
            <td>
              <router-link :to="{name: 'productEdit', params: {id: product.id}}">
                <button class="btn-handle-edit btn-handle">Edit</button>
              </router-link>
              <button @click="onDelete(product.id)" class="btn-handle-delete btn-handle">Delete</button>
            </td>
          </tr>
        </tbody>
        <tbody v-else> 
          <tr v-for="(product, index) in productsearch" :key="index">
            <th scope="row">{{ index + 1 }}</th>
            <td>{{ product.id }}</td>
            <td>{{ product.name }}</td>
            <td>{{ product.price }}</td>
            <td>{{ product.description }}</td>
            <td>
                <router-link :to="{name: 'productImg', params: {id: product.id}}" >
                  <i class="fa-solid fa-eye"></i>
                </router-link>
            </td>
            <td>
              <router-link :to="{name: 'productEdit', params: {id: product.id}}">
                <button class="btn-handle-edit btn-handle">Edit</button>
              </router-link>
              <button @click="onDelete(product.id)" class="btn-handle-delete btn-handle">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
    </div>
</template>

<script>
export default {
    name: "ProductForm", 
    data() {
        return {
            products:[

            ], 
            productsearch:[

            ], 
            searchText: '', 
            orders: [

            ]
        }  
    },
    created(){
        this.getAll(); 
    }, // chạy luôn khi components còn chưa được khởi tạo
    methods: {
      onDelete(id) {
        this.$swal.fire({
        title: "Do you want to delete?",
        showDenyButton: false,
        showCancelButton: true,
        confirmButtonText: "OK",
        // denyButtonText: Don't save
        }).then((result) => {
          this.getAllOrderProduct();
          const orderExists = this.orders.some(order => order.productId == id);
          console.log('orderExists', orderExists);
          if(!orderExists){
          if (result.isConfirmed) {
            }
            this.$request.delete(`https://localhost:7257/api/MyProduct/${id}`, {
              headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
            }).then(res=> {
              if(res.status == 200){
                this.$swal.fire('Deleted!', '', 'success'); 
                this.getAll(); 
              }
            }
            )
          }else {
            alert('Cannot remove Product')
          }})
        }, 
        getAllOrderProduct(){
          this.$request.get('https://localhost:7257/api/Order', {
            headers: {
                    Authorization: `Bearer ${localStorage.getItem('jwt')}`
                  }
          }).then(res=> {
          this.orders = res.data
        })
      }, 
        search(){
          
          if(this.searchText == '') {
            alert('Vui lòng nhập từ khóa tìm kiếm'); 
            return 
          }
          try {
            console.log("serach runn")
            // this.searchText.toLowerCase();
            // console.log(this.searchText); 
            this.productsearch = this.products.filter(p=> p.name.toLowerCase().includes(this.searchText.toLowerCase())); 
            console.log("end search");
            // if(!this.searchText){
            //   this.getAll();
            // }
            // if(this.productsearch.length ==0){
            //   alert("Không có sản phẩm được tìm kiếm")
            // }
          }catch(err) {
            console.log(err); 
          }
        },
        getAll() {
        this.$request.get('https://localhost:7257/api/MyProduct', {
          headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
        }).then(res=> {
          this.products = res.data
        })
      }, 
      back() {
        console.log('back')
        this.productsearch=[];
      },
      }

          

  }
</script>
<style scoped>

</style>