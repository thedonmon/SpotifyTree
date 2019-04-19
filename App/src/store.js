import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const RECOMMENDATION_GENERATOR_BASE = 'https://spotifytree.azurewebsites.net'
const RECOMMENDATION_GENERATOR_API = RECOMMENDATION_GENERATOR_BASE + '/api/home'
const CREATE_PLAYLIST = RECOMMENDATION_GENERATOR_API + '/createPlaylist'

export default new Vuex.Store({
  state: {
    auth: {},
    playlistName: '',
    generatedPlaylist: [
      // {
      //   ArtistId,
      //   ArtistName,
      //   SongId,
      //   SongName,
      //   Duration (ms)
      // }
    ]
  },
  mutations: {
    setGeneratedPlaylist (state, playlist) {
      state.generatedPlaylist = playlist
    },
    removeSong (state, songId) {
      state.generatedPlaylist = state.generatedPlaylist.filter(s => s.songId !== songId)
    },
    setAuthorization (state, auth) {
      state.auth = auth
    },
    setPlaylistName (state, name) {
      state.playlistName = name
    }
  },
  actions: {
    async createPlaylist ({ commit, state }) {
      const accessToken = state.auth.accessToken
      const tokenType = state.auth.tokenType
      if (accessToken === undefined || tokenType === undefined) return
      const data = {
        AccessToken: accessToken,
        TokenType: tokenType,
        PlaylistName: state.playlistName,
        SongIds: state.generatedPlaylist.map(p => p.songUri)
      }
      const res = await axios({
        method: 'post',
        url: CREATE_PLAYLIST,
        headers: { 'content-type': 'application/json' },
        data
      })
    },
    async generatePlaylist ({ commit }, { searchTerm }) {
      const criteria = {
        ArtistName: searchTerm.trim()
      }
      const res = await axios({
        method: 'post',
        url: RECOMMENDATION_GENERATOR_API,
        headers: { 'content-type': 'application/json' },
        data: criteria
      })
      console.log(res)
      commit('setPlaylistName', searchTerm)
      commit('setGeneratedPlaylist', res.data)
      
    },
    removeSong ({ commit }, songId) {
      commit('removeSong', songId)
    },
    setAuthorization ({ commit }, auth) {
      commit('setAuthorization', auth)
    }
  },
  getters: {
    hasReccomendation: state => state.generatedPlaylist.length > 0,
    generatedPlaylist: state => state.generatedPlaylist
  }
})
