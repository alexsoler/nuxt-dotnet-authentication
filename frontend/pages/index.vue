<template>
  <div class="container">
    <div>
      <logo />
      <h1 class="title">
        frontend
      </h1>
      <h2 class="subtitle">
        Nuxt.js project with ServiceStack backend
      </h2>
      <div class="links">
        <a href="https://nuxtjs.org/" target="_blank" class="button--green">
          Documentation
        </a>
        <a
          href="https://github.com/nuxt/nuxt.js"
          target="_blank"
          class="button--grey"
        >
          GitHub
        </a>
        <nuxt-link v-if="!$auth.loggedIn" to="/login" class="button--grey"
          >Login</nuxt-link
        >
        <a v-else class="button--grey" @click="$auth.logout()">Logout</a>
      </div>
    </div>
    <div>
      <table v-if="$auth.loggedIn" class="table-weathers">
        <thead>
          <tr>
            <th>Date</th>
            <th>Summary</th>
            <th>Temp. C°</th>
            <th>Temp. F°</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(weather, index) in weathers" :key="index">
            <td>{{ weather.date | formatDate }}</td>
            <td>{{ weather.summary }}</td>
            <td>{{ weather.temperatureC }}</td>
            <td>{{ weather.temperatureF }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import Logo from '~/components/Logo.vue'

export default {
  auth: false,
  components: {
    Logo
  },
  filters: {
    formatDate(value) {
      if (value) {
        const date = new Date(String(value))

        return date.toDateString()
      }
    }
  },
  async asyncData({ $axios, isDev, $auth }) {
    let weathers = []

    if ($auth.loggedIn) {
      if (isDev) {
        process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0'
      }

      weathers = await $axios.$get('/api/WeatherForecast')
    }

    return { weathers }
  }
}
</script>

<style>
.container {
  margin: 0 auto;
  min-height: 100vh;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.title {
  font-family: 'Quicksand', 'Source Sans Pro', -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}

.table-weathers {
  width: 50%;
  margin: auto;
  margin-top: 20px;
}
</style>
