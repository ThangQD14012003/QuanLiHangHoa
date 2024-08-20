<template>
    <div>
        <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <h1 class="display-5">Customer infomation</h1>
            <router-link to="/user">Back</router-link>
        </div>
        <div class="container">
            <form @submit="save()">
                <!-- <div class="form-group row">
                <label for="inputPassword" class="col-sm-3 col-form-label">id</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control" 
                        v-model ="user.id"
                        :class="{'is-invalid': errors.id}"
                    />
                    <div v-if="errors.id" class="invalid-feedback">
                        {{ errors.id }}
                    </div>
                </div>
                </div> -->
                <div class="form-group row">
                <label for="inputPassword" class="col-sm-3 col-form-label">Họ tên</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control" 
                        v-model ="user.name"
                        :class="{'is-invalid': errors.name}"
                    />
                    <div v-if="errors.name" class="invalid-feedback">
                        {{ errors.name }}
                    </div>
                </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">Email</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" 
                            v-model ="user.email"
                            
                            :class="{'is-invalid': errors.email}"
                        />
                        <div v-if="errors.email" class="invalid-feedback">
                        {{ errors.email }}
                    </div>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">SĐT</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" 
                            v-model ="user.sdt"
                            :class="{'is-invalid': errors.sdt}"
                        />
                        <div v-if="errors.sdt" class="invalid-feedback">
                        {{ errors.sdt }}
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
import { useRouter, useRoute } from "vue-router"; 
import axios from "axios"; 
import urlOrigin from "../uses/urlOrigin";
import customer from "../uses/customer";
export default {
    setup(){
        const {urlOriginCustomer} =urlOrigin();
        const router = useRouter();
        const route = useRoute();
        const {addCustomer, updateCustomer} = customer;
        console.log('-----------')
        console.log(route.params.id); 
        console.log('-----------')
        const errors = ref({
            name: '', 
            email: '', 
            sdt: '', 
        })
        const user = ref({
            // id: '',
            name: '', 
            email: '', 
            sdt: '',
        })
        const validate = () =>  {
            let isValid = true; 
            errors.value =  {
                name: '', 
                email: '', 
                sdt: '', 
            }
            if(!user.value.name) {
                errors.value.name='Name is required'; 
                isValid = false; 
            }
            if(!user.value.email) {
                errors.value.email='email is required'; 
                isValid = false; 
            }
            if(!user.value.sdt) {
                errors.value.sdt='SĐT is required'; 
                isValid = false; 
            }
            // console.log(isValid); 
            return isValid; 
        }
        console.log('User before save:', user.value);
        const save = async() => {
            try {
                if(validate()){
                    if(user.value.id){
                        console.log("put")
                        // await axios.put(`${urlOriginCustomer}/${route.params.id}`, user.value, {
                        //     headers: {
                        //         Authorization: `Bearer ${localStorage.getItem('jwt')}`
                        //     }
                        // });
                        await updateCustomer(route.params.id, user.value);
                        router.push('/user'); 
                    }else {
                        console.log("post")
                        await addCustomer(user.value);
                        // Từ khóa await được sử dụng để chờ đợi kết quả của yêu cầu POST.
                        // Bởi vì axios.post trả về một Promise, await tạm dừng thực thi của hàm cho đến khi Promise được giải quyết 
                        // (resolved) hoặc bị từ chối (rejected).
                        console.log("posted")
                        router.push('/user');
                    }
                }
            }catch(err) {
                console.log(err)
            }
        }
        const getuser = async() => {
            const res = await axios.get(`${urlOriginCustomer}/${router.currentRoute._value.params.id}`, {
                headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
            }); 
            user.value = res.data; 
        }
        const getuserput = () => {
            if(router.currentRoute._value.params.id){
                getuser(); 
            }
        }
        getuserput(); 
        // const getAllCustomer = async() => {
        //   try {
        //     const res = await axios.get('https://localhost:7257/api/MyCustomer'); 
        //     user.value = res.data; 
        //     console.log(user.value); 
        //   }catch(err) {
        //     console.log(err); 
        //   } 
        // }
        // getAllCustomer();  lúc đầu có thằng getall này nên k ra 
        return {errors, user, save, validate}
    }

    
}
</script>