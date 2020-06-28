<template>
  <div class="form-group">
    <label for="exampleInputEmail1">{{title}}</label>
    <input
      type="text"
      class="form-control"
      :placeholder="placeholder"
      v-on:input="$emit('input', $event.target.value)"
    >
  </div>
</template>

<script>
export default {
  props: {
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