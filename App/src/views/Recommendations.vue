<template>
  <div class="recommendations">
    <template v-if="hasReccomendation">
      <div class="recommendations--playlist">
        <s-t-search-widget @search="handleSearchPlaylists" />
        <playlist :playlist="generatedPlaylist"></playlist>
        <s-t-button @click="handleCreatePlaylist">Create Playlist</s-t-button>
      </div>
    </template>
    <template v-else>
      <div class="recommendations--search-panel">
        <s-t-search-widget class="recommendations--search-panel-widget" @search="handleSearchPlaylists" />
      </div>
    </template>
  </div>
</template>

<script>
import STSearchWidget from '@/components/widgets/Search'
import Playlist from '@/components/widgets/Playlist'
import STButton from '@/components/widgets/Button'

export default {
  name: 'Recommendations',
  components: {
    STSearchWidget,
    Playlist,
    STButton
  },
  mixins: [],
  props: {},
  data: () => ({}),
  created () {},
  mounted () {},
  updated () {},
  destroyed () {},
  watch: {},
  computed: {
    generatedPlaylist () {
      return this.$store.getters['generatedPlaylist']
    },
    hasReccomendation () {
      return this.$store.getters['hasReccomendation']
    }
  },
  methods: {
    handleSearchPlaylists (searchTerm) {
      const searchCriteria = { searchTerm }
      this.$store.dispatch('generatePlaylist', searchCriteria)
    },
    handleCreatePlaylist () {
      this.$store.dispatch('createPlaylist')
    }
  },
  directives: {},
  filters: {},
}
</script>

<style lang="scss">
.recommendations {
  height: 100%;
  width: 100%;
  &--search-panel {
    height: 100%;
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  &--search-panel-widget {
    width: 100%;
    max-width: 25em;
  }
  &--playlist {
    display: flex;
    flex-direction: column;
  }
}
</style>
