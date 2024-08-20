<template>
    <div>
        <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <h1 class="display-5">Product image</h1>
            <router-link to="/product">Back</router-link>
        </div>
        <div class="container">
            <img :src="linkImg" alt="">
            <br>
        </div>
    </div>
</template>

<script>
import { ref } from 'vue';
import axios from 'axios'; 
import { useRouter, useRoute } from "vue-router"; 

export default {
    setup(){
        const haveImg = ref(false)
        const linkImg = ref('');
        const test = ref('abc')
        const router = useRouter();
        const route = useRoute();
        // console.log(route)
        // const id = router.currentRoute._value.params; 
        const getProduct = async()=> {
            const res = await axios.get(`https://localhost:7257/api/MyProduct/${route.params.id}`, {
                headers: {
                    Authorization: `Bearer ${localStorage.getItem('jwt')}`
                }
            }); 
            // linkImg.value = res.data.image;
            console.log(res.data); 
            const imagePath = res.data.image;
            
            console.log("đây là đường link: ", imagePath); 
            const imageParts = imagePath.split("\\");

            const imageName = imageParts[imageParts.length - 1];
           
            linkImg.value = `https://localhost:7257/Images/${imageName}`
            console.log("đây là linkImg sau khi convert để truyền lên: ", linkImg.value);

        }
        getProduct();
        return {linkImg}
    }
}

</script>

<style scoped>
img{
    /* position: absolute; */
    height: 400px;
    width:  auto;
    padding-bottom: 20px;
    padding: 10px;
}
</style>