<template>
  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <router-link
      to="/"
      class="brand-link"
    >
      <img
        src="/assets/img/AdminLTELogo.png"
        alt="AdminLTE Logo"
        class="brand-image img-circle elevation-3"
        style="opacity: .8"
      />
      <span class="brand-text font-weight-light">Monova</span>
    </router-link>
    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel mt-3 pb-3 mb-3 d-flex">
        <div class="image">
          <img
            src="/assets/img/user2-160x160.jpg"
            class="img-circle elevation-2"
            alt="User Image"
          />
        </div>
        <div class="info">
          <a
            href="#"
            class="d-block"
          >Welcome Ahmet </a>
        </div>
      </div>

      <!-- Sidebar Menu -->
      <nav class="mt-2">
        <ul
          class="nav nav-pills nav-sidebar flex-column"
          data-widget="treeview"
          role="menu"
          data-accordion="false"
        >
          <!-- Add icons to the links using the .nav-icon class
          with font-awesome or any other icon font library-->
          <li
            class="nav-item"
            v-for="(myRoute, i) in routes"
            :key="i"
          >
            <router-link
              v-if="myRoute.component && !myRoute.hidden"
              :to="myRoute.path"
              exact-active-class="active"
              class="nav-link"
            >
              <icon
                :icon="myRoute.icon"
                class="mr-2 menu-icon"
              />
              <p>{{ myRoute.display }}</p>
            </router-link>

            <a
              v-else-if="!myRoute.component"
              :href="myRoute.path"
              class="nav-link"
            >
              <icon
                :icon="myRoute.icon"
                class="mr-2 menu-icon"
              />
              <p>{{ myRoute.display }}</p>
            </a>
          </li>
        </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>
</template>

<script>
import { routes } from "@/router/routes";
export default {
  data() {
    return {
      routes,
      collapsed: true
    };
  }
};
</script>

<style>
</style>