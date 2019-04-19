import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Recommendations from './views/Recommendations.vue'

import store from './store'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/recommendations',
      name: 'recommendations',
      component: Recommendations,
      beforeEnter (to, from, next) {
        if (store.state.auth.accessToken === undefined || store.state.auth.tokenType === undefined) {
          next({ name: 'home' })
        }
        next()
      }
    },
    {
      path: '*',
      name: 'home',
      component: Home,
      beforeEnter (to, from, next) {
        const regex = /access_token=(.*)&token_type=(.*)&expires_in=(.*)&state=(.*)/
        const matched = to.fullPath.match(regex)
        if (matched.length > 1) {
          store.dispatch('setAuthorization', {
            accessToken: matched[1],
            tokenType: matched[2]
          })
          next({ name: 'recommendations' })
        } else {
          next({ name: 'home' })
        }
      }
    },
  ]
})
