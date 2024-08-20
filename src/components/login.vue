<template>
    <div>
        <form class="container-form" action="" @submit.prevent="login()">
            <div class="anh-nen">
                <img src="../assets/img/anh5.png" alt="">
            </div>
            <div class="login">
                <div class="content" >
                    <h3>Login into account</h3>
                    <i class="fa-regular fa-user user"></i>
                </div>
                <div class="container">
                    <!-- <button class="icon"><i class="fa-regular fa-user"></i></button> -->
                    <div class="form-input">
                        <span class="container-icon"><i class="fa fa-envelope-o icon"></i></span>
                        <input v-model="user.email" type="text" name="email" placeholder="Email" class="box" autocomplete="off">
                    </div>
                    <!-- <button type="input" placeholder="email"></button> -->
                    <div class="form-input">
                        <span class="container-icon"><i class="fa fa-key icon"></i></span>
                        <input v-model="user.password" type="password" name="password" placeholder="Password" class="box">
                    </div>
                    <input type="submit" name="submit" value="Login" class="btn">
                    <div class="other">
                        <div class="text">Or login with</div>
                        <button class="other-btn other-fb" >Facebook</button>
                        <button class="other-btn other-gg" >Google</button>
                        <button class="other-btn other-tw">Twitter</button>
                    </div>
                    <hr>
                    <p>Don't have an account? <router-link to="/register">Register here</router-link></p>
                </div>
            </div>
            
            
        </form>
    </div>
</template>

<script>
import {ref} from "vue"
import { useRouter } from "vue-router"; // Import useRouter
import axios from "axios"; // Import axios
import urlOrigin from "@/views/uses/urlOrigin";
export default {
    setup(){
        const {urlOriginLogin} = urlOrigin();
        const router = useRouter(); 
        const isLogin = ref(false) 
        const user = ref({
            email: '', 
            password: ''
        })
        console.log('isLogin: ', isLogin.value); 
        const login = async() => {
            if (!user.value.email || !user.value.password) {
            alert("Vui lòng nhập email và password");
            return;
            }
            try{
                const res = await axios.post(urlOriginLogin, user.value); 
                console.log(res.data)
                const token = res.data; 
                // const decoded = jwt_decode(token); 
                // console.log(decoded);
                if (token) {
                    // Lưu trữ JWT vào localStorage hoặc sessionStorage
                    localStorage.setItem('jwt', token);
                    console.log('da lu vao localstorage')
                    router.push({ name: 'Home' });
                }
            }catch(err) {
                alert("Email hoặc mất khẩu không đúng")
            }
            
        } 
        return {login, isLogin, user}
    }
}
</script>

<style scoped>
    .container-form {
        /* margin-top: px; */
        display: flex;
        box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.3);
        width: 800px;
        height: 440px;
        margin: 100px auto;
        position: relative;
        border-radius: 30px;
        overflow: hidden;
        background: linear-gradient(45deg, #e0cad3, #d5ff96, #33ccff);
    }
    .anh-nen img {
        width: 300px;
        height: auto;
    } 
    .login {
        margin: auto;
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
    input {
        outline: none;
    }
    input[type="submit"] {
        width: 180px;
        padding: 6px;
        background-color: rgb(33, 134, 228);
        color: aliceblue;
        border-radius: 30px;
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
    .other-btn {
        border-radius: 20px;
        width: 100px;
        border: 1px solid grey;
        outline: none; 
    }
    .other-fb {
        background-color: #4866a8;
        color: white
    }
    .other-gg {
        background-color: rgb(32, 73, 255);
        color: white
    }
    .other-tw {
        background-color: #33ccff;
        color: white
    }
    .other {
        margin-top: 20px;
    }
    .text {
        padding: 0 10px 20px;
    }
</style>