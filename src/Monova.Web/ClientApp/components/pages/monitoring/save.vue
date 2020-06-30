<template>
  <div>
    <div v-if="loading">
      <content-placeholders>
        <content-placeholders-text :lines="3" />
      </content-placeholders>
    </div>
    <div
      v-else
      class="row"
    >
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
        <button
          class="btn btn-success"
          @click="save"
        >Save</button>
      </div>
    </div>
  </div>
</template>

<script>
import service from "services/monitoring";
export default {
  data() {
    return {
      loading: true,
      modelData: {
        name: null,
        url: null
      }
    };
  },
  async mounted() {
    if (this.$route.params.id) {
      const result = await service.getById(this.$route.params.id);

      if (result.data) this.modelData = result.data;
    }
    this.loading = false;
  },
  methods: {
    async save() {
      if (this.$route.params.id) {
        var result = await service.update(this.modelData);
        if (result.success && result.data && result.data.id) {
          this.$router.push({
            name: "monitoring-list"
          });
        }
      } else {
        var result = await service.save(this.modelData);
        if (result.success && result.data && result.data.id) {
          this.$router.push({
            name: "monitoring-list"
          });
        }
      }
    }
  }
};
</script>

<style>
</style>