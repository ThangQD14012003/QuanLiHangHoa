<template>
    <div>
        <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <h1 class="display-5">Order infomation</h1>
            <router-link to="/order">Back</router-link>
        </div>

        <div class="container">
            <form @submit.prevent="save()" style="position: relative; left: 0px">
                <div class="form-group row">
                <label for="inputPassword" class="col-sm-3 col-form-label">Product name</label>
                <div class="col-sm-9">
                    <select name="" id="" v-model="order.productId">
                        <option disabled value="">Select product name</option>
                        <option :value="product.id" class="form-control" v-for="(product, index) in products" :key="index">{{ product.name }}</option>
                    </select>
                    <div v-if="errors.productId" class="invalid-feedback">
                        {{ errors.productId }}
                    </div>
                </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">Customer name</label>
                    <div class="col-sm-9">
                        <select name="" id="" v-model="order.customerId">
                            <option disabled value="">Select product name</option>
                            <option :value="user.id" class="form-control" v-for="(user, index) in Users" :key="index">{{ user.name }}</option>
                        </select>
                        <div v-if="errors.customerId" class="invalid-feedback">
                        {{ errors.customerId }}
                    </div>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">Address</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" 
                            v-model ="order.address"
                      
                            :class="{'is-invalid': errors.address}"
                        />
                        <div v-if="errors.address" class="invalid-feedback">
                        {{ errors.address }}
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">Customer phone</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" 
                            v-model ="order.customerPhone"
                          
                            :class="{'is-invalid': errors.customerPhone}"
                        />
                        <div v-if="errors.customerPhone" class="invalid-feedback">
                        {{ errors.customerPhone }}
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">Total price</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" 
                            v-model ="order.totalPrice"
                         
                            :class="{'is-invalid': errors.totalPrice}"
                        />
                        <div v-if="errors.totalPrice" class="invalid-feedback">
                        {{ errors.totalPrice }}
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label"></label>
                    <div class="col-sm-9">
                        <button type="submit" class="btn btn-primary">Save</button> 
                        <button type="reset" class="btn btn-danger">Cancel</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import {ref} from "vue"
import { useRouter, useRoute } from "vue-router"; // Import useRouter
import axios from "axios"; // Import axios
import useUser from "../uses/useUser";
// cái useUser này là để lấy cái Users và getAll thằng user, còn cái product dùng option api nên k dùng kiểu này được
import urlOrigin from "../uses/urlOrigin";
export default {
    setup(){
        const router = useRouter();
        const route = useRoute();
        const products = ref([]); 
        console.log('-----------')
        console.log(router.currentRoute._value.params.id); 
        console.log('-----------')
        const errors = ref({
            productId: '', 
            customerId: '', 
            address: '', 
            customerPhone: '', 
            totalPrice: '', 

        })
        const order = ref({
            productId: '', 
            customerId: '', 
            address: '', 
            customerPhone: '', 
            totalPrice: '',

            
        })
        const {urlOriginOrder, urlOriginProduct} = urlOrigin()
        const getAllProduct = async() => {
          try {
            const res = await axios.get(urlOriginProduct, {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem('jwt')}`
                }
            }); 
            products.value = res.data; 
            // console.log(products.value); 
          }catch(err) {
            console.log(err); 
          } 
        }
        getAllProduct();
        //---------------------------------------
        // với cái customer thì mình dùng cái này 
        const {getAll, Users} = useUser()
        getAll(); 
        //-----------------------------------
        const validate = () =>  {
            let isValid = true; 
            errors.value =  {
                productId: '', 
                customerId: '', 
                address: '', 
                customerPhone:'', 
                totalPrice: '', 
            }
            if(!order.value.productId) {
                errors.value.productId='product name is required'; 
                isValid = false; 
            }
            console.log(order.value.productId); 
            if(!order.value.customerId) {
                errors.value.customerId='customer name is required'; 
                isValid = false; 
            }
            if(!order.value.address) {
                errors.value.address='address is required'; 
                isValid = false; 
            }
            if(!order.value.customerPhone) {
                errors.value.customerPhone='customer phone is required'; 
                isValid = false; 
            }
            if(!order.value.totalPrice) {
                errors.value.totalPrice='totalprice is required'; 
                isValid = false; 
            }
            console.log(isValid); 
            return isValid; 
        }
        const save = async() => {
            try {
                if(validate()){
                    if(order.value.id){
                        console.log(router)
                        await axios.put(`${urlOriginOrder}/${route.params.id}`, order.value, {
                            headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
                        })
                        router.push('/order'); 
                    }else {
                        await axios.post(urlOriginOrder, order.value, {
                            headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
                        })
                        console.log('hello')
                        router.push('/order');
                    }
                }
            }catch(err) {
                console.log(err)
            }
        }
        const getorder = async() => {
            const res = await axios.get(`${urlOriginOrder}/${route.params.id}`, {
                headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
            }); 
            order.value = res.data; 
        }
        const getorderput = () => {
            if(router.currentRoute._value.params.id){
                getorder(); 
            }
        }
        getorderput(); 
        return {errors, order, save, validate, products, Users}
    }
}
</script>

<style>
    select {
        width: 100%;
        height: 100%;
        border: 1px solid gray
    }
</style>