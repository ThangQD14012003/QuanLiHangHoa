import { createRouter, createWebHashHistory } from 'vue-router'
import ListProduct from "../views/product/List.vue"
import FormProduct from "../views/product/FormCreate.vue"
import ListUser from "../views/user/List.vue"
import FormUser from "../views/user/FormCreate.vue"
import Home from "../components/Home.vue"
import ListOrder from "../views/order/List.vue"
import FormOrder from "../views/order/FormCreate.vue"
import ImgProduct from "../views/product/img.vue"
import Login from "../components/login.vue"
import Register from "../components/register.vue"
const routes = [
  {
    path: "/login", 
    name: 'login',
    component: Login, 
  },
  {
    path: "/register", 
    name: 'register',
    component: Register, 
  },
  {
   path: "/product", 
   name: 'productList',
   component: ListProduct, 
  }, 
  {
   path: "/product/form", 
   name: 'productForm',
   component: FormProduct, 
  }, 
  {
   path: "/product/edit/:id", 
   // /:id là params trên router, và khi ở form html thì truyển params vào
   name: 'productEdit',
   component: FormProduct, 
  }, 
  {
   path: "/product/img/:id", 
   name: 'productImg',
   component: ImgProduct, 
  }, 
  {
   path: "/user", 
   name: 'userList',
   component: ListUser, 
  }, 
  {
   path: "/user/form", 
   name: 'userForm',
   component: FormUser, 
  }, 
  {
   path: "/user/edit/:id", 
   name: 'userEdit',
   component: FormUser, 
  }, 
  {
    path: "/Home", 
    name: 'Home', 
    component: Home,
  }, 

  {
    path: "/order", 
    name: 'orderList',
    component: ListOrder, 
  }, 
  {
    path: "/order/form", 
    name: 'orderForm',
    component: FormOrder, 
  }, 
  {
    path: "/order/edit/:id", 
    // /:id là params trên router, và khi ở form html thì truyển params vào
    name: 'orderEdit',
    component: FormOrder, 
   }, 
  //  {
  //   path: "/user/search/:id", 
  //   name: "searchCustomer", 
  //   component: searchCustomer
  //  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router