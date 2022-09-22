<template>

  <van-grid :column-num="3" :square="true" :clickable="true" >
    <van-grid-item text="待办" to="/todo"  />
    <van-grid-item text="日历" to="/calendar" />
    <van-grid-item text="待办事项" />

    <van-grid-item text="待办事项" />
    <van-grid-item text="待办事项" />
    <van-grid-item text="待办事项" />
  </van-grid>
</template>

<script>
export default {
  name: "index"
}
</script>

<style scoped>

</style>