<template>

</template>

<script>
import service from "services/monitoring"; //services kısmı alias ile webpack config kısmında tanımlandı
export default {
  async mounted() {
    var data = await service.list();
  }
};
</script>

<style>
</style>