<template>
  <div>
    <h1>Sign In</h1>
    <form autocomplete="off" method="post" @submit.prevent="login">
      <div>
        <div>
          <label>Email</label>
        </div>
        <div>
          <input v-model="email" type="email" required />
        </div>
      </div>

      <div>
        <div>
          <label>Password</label>
        </div>
        <div>
          <input v-model="password" type="password" required />
        </div>
      </div>

      <div>
        <input id="RememberMe" v-model="rememberMe" type="checkbox" />
        <label for="RememberMe">Remember Me</label>
      </div>

      <div><button type="submit">Sign In</button>&nbsp;</div>

      <p v-if="$auth.loggedIn">Usuario logueado</p>
      <p>{{ error }}</p>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: '',
      password: '',
      rememberMe: false,
      error: ''
    }
  },
  computed: {
    redirect() {
      return (
        this.$route.query.redirect &&
        decodeURIComponent(this.$route.query.redirect)
      )
    },
    isCallback() {
      return Boolean(this.$route.query.callback)
    }
  },
  methods: {
    login() {
      this.error = null
      return this.$auth
        .loginWith('local', {
          data: {
            email: this.email,
            password: this.password,
            rememberMe: this.rememberMe,
            clientId: 1,
            grantType: 'password',
            scope: 'offline_access'
          }
        })
        .catch((e) => {
          this.error = e + ''
        })
    }
  }
}
</script>

<style></style>
