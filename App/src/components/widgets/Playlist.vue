<template>
  <div class="playlist">
    <div class="playlist--table-head">
      <div class="playlist--header">Song Name</div>
      <div class="playlist--header">Artist</div>
      <div class="playlist--header">Song Duration</div>
    </div>
    <song v-for="song in playlist" :key="song.songId" :song="song"></song>
  </div>
</template>

<script>
import Song from './Song'

export default {
  name: 'Playlist',
  components: {
    Song
  },
  mixins: [],
  props: {
    playlist: {
      type: Array,
      default: () => ([])
    }
  },
  data: () => ({}),
  created () {},
  mounted () {},
  updated () {},
  destroyed () {},
  watch: {},
  computed: {},
  methods: {},
  directives: {},
  filters: {},
}
</script>

<style lang="scss">
.playlist {
  display: flex;
  flex-direction: column;
  &--table-head {
    display: flex;
  }
  &--header {
    flex-basis: 25%;
    white-space: pre;
    overflow: hidden;
    text-overflow: ellipsis;
  }
}
</style>
