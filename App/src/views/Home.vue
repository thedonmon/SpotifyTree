<template>
  <div class="home">
    
  </div>
</template>

<script>

export default {
  name: 'home',
  components: {},
  mounted () {
    this.authorize()
  },
  methods: {
    authorize () {
      var client_id = '56fe9ecd118c4d5699bc17e3bc7b4350'
      var redirect_uri = 'https://spotifytree-d8e02.firebaseapp.com/#/authorize'

      var state = this.generateRandomString(16);

      var scope = 'user-read-private user-read-email playlist-modify-public playlist-modify-private';

      var url = 'https://accounts.spotify.com/authorize';
      url += '?response_type=token';
      url += '&client_id=' + encodeURIComponent(client_id);
      url += '&scope=' + encodeURIComponent(scope);
      url += '&redirect_uri=' + encodeURIComponent(redirect_uri);
      url += '&state=' + encodeURIComponent(state);

      window.location = url;
    },
    generateRandomString(length) {
      var text = '';
      var possible = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';

      for (var i = 0; i < length; i++) {
        text += possible.charAt(Math.floor(Math.random() * possible.length));
      }
      return text;
    }
  }
}
</script>
