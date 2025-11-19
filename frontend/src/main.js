import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { createVuetify } from 'vuetify'

import App from './App.vue'
import router from './router'

const vuetify = createVuetify()

const app = createApp(App).use(vuetify).mount('#app')

app.use(createPinia())
app.use(router)

app.mount('#app')
