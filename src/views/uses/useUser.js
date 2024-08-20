import {ref} from "vue"
import axios from 'axios'
export default function() {
    const Users = ref([]); 
    const getAll = async()=> {
        try {
          const response = await axios.get("https://localhost:7257/api/MyCustomer", {
            headers: {
                            Authorization: `Bearer ${localStorage.getItem('jwt')}`
                        }
          }); 
          Users.value = response.data; 
          console.log('------------------')
          console.log(Users.value); 
          console.log('------------------')
          
        } catch(err) {
          console.log(err); 
        }
    }
    return {getAll, Users}
}