<template>
  <div id="app">
    <nav-menu params="route: route"></nav-menu>
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
      <!-- Main content -->
      <div class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-lg-12">
              <router-view></router-view>
            </div>
          </div>
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
export default {
  components: {
    "nav-menu": NavMenu
  },
  data() {
    return {};
  }
};
</script>

<style>
</style>