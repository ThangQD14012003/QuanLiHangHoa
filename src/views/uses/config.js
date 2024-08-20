import axios from "axios";

const instance = axios.create({
    baseURL: "https://localhost:7257/api", 
});


export default instance
