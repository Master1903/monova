
<template>
  <div>
    <ol class="breadcrumb float-sm-left">

      <!-- <li :v-for="p in this.$route.path.split('/')">{{p}}</li> -->
      <li class="breadcrumb-item"> {{prefix}}</li>
      <li class="breadcrumb-item active strong font-weight-bold">{{title}}</li>
    </ol>

  </div>

</template>

<script>
import { routes } from "@/router/routes";
export default {
  computed: {
    prefix() {
      let path = this.$route.path;
      if (path) return path.split("/")[1];
    },
    title() {
      let path = this.$route.path;
      if (path) return path.split("/")[2];
    }
  }
};
</script>

<style>
</style>