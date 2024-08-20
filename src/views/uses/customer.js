import instance from './config.js'

const getCustomer = () => {
    return instance.get("/MyCustomer", {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('jwt')}`
        }
    }); 
}
const addCustomer = (cutomer) => {
    return instance.post("/MyCustomer", cutomer, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('jwt')}`
        }
    });
}
const updateCustomer = (id, customer) => {
    return instance.put(`/MyCustomer/${id}`, customer, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('jwt')}`
        }
    })
}
const deleteCustomer = (id) => {
    return instance.delete(`/MyCustomer/${id}`, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem('jwt')}`
        }
    })
}
export default {
    getCustomer, addCustomer, updateCustomer, deleteCustomer
}