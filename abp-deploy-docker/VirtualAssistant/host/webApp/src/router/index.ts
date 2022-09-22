import {createRouter, createWebHistory} from 'vue-router'
import indexLayout from '../views/defaultLayout.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: indexLayout,
            redirect: '/home', // 重定向到home页面
            children: [{
                path: '/home',
                name: 'home',
                component: () => import('../views/home/index.vue'),
                meta: {
                    title: '首页'
                }
            }, {
                path: '/user',
                name: 'user',
                component: () => import('../views/user/index.vue'),
                meta: {
                    title: '用户中心'
                }
            }, {
                path: '/calendar',
                name: 'calendar',
                component: () => import('../views/calendar/index.vue')
            }, {
                path: '/todo',
                name: 'todo',
                component: () => import('../views/todo/index.vue'),
                meta: {
                    title: '代办事项'
                }
            }]
        },
        // {
        //     path: '/about',
        //     name: 'about',
        //     // route level code-splitting
        //     // this generates a separate chunk (About.[hash].js) for this route
        //     // which is lazy-loaded when the route is visited.
        //     component: () => import('../views/AboutView.vue')
        // }
    ]
})

router.beforeEach((to, from, next) => {
    const title = to?.meta?.title
    if (title) {
        document.title = title as string
    }
    next()
})

export default router
