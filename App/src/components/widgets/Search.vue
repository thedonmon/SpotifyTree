<template>
  <div class="search-widget">
    <s-t-text-input class="search-widget--search" v-model="searchTerm" placeholder="Search for an artist..." />
    <s-t-button class="search-widget--action" @click="handleSearch">Generate Playlist</s-t-button>
  </div>
</template>

<script>
import STTextInput from './TextInput'
import STButton from './Button'

export default {
  name: 'SearchWidget',
  components: {
    STTextInput,
    STButton
  },
  mixins: [],
  props: {
  },
  data: () => ({
    searchTerm: ''
  }),
  created () {},
  mounted () {},
  updated () {},
  destroyed () {},
  watch: {},
  computed: {},
  methods: {
    handleSearch () {
      this.$emit('search', this.searchTerm)
    }
  },
  directives: {},
  filters: {},
}
</script>

<style lang="scss">
.search-widget {
  display: flex;
  &--search {
    flex-grow: 1;
    margin-right: 1em;
  }
  &--action {}
}
</style>
