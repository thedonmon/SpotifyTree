<template>
  <input
    class="search"
    type="text"
    :value="value"
    @input="handleInput"
    :placeholder="placeholder"
  >
</template>

<script>
export default {
  name: 'Search',
  components: {},
  mixins: [],
  props: {
    value: {
      type: String,
      required: true
    },
    placeholder: {
      type: String,
      default: ''
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
    handleInput (e) {
      this.$emit('input', e.target.value)
    }
  },
  directives: {},
  filters: {},
}
</script>

<style lang="scss">

</style>
