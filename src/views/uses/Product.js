import instance from "./config"

const getProducts = async() => {
    return instance.get('/MyProduct'); 
}
export default {
    getProducts
}