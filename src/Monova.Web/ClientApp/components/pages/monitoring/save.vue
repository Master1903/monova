<template>
  <div class="row">
    <div class="col-md-4">
      <mvi-text
        placeholder="Name"
        title="Project Name"
        v-model="modelData.name"
      />
    </div>
    <div class="col-md-4">
      <mvi-text
        placeholder="url"
        title="Project Url"
        v-model="modelData.url"
      />
    </div>

    <div class="col-md-3 mt-4">
      <button class="btn btn-success" @click="save">Save</button>
    </div>
  </div>
</template>

<script>
import service from "services/monitoring";
export default {
  data() {
    return {
      modelData: {
        name: "",
        url: ""
      }
    };
  },
  methods: {
    async save() {
      var result = await service.save(this.modelData);
      if (result.success && result.data && result.data.id) {
        this.$router.push({
          name: "monitoring-list"
        });
      }
    }
  }
};
</script>

<style>
</style>