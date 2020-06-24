<template>
  <div>
    <button @click="save">Save</button>
  </div>
</template>

<script>
import service from "services/monitoring";
export default {
  methods: {
    async save() {
      var result = service.save({
        name: "ahmet akarsu",
        url: "ahmetakarsu.net"
      });
    }
  }
};
</script>

<style>
</style>