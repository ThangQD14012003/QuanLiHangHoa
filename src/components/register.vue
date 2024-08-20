<template>
    <div>
        
    <form class="container-form" @submit.prevent="Register">
        <div class="anh-nen">
            <img src="../assets/img/anh3.jpg" alt="">
        </div>
        <div class="register">
            <div class="content" >
                <h3>Register</h3>
                <i class="fa-regular fa-user user"></i>
            </div>
            <div class="wrap-form-input">
                <div class="form-input">
                <span class="container-icon"><i class="fa-regular fa-face-smile-beam icon"></i></span>
                <input autocomplete="off" v-model="accout.name" type="text" name="name" placeholder="Name" class="box">
                </div>
                <div class="form-input">
                    <span class="container-icon"><i class="fa fa-envelope-o icon"></i></span>
                    <input autocomplete="off" v-model="accout.email" type="text" name="email" placeholder="Email" class="box">
                </div>
                <div class="form-input">
                    <span class="container-icon"><i class="fa fa-key icon icon"></i></span>
                    <input autocomplete="off" v-model="accout.password" type="password" name="password" placeholder="Password" class="box">
                </div>
                <div class="form-input">
                    <span class="container-icon"><i class="fa fa-key icon icon"></i></span>
                    <input autocomplete="off" v-model="accout.confirmPassword" type="password" name="cpassword" placeholder="Password confirm" class="box">
                </div>
            </div>
            
            <input type="submit" name="submit" value="Sign up" class="btn">
            <hr>
            <p>Already have an account? <router-link to="/login">Login</router-link></p>
        </div>
      
   </form>
    </div>
</template>
<script>
import {ref} from "vue"
import { useRouter } from "vue-router"; 
import axios from "axios";
import urlOrigin from "@/views/uses/urlOrigin";
export default {
    setup() {
        const {urlOriginRegister} = urlOrigin();
        const router = useRouter(); 
        const accout = ref({
            name: '', 
            email: '', 
            password: '', 
            confirmPassword: '', 
        })
        console.log(accout.value.name); 
        const Register = async() => {
            try {
                console.log(accout.value); 
                if(accout.value.password === accout.value.confirmPassword && 
                (accout.value.name !='' || accout.value.email !='' || accout.value.password !='' || accout.value.confirmPassword !='' )){
                    const res = await axios.post(urlOriginRegister, accout.value); 
                    router.push({name: 'login'});
                    alert('Đăng kí thành công')
                }else {
                    alert('Vui lòng nhập đầy đủ và đúng thông tin')
                }
            }catch {
                alert("Nhập mật khẩu đầy đủ chữ hoa, số và kí tự đặc biệt")
            }
            
        }
        return {
            Register, accout, Register
        }
    }
}
</script>


<style scoped>

    .form-input {
        border: 1px solid grey;
        width: 340px;
        height: 36px;
        border-radius: 30px;
        margin: 20px;
        display: flex;
    }
    .container-form {
        /* margin-top: px; */
        display: flex;
        box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.3);
        width: 800px;
        height: 500px;
        margin: 60px auto;
        position: relative;
        border-radius: 30px;
        overflow: hidden;
        background-color: rgb(230, 254, 252);
    }
    .anh-nen img {
        width: 100%;
        height: 600px
        /* width: 30%; */
    } 
    .anh-nen {
        flex: 1 0 40%; 
    }
    .register {
        margin: auto 40px; 
        /* flex: 1 0 70%;  */
    }
    input[type="submit"]:hover{
        background-color: rgb(92, 94, 246);
    }
    .content {
        margin-bottom: 30px;
        /* background-color: aqua; */
        /* margin: auto; */
        height: 50px;
    }
    h3 {
        margin-top: 30px;
    }
    .user {
        width: 40px;
        height: auto;
        font-size: 30px; 
        opacity: 0.8;
        color: rgb(33, 134, 228);
    }
    input[type="submit"] {
        width: 180px;
        padding: 6px;
        background-color: rgb(33, 134, 228);
        color: aliceblue;
        border-radius: 30px;
    }
    input {
        outline: none;
    }
    input[type="text"] {
        height: 100%;
        border: none;
        width: 300px;
        border-radius: 30px;
    }
    input[type="password"] {
        height: 100%;
        border: none;
        width: 300px;
        border-radius: 30px;
    }
    .form-input {
        border: 1px solid grey;
        width: 340px;
        height: 36px;
        border-radius: 30px;
        margin: 20px;
        display: flex;
        background-color: white;
    }
    .icon {
        /* padding: 4px;  */
        line-height: 100%;
        margin: auto;
        position: relative;
        top: 6px;
        font-size: 20px;
        border: none;
        opacity: 0.9;
        color: rgb(33, 134, 228);;
    }
    span {
        width: 10%;
        /* padding: 6px */
    }
</style>