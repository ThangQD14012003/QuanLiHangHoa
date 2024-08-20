<template>
    <div>
        <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
            <h1 class="display-5">Product infomation</h1>
            <router-link to="/product">Back</router-link>
        </div>
        <div class="container">
            <form @submit.prevent="save()">
                <div class="form-group row">
                <label for="inputPassword" class="col-sm-3 col-form-label">Product name</label>
                <div class="col-sm-9">
                    <input type="text" 
                    class="form-control" 
                    v-model="product.name"
                   :class="{'is-invalid': errors.name}"
                    />
                    <div v-if="errors.name" class="invalid-feedback">
                        {{ errors.name }}
                    </div>
                </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">Product price</label>
                    <div class="col-sm-9">
                        <input type="text" 
                        class="form-control" 
                        v-model="product.price"
                       
                        :class="{'is-invalid': errors.price}"
                        />
                    <div v-if="errors.price" class="invalid-feedback">
                        {{ errors.price }}
                    </div>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">Product description</label>
                    <div class="col-sm-9">
                        <textarea class="form-control" rows="3" v-model="product.description"></textarea>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-3 col-form-label">Upload img</label>
                    <div class="col-sm-9" style="margin-top: 8px">
                        <input class="img" type="file"  @change="handleFileUpload"/>
                    </div>
                    <!-- <div v-if="product.imgUrl">
                        <img alt="Product Image" style="max-width: 100%; height: auto; margin-top: 10px;"/>
                    </div> -->
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
// với option api thì không dùng được cái import 
export default {
    name: "ProductForm", 
    data() {
        return {
            errors: {
                name: '', 
                price: '', 
                description: '', 
            },
            product:{
                name: '', 
                price: '', 
                description: '', 
                image: "", 
                imgUrl: '', 
            }, 
        }
            
    },
    created() {
        let productID = this.$route.params.id; 
        if(productID) {
            this.getProduct(productID); 
            
        }
    },
    methods: {
        validate() {
            let isValid = true; 
            this.errors =  {
                name: '', 
                price: '', 
                description: '', 
            }
            if(!this.product.name) {
                this.errors.name='Name is required'; 
                isValid = false; 
            }
            if(!this.product.price) {
                this.errors.price='Price is required'; 
                isValid = false; 
            }else if(this.isNumber(this.product.price) === false){
                this.errors.price='Price is not string'; 
                isValid = false; 
            }
            return isValid; 
        },
        isNumber(value){
            if(value === "a") {
                return false; 
            }
        },
        handleFileUpload(event){
            const file = event.target.files[0];
            this.product.image = file;
            console.log('product.image:', this.product.image)
            // this.product.imgUrl = URL.createObjectURL(file);
            console.log(this.product.image);
        },
        save() {
            if(this.validate()){
                const formData = new FormData();
                    formData.append('name', this.product.name);
                    formData.append('price', this.product.price);
                    formData.append('description', this.product.description);
                    formData.append('image', this.product.image);
                    // lúc đầu k hiểu tại sao lại k up được ảnh khi k chọn ảnh, lí do là vì 
                    //cái gửi đi là phải là 1 tệp ảnh chứ nếu k chọn ảnh thì cái gửi đi chỉ là 1 url của ảnh
                if(this.product.id){
                    
                    // console.log("MYPUT")
                    // console.log(this.product.id)
                    console.log("this is formData", formData);
                    this.$request.put(`https://localhost:7257/api/MyProduct/${this.product.id}`, formData, {
                        headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }}).then(
                            res=> {
                                this.$router.push({name: 'productList'}); 
                                }
                        )
                        .catch(err => {
                        console.log(err); 
                    })}
                    else {
                    console.log("MYPOST")
                    console.log(formData)
                    console.log(this.product);
                    this.$request.post('https://localhost:7257/api/MyProduct', formData, {
                        headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
                    }).then(
                        res=> {
                            console.log(res); 
                            if(res.status == 200){
                                console.log(res);
                                this.$router.push({name: 'productList'}); 
                            }else if(res.statusText != 200){
                                alert('Something went wrong')
                            }
                        }
                    )
                    }
            }
        },
        getProduct(productId){
            this.$request.get(`https://localhost:7257/api/MyProduct/${productId}`,{
                headers: {
                                Authorization: `Bearer ${localStorage.getItem('jwt')}`
                            }
            }).then(res=>{
                // Trong Vue.js, this.$request.get và các phương thức gửi yêu cầu HTTP khác là các hoạt động bất đồng bộ
                console.log("res.data:",res.data); 
                this.product = res.data; 
                this.product.imgUrl = res.data.image; 
                console.log('imgUrl: ', this.product.imgUrl)
                console.log('image:', this.product.image)
            })
            
        }
    }
}
</script>

<style scoped>
    .img{
        margin-right: 700px;
    }
</style>>

