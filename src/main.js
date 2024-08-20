import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import './assets/css/style.css'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css'; // xác nhận hủy
const app = createApp(App)
app.use(VueSweetalert2);
app.use(VueAxios, { $request: axios })
app.use(router).mount('#app')