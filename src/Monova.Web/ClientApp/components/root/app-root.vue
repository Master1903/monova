<template>
  <div id="app">
    <notifications />
    <nav-menu params="route: route"></nav-menu>

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
      <section class="content-header">
        <div class="container-fluid">
          <div class="row mb-2">
            <div class="col-sm-12">
              <page-head />
            </div>
          </div>
        </div><!-- /.container-fluid -->
      </section>
      <!-- Main content -->
      <div class="content">
        <div class="container-fluid">
          <router-view></router-view>
        </div>
      </div>
      <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
    <!-- Control Sidebar -->
    <aside class="control-sidebar control-sidebar-dark">
      <!-- Control sidebar content goes here -->
      <div class="p-3">
        <h5>Title</h5>
        <p>Sidebar content</p>
      </div>
    </aside>
  </div>
</template>

<script>
import NavMenu from "./nav-menu";
import PageHead from "@/components/shared/page-head";

export default {
  components: {
    "nav-menu": NavMenu,
    "page-head": PageHead
  },
  data() {
    return {};
  }
};
</script>

<style>
</style>