<template>
  <div class="row">
    <div
      class="col-md-3"
      v-for="(item,i) in modelData"
      :key="i"
    >
      <div class="card mb-3 mb-4">
        <img
          class="card-img-top"
          src="/assets/img/placeholder.svg"
          alt="Card image cap"
        >
        <div class="card-body">
          <h5 class="card-title">{{item.name}}</h5>
          <p class="card-text">{{item.createdDate}}</p>

          <router-link class="card-link" :to="{ name: 'monitoring-view', params: { id: item.id }}">View</router-link>

        </div>
      </div>
    </div>

  </div>

</template>

<script>
import service from "services/monitoring"; //services kısmı alias ile webpack config kısmında tanımlandı
export default {
  data: function() {
    return {
      modelData: []
    };
  },

  async mounted() {
    var result = await service.list();
    if (result.data && result.data.length > 0) {
      this.modelData.push(...result.data);
    }
  }
};
</script>

<style>
</style>