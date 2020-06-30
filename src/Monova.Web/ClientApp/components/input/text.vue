<template>
  <div class="form-group">
    <label for="exampleInputEmail1">{{title}}</label>
    <input
      type="text"
      class="form-control"
      :placeholder="placeholder"
      v-on:input="$emit('input', $event.target.value)"
      :value="value"
    >
  </div>
</template>

<script>
export default {
  props: {
    value: {
      default: null,
      type: String
    },
    placeholder: {
      default: "",
      type: String
    },
    title: {
      default: "",
      type: String
    }
  }
};
</script>

<style>
</style>