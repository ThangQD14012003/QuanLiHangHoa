export default function() {
    const urlOriginOrder = 'https://localhost:7257/api/Order'; 
    const urlOriginProduct = 'https://localhost:7257/api/MyProduct';
    const urlOriginCustomer = 'https://localhost:7257/api/MyCustomer';
    const urlOriginLogin = 'https://localhost:7257/api/Acount/SignIn'; 
    const urlOriginRegister = 'https://localhost:7257/api/Acount/SignUp';
    return {
        urlOriginOrder, urlOriginProduct, urlOriginCustomer, urlOriginLogin, urlOriginRegister
    }
}