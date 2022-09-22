<template>

  <van-button text="创建"  />
  <van-list v-model:loading="loading" :finished="finished" finished-text="没有更多了" @load="onLoad">
    <van-cell v-for="item in list" :key="item" :title="item"/>
  </van-list>
</template>

<script>
import {ref} from "vue";

export default {
  name: "index",
  setup() {
    const list = ref([]);
    const loading = ref(false);
    const finished = ref(false);

    const onLoad = () => {
      setTimeout(() => {
        for (let i = 0; i < 10; i++) {
          list.value.push(list.value.length + 1);
        }
        loading.value = false;

        if (list.value.length >= 40) {
          finished.value = true;
        }
        console.log(list.value)
      }, 1000)
    }

    return {
      loading,
      finished,
      list,
      onLoad
    }
  }
}
</script>

<style scoped>

</style>