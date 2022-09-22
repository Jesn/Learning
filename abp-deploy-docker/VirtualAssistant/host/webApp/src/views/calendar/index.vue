<template>
  <!--  日历组件-->
  <van-calendar
      ref="calendarRef"
      color="0A48A9FF"
      :show-title="false"
      :poppable="false"
      :min-date="minDate"
      :show-confirm="false"
      :style="{ height: '390px' }"
      :formatter="formatter"
      @select="calendarSelected"
  >
    <!--    日历组件 top-info 自定义-->
    <template #top-info="item">
      <div style="float: right;color: #15dc15;padding-right: 0.3rem">{{ item.topInfo }}</div>
    </template>
    <template #bottom-info="item">
      <div style="color: red;font-weight:bolder;text-align: center;">{{ item.bottomInfo }}</div>
    </template>
  </van-calendar>
  <template v-if="eventItems.length>0">
    <van-cell>
      <span style="float: left">今天</span>
    </van-cell>
    <van-swipe-cell v-for="item in eventItems">
      <van-cell :border="false" :title="item.content"/>
      <template #right>
        <van-button square type="primary" text="移动"/>
        <van-button square type="danger" text="删除"/>
      </template>
    </van-swipe-cell>
  </template>
  <template v-if="eventItems.length==0">
    <van-empty/>
  </template>

  <!--  新增todoItem-->
  <van-action-sheet v-model:show="eventActionSheetShow">
    <van-row>
      <van-col span="24">
        <van-field v-model="newEventItem.content" rows="2" maxlength="100" type="textarea" placeholder="准备做什么？"
                   autofocus="true" clearable></van-field>
      </van-col>
    </van-row>
    <van-row>
      <van-col span="21">
        <van-space direction="horizontal" style="padding: 5px;">
          <van-icon name="calendar-o" size="25" color="red"/>
          <span>{{ newEventItem.date }}}</span>
          <van-icon name="flag-o" size="25" color="red"/>
          <van-icon name="description" size="25" color="red"/>
        </van-space>
      </van-col>
      <van-col span="3">
        <van-icon name="share" size="25" color="#1989fa" @click="submitEventItem"/>
      </van-col>
    </van-row>
  </van-action-sheet>


  <float-button :item-width="40" :item-height="40" @click="showEventSheet">
    <template #icon>
      <van-icon name="add" size="35" color="red"/>
    </template>
  </float-button>


</template>

<script>
import {computed, onMounted, ref} from "vue";
import FloatButton from "@/components/FloatButton.vue";

// 日历自定义样式文章
// https://blog.csdn.net/xiao_ai123/article/details/124998503

export default {
  name: "index",
  components: {FloatButton},
  setup() {
    const calendarRef = ref(null);
    const asyncData = ref();
    // 事件添加action sheet 是否展示
    let eventActionSheetShow = ref(false);
    let eventItems = ref([]);

    let newEventItem = ref({
      date: '',
      content: ""
    });
    // const formatter = (day) => {
    //   console.log(typeof (day))
    //   const month = day.date.getMonth() + 1;
    //   const date = day.date.getDate();
    //   if (month == 9) {
    //     if (date == 6) {
    //       day.topInfo = "休"
    //       day.bottomInfo = ".";
    //     }
    //   }
    //   return day;
    // };

    //  formatter 中使用异步返回的数据
    const formatter = computed(() => {
      if (!asyncData.value) {
        console.log(1)
        return (day) => day;
      }
      return (day) => {
        console.log(2)
        const month = day.date.getMonth() + 1;
        const date = day.date.getDate();
        if (month == 9) {
          if (date == 7) {
            day.topInfo = "休"
            day.bottomInfo = ".";
          }
        }
        return day;
      }
    });
    // 模拟后端请求数据
    setTimeout(() => {
      asyncData.value = '后端文案';
    }, 3000);


    // IOS中识别不了2022-9-3这种格式，只能识别/
    const formatDate = (date) => `${date.getMonth() + 1}/${date.getDate()}`;
    // 选择日历事件
    const calendarSelected = (date) => {
      getEventItems(date);
    };
    // 初始化后台数据
    const getEventItems = (date) => {
      const month = date.getMonth() + 1;
      const day = date.getDate();
      if (month == 9 && day == 6) {
        eventItems.value = Object.assign([{content: '回家拿快递', status: 1,date:date}, {content: '吃喝玩乐', status: 0,date:date}]);
      } else if (month == 9 && day == 7) {
        eventItems.value = Object.assign([{content: '优化代码', status: 1,date:date}, {content: '休息喝水', status: 0,date:date}]);
      } else {
        eventItems.value = Object.assign([]);
      }
    };
    // 显示新增event 弹框
    const showEventSheet = () => {
      const date = calendarRef.value.getSelectedDate();
      eventActionSheetShow.value = true;
      newEventItem.value = {date: date, content: ''};
      console.log(newEventItem.value)
    };
    // 提交数据
    const submitEventItem = () => {
      // 追加数据
      eventItems.value.push(newEventItem.value)
      // 关闭弹框
      eventActionSheetShow.value = false;
    };
    onMounted(() => {
      const date = calendarRef.value.getSelectedDate();
      getEventItems(date);
    });
    return {
      calendarRef,
      minDate: new Date(2010, 1, 1), //calendar 可选择最小值
      eventItems,
      eventActionSheetShow,
      newEventItem,
      formatter,
      calendarSelected,
      getEventItems,
      showEventSheet,
      submitEventItem
    }
  },

}
</script>

<style scoped>
.content {
  width: 98%;
  margin-top: 15px;
  margin-left: 2px;
  padding: 10px 10px 10px 10px;
  border: none;
}
</style>