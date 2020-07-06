<template>
  <div class="row">
    <div
      class="col-md-4"
      v-for="(item,i) in modelData"
      :key="i"
    >
      <div class="card mb-4 mr-4">
        <!-- <img
          class="card-img-top"
          src="/assets/img/placeholder.svg"
          alt="Card image cap"
        > -->
        <apex-chart
          type="area"
          :options="spark"
          :series="spark.series"
          class="mt-4 ml-2 mr-2"
        ></apex-chart>

        <div class="card-body">
          <h5 class="card-title">{{item.name}}</h5>
          <p class="card-text">{{item.createdDate}}</p>
          <div class="btn-group">

            <router-link
              class="btn btn-secondary btn-sm"
              :to="{ name: 'monitoring-view', params: { id: item.id }}"
            >View Dashboard
            </router-link>

            <router-link
              class="btn btn-primary btn-sm"
              :to="{name:'monitoring-save',params:{ id:item.id}}"
            >
              Edit
            </router-link>
          </div>

        </div>
      </div>
    </div>

  </div>

</template>

<script>
import service from "services/monitoring"; //services kısmı alias ile webpack config kısmında tanımlandı
import VueApexCharts from "vue-apexcharts";
export default {
  components: { "apex-chart": VueApexCharts },
  data() {
    return {
      modelData: [],
      sparkData: [
        10,
        30,
        54,
        38,
        46,
        45,
        65,
        25,
        14,
        65,
        98,
        57,
        8,
        65,
        32,
        15,
        98,
        78,
        10,
        45,
        47,
        41,
        25,
        36
      ],
      spark: {
        series: [
          {
            data: []
          }
        ],
        chart: {
          type: "area",
          height: 160,
          sparkline: {
            enabled: true
          }
        },
        stroke: {
          curve: "straight"
        },
        fill: {
          opacity: 0.3
        },
        yaxis: {
          min: 0
        },
        colors: ["#DCE6EC"],
        title: {
          text: "99.34 %",
          offsetX: 0,
          style: {
            fontSize: "20pt"
          }
        },
        subtitle: {
          text: "Uptime",
          offsetX: 0,
          style: {
            fontSize: "14px"
          }
        }
      }
    };
  },

  async mounted() {
    this.spark.series[0].data = this.sparkData;
    var result = await service.list();
    if (result.data && result.data.length > 0) {
      this.modelData.push(...result.data);
    }
  }
};
</script>

<style>
</style>