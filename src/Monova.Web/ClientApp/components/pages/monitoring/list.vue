<template>
  <div class="col-md-12">
    <div class="col-md-4" v-for="(item,i) in modelData" :key="i">
      <div
        class="card"
        style="width: 18rem;"
      >
        <img
          class="card-img-top"
          src="/assets/img/placeholder.svg"
          alt="Card image cap"
        >
        <div class="card-body">
          <h5 class="card-title">{{item.name}}</h5>
          <p class="card-text">{{item.createdDate}}</p>

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