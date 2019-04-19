<template>
  <div class="song">
    <div class="song--name">{{ song.songName }}</div>
    <div class="song--artist">{{ song.artistName }}</div>
    <div class="song--duration">{{ song.duration }}</div>
    <div class="song--duration">
      <s-t-button @click="handleRemoveSong">Remove Song</s-t-button>
    </div>
  </div>
</template>

<script>
import STButton from './Button'

export default {
  name: 'Song',
  components: {
    STButton
  },
  mixins: [],
  props: {
    song: {
      type: Object,
      default: () => ({})
    }
  },
  data: () => ({}),
  created () {},
  mounted () {},
  updated () {},
  destroyed () {},
  watch: {},
  computed: {},
  methods: {
    handleRemoveSong () {
      this.$store.dispatch('removeSong', this.song.songId)
    }
  },
  directives: {},
  filters: {},
}
</script>

<style lang="scss">
.song {
  display: flex;
  &--name, &--artist, &--duration {
    flex-basis: 25%;
    white-space: pre;
    overflow: hidden;
    text-overflow: ellipsis;
  }
}
</style>
