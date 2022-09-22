<template>
  <van-nav-bar
      title="标题"
      left-text="返回"
      left-arrow
  />
  <router-view/>
  <van-tabbar route>
    <van-tabbar-item replace to="/home" icon="home-o">首页</van-tabbar-item>
    <van-tabbar-item replace to="/calendar" icon="user-o">日历</van-tabbar-item>
    <van-tabbar-item replace to="/user" icon="user-o">我的</van-tabbar-item>
  </van-tabbar>
</template>

<script>
export default {
  name: "Index"
}
</script>

<style scoped>

</style>